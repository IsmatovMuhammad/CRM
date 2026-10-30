using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class StudentGroupRepository(DataBase dataBase) : IStudentGroupRepository
{
    private DataBase data = dataBase;
    public async Task<bool> AddStudentGroup(StudentGroup studentGroup)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "insert into studentgroups(studentid, groupid, status)values(@studentid, @groupid, @status)";
        var mento = await conn.ExecuteAsync(query, studentGroup);
        return mento > 0;
    }

    public async Task<bool> DeleteStudentGroup(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "delete from studentgroups where id = @id";
        var mento = await conn.ExecuteAsync(query, new{id});
        return mento > 0;
    }

    public async Task<int> GetAllStartDates()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select count(*) from studentgroups";
        var start = await conn.ExecuteAsync(query);
        return start;
    }


    public async Task<StudentGroup> GetStudentGroup(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from studentgroups where id = @id";
        var mento = await conn.QuerySingleAsync<StudentGroup>(query, id);
        return mento;
    }

    public async Task<List<StudentGroup>> GetStudentGroups()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from";
        var mento = await conn.QueryAsync<StudentGroup>(query);
        return mento.ToList();
    }

    public async Task<bool> UpdateStudentGroup(StudentGroup studentGroup)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "update studentgroup set studentid = @studentid, groupid = @gruopid, status = @status";
        var mento = await conn.ExecuteAsync(query, studentGroup);
        return mento > 0;
    }

}
