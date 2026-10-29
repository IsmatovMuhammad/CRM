using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Application.Interfaces;
using Infrastructure.Repository;

namespace Application.Service;

public class GroupService(GroupRepository repository) : IGroupService
{
    private GroupRepository group1 = repository;
    public void AddGroup(Group group)
    {
        
    }

    public void AddGroup(Domain.Models.Group group)
    {
        var result = group1.AddGroup(group);
        if(result) System.Console.WriteLine("Added Successfully !!");
        else System.Console.WriteLine("Sameting wrong !!");
    }


    public void DeleteGroup(int id)
    {
        var result = group1.DeleteGroup(id);
        if(result) System.Console.WriteLine("Deleted Successfully !!");
        else System.Console.WriteLine("Sameting wrong !!");
    }

    public void GetGroup(int id)
    {
        var res = group1.GetGroup(id);
        System.Console.WriteLine(res.GroupId);
    }

    public void GetGroups()
    {
        var result = group1.GetGroups();
        foreach (var i in result)
        {
            System.Console.WriteLine(i.Group);
        }
    }

    public void GetTotalGroupsCount()
    {
        throw new NotImplementedException();
    }


    public void UpdateGroup(Group group)
    {
        var conn = group1.UpdateGroup(group);
        if(conn) System.Console.WriteLine("Update Successfully !!");
        else System.Console.WriteLine("Sameting wrongs !!");
    }

    public void UpdateGroup(Domain.Models.Group group)
    {
        throw new NotImplementedException();
    }
}
