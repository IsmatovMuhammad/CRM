using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CourseRepository(DataBase dataBase) : ICourseRepository
{
    private DataBase data = dataBase;
    public bool AddCourse(Course course)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "insert into courses (title, description, durationweeks)values(@title, @description, @durationweeks)";
        var cours = conn.Execute(query, course);
        return cours > 0;
    }

    public bool DeleteCourse(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "delete from courses where id = @id";
        var cours = conn.Execute(query, new{id});
        return cours > 0;
    }

    public Course? GetCourse(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from courses where id = @id";
        var cours = conn.QuerySingleOrDefault<Course>(query, new{id});
        return cours;
    }

    public List<Course> GetCourses()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from courses";
        var cours = conn.Query<Course>(query).ToList();
        return cours;
    }

    public int GetTotalCoursesCount()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select count(*) from courses";
        var cours = conn.ExecuteScalar<int>(query);
        return cours;
    }


    public bool UpdateCourse(Course course)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "update courses set title = @title, description = @description, durationweeks = @durationweeks where id = @id)";
        var cours = conn.Execute(query, course);
        return cours > 0;
    }

}
