using System.Runtime.InteropServices;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CourseRepository(DataBase dataBase) : ICourseRepository
{
    private DataBase data = dataBase;
    public async Task<bool> AddCourseAsync(Course course)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "insert into courses (title, description, durationweeks)values(@title, @description, @durationweeks)";
        var cours = await conn.ExecuteAsync(query, course);
        return cours > 0;
    }

    public async Task<bool> DeleteCourseAsync(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "delete from courses where courseid = @id";
        var cours = await conn.ExecuteAsync(query, new{id});
        return cours > 0;
    }

    public async Task<Course> GetCourseAsync(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from courses where courseid = @id";
        var cours = await conn.QuerySingleAsync<Course>(query, new{id});
        return cours;
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from courses";
        var cours = await conn.QueryAsync<Course>(query);
        return cours.ToList();
    }

    public async Task<int> GetLeastPopularCourses()
    {
        using var conn = data.Connection();
        conn.Open();

        var query = @"select c.*, count(s.studentid) as studentcount from courses c
        left join groups g on c.courseid = g.courseid
        left join studentgroups sg on sg.groupid = g.groupid
        left join students s on s.studentid = sg.studentid
        order by studentcount asc
        limit 3";

        var cours = await conn.ExecuteAsync(query);
        return cours;
    }


    public async Task<int> GetStudentsPerCourse()
    {
        using var conn = data.Connection();
        conn.Open();

        var query = @"select c.title, count(s.*) from courses c
        join groups g on c.courseid = g.courseid
        join studentgroups sg on sg.groupid = g.groupid
        join students s on s.studentid = sg.studentid
        group by c.courseid, c.title";

        var cours = await conn.ExecuteAsync(query);
        return cours;
    }

    public async Task<int> GetTopThreeCourses()
    {
        using var conn = data.Connection();
        conn.Open();

        var query = @"select c.* from courses c
        join groups g on c.courseid = g.courseid
        join studentgroups sg on sg.groupid = g.groupid
        join students s on s.studentid = sg.studentid
        order by students desc
        limit 3";

        var gru = await conn.ExecuteAsync(query);
        return gru;
    }

    public async Task<int> GetTotalCoursesCountAsync()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select count(*) from courses";
        var cours = await conn.ExecuteAsync(query);
        return cours;
    }


    public async Task<bool> UpdateCourseAsync(Course course)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "update courses set title = @title, description = @description, durationweeks = @durationweeks where courseid = @id)";
        var cours = await conn.ExecuteAsync(query, course);
        return cours > 0;
    }

}
