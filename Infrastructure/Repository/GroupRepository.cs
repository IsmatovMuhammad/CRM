using System.Text.RegularExpressions;
using Dapper;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GroupRepository(DataBase dataBase) : IGroupRepository
{
    private DataBase data = dataBase;
    public bool AddGroup(Group group)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "insert into (groupname, courseid, mentorid, startdate, enddate)values(@groupname, @courseid, @mentorid, @startdate, @enddate)";
        var cours = conn.Execute(query, group);
        return cours > 0;
    }

    public bool DeleteGroup(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "delete from groups where id = @id";
        var cours = conn.Execute(query, new{id});
        return cours > 0;
    }

    public Group? GetGroup(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "Select * from groups where id = @id";
        var cours = conn.QuerySingleOrDefault<Group>(query, id);
        return cours;
    }

    public List<Group> GetGroups()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from groups";
        var cours = conn.Query<Group>(query).ToList();
        return cours;
    }

    public int GetTotalGroupsCount()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select count(*) from groups";
        var group = conn.ExecuteScalar<int>(query);
        return group;
    }


    public bool UpdateGroup(Group group)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "update courses set groupname = @groupname, courseid = @courseid, mentorid = @mentorid, startdate = @startdate, enddate = @enddate";
        var cours = conn.Execute(query, group);
        return cours > 0;
    }

}
