using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Dapper;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GroupRepository(DataBase data1) : IGroupRepository
{
    private DataBase data = data1;
    public async Task<bool> AddGroupAsync(Group group)
    {
        using var conn = data.Connection();
        conn.Open();

        var query = "insert into groups(groupname, courseid, mentorid, startdate, enddate)values(@groupname, @courseid, @mentorid, @startdate, @enddate)";
        
        var grou = await conn.ExecuteAsync(query, group);
        return grou > 0;
    }

    public async Task<bool> DeleteGroupAsync(int id)
    {
        using var conn = data.Connection();
        conn.Open();

        var query = "delete from groups where id = @id";
        
        var grou = await conn.ExecuteAsync(query, new{id});
        return grou > 0;
    }

    public async Task<int> GetEmptyGroups()
    {
        using var conn = data.Connection();
        conn.Open();

        var query = @"select g.* from group g
        left join studentgroups sg on sg.groupid= g.groupid
        left join students s on s.studentid = sg.studentid
        where s.studentid is null";

        var gru = await conn.ExecuteScalarAsync(query);
        return Convert.ToInt32(gru);
    }


    public async Task<Group> GetGroup(int id)
    {
        using var conn = data.Connection();
        conn.Open();

        var query = "select * from groups where id = @id";
        var gru = await conn.QuerySingleAsync(query, new{id});
        return gru;
    }

    public async Task<List<Group>> GetGroups()
    {
        using var conn = data.Connection();
        conn.Open();

        var query = "select * from groups";
        var gru = await conn.QueryAsync<Group>(query);
        return gru.ToList();
    }

    public async Task<int> GetStudentsPerGroup()
    {
        using var conn = data.Connection();
        conn.Open();

        var query = @"select g.groupname, count(s.*) from group g
        join studentgroups sg on sg.groupid= g.groupid
        join students s on s.studentid = sg.studentid";

        var gru = await conn.ExecuteScalarAsync(query);
        return Convert.ToInt32(gru);
    }


    public async Task<bool> UpdateGroupAsync(Group group)
    {
        using var conn = data.Connection();

        var query = @"update groups set groupname = @groupname, courseid = @courseid, mentorid = @mentorid, startdate = @startdate, enddate = @enddate where id = @id";

        var stud = await conn.ExecuteAsync(query, group);
        return stud>0;
    }

}
