using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class StudentGroupRepository(DataBase dataBase) : IStudentGroupRepository
{
    private DataBase data = dataBase;
    public bool AddStudentGroup(StudentGroup studentGroup)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "insert into studentgroups(studentid, groupid, status)values(@studentid, @groupid, @status)";
        var mento = conn.Execute(query, studentGroup);
        return mento > 0;
    }

    public bool DeleteStudentGroup(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "delete from studentgroups where id = @id";
        var mento = conn.Execute(query, new{id});
        return mento > 0;
    }

    public int GetAllStartDates()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select count(*) from studentgroups";
        var start = conn.ExecuteScalar<int>(query);
        return start;
    }


    public StudentGroup? GetStudentGroup(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from studentgroups where id = @id";
        var mento = conn.QuerySingleOrDefault<StudentGroup>(query, id);
        return mento;
    }

    public List<StudentGroup> GetStudentGroups()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from";
        var mento = conn.Query<StudentGroup>(query).ToList();
        return mento;
    }

    public bool UpdateStudentGroup(StudentGroup studentGroup)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "update studentgroup set studentid = @studentid, groupid = @gruopid, status = @status";
        var mento = conn.Execute(query, studentGroup);
        return mento > 0;
    }

}
