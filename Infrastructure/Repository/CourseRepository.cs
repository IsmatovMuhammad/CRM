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
        var query = "delete from courses where id = @id";
        var cours = await conn.ExecuteAsync(query, new{id});
        return cours > 0;
    }

    public async Task<Course> GetCourseAsync(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from courses where id = @id";
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
        var query = "update courses set title = @title, description = @description, durationweeks = @durationweeks where id = @id)";
        var cours = await conn.ExecuteAsync(query, course);
        return cours > 0;
    }

}
