using System.Runtime.InteropServices;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class MentorRepository(DataBase dataBase) : IMentorRepository
{
    private DataBase data = dataBase;
    public async Task<bool> AddMentor(Mentor mentor)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "insert into mentors(fullname, email, phone, specialization)values(@fullname, @email, @phone, @specialization)";
        var mento = await conn.ExecuteAsync(query, mentor);
        return mento > 0;
    }

    public async Task<bool> DeleteMentor(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "delete from mentors where mentorid = @id";
        var mento = await conn.ExecuteAsync(query, new{id});
        return mento > 0;
    }

    public async Task<Mentor> GetMentor(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from mentors where mentorid = @id";
        var mento = await conn.QuerySingleAsync<Mentor>(query, new{id});
        return mento;
    }

    public async Task<List<Mentor>> GetMentors()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from mentors";
        var mento = await conn.QueryAsync<Mentor>(query);
        return mento.ToList();
    }

    public async Task<List<Mentor>> GetMentorsWithMultipleCourses()
    {
        using var conn = data.Connection();
        conn.Open();

        var query = @"select m.* from mentors m
                  join groups g on g.mentorid = m.mentorid
                  group by m.mentorid
                  having count(distinct g.courseid) > 1";

        var mento = await conn.QueryAsync<Mentor>(query);
        return mento.ToList();
    }


    public async Task<Mentor> GetMentorWithMostStudents()
    {
        using var conn = data.Connection();
        conn.Open();

        var query = @"select m.*, count(distinct sg.studentid) as student_count 
        from mentors m 
        join groups g on g.mentorid = m.mentorid
        join studentgroups sg on sg.groupid = g.groupid
        group by m.mentorid
        order by student_count desc
        limit 1";

        var mento = await conn.QueryFirstOrDefaultAsync<Mentor>(query);
        return mento;
    }


    public async Task<int> GetTotalMentorsCount()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select count(*) from mentors";
        var mento = await conn.ExecuteScalarAsync<int>(query);
        return mento;
    }


    public async Task<bool> UpdateMentor(Mentor mentor)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "update mentors set fullname = @fullname, email = @email, phone = @phone, specialization = @specialization where mentorid = @mentorid";
        var mento = await conn.ExecuteAsync(query, mentor);
        return mento > 0;
    }
}
