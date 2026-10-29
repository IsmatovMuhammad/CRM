using System.Runtime.InteropServices;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class MentorRepository(DataBase dataBase) : IMentorRepository
{
    private DataBase data = dataBase;
    public bool AddMentor(Mentor mentor)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "insert into mentors(fullname, email, phone, specialization)values(@fullname, @email, @phone, @specialization)";
        var mento = conn.Execute(query, mentor);
        return mento > 0;
    }

    public bool DeleteMentor(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "delete from mentors where id = @id";
        var mento = conn.Execute(query, new{id});
        return mento > 0;
    }

    public Mentor? GetMentor(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from mentors where id = @id";
        var mento = conn.QuerySingleOrDefault<Mentor>(query, new{id});
        return mento;
    }

    public List<Mentor> GetMentors()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from mentors";
        var mento = conn.Query<Mentor>(query).ToList();
        return mento;
    }

    public int GetTotalMentorsCount()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select count(*) from mentors";
        var mento = conn.ExecuteScalar<int>(query);
        return mento;
    }


    public bool UpdateMentor(Mentor mentor)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "update mentors set fullname = @fullname, email = @email, phone = @phone, specialization = @specialization";
        var mento = conn.Execute(query, mentor);
        return mento > 0;
    }

}
