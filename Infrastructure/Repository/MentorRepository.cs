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
        var query = "delete from mentors where id = @id";
        var mento = await conn.ExecuteAsync(query, new{id});
        return mento > 0;
    }

    public async Task<Mentor> GetMentor(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from mentors where id = @id";
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

    public async Task<int> GetTotalMentorsCount()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select count(*) from mentors";
        var mento = await conn.ExecuteAsync(query);
        return mento;
    }


    public async Task<bool> UpdateMentor(Mentor mentor)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "update mentors set fullname = @fullname, email = @email, phone = @phone, specialization = @specialization";
        var mento = await conn.ExecuteAsync(query, mentor);
        return mento > 0;
    }
}
