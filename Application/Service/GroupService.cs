using System.Text.RegularExpressions;
using Application.Interfaces;
using Infrastructure.Repository;

namespace Application.Service;

public class GroupService(GroupRepository repository) : IGroupService
{
    private GroupRepository group1 = repository;
    public async Task AddGroupAsync(Group group)
    {
        var add = await group1.AddGroupAsync(group);
        if(add) System.Console.WriteLine("Added successfylly!!");
        else System.Console.WriteLine("Samting wrong!!");
    }

    public async Task DeleteGroupAsync(int id)
    {
        var delete = await group1.DeleteGroupAsync(id);
        if(delete) System.Console.WriteLine("Deleted successfully!!");
        else System.Console.WriteLine("Samting wrong!!");
    }

    public async Task<Group> GetGroup(int id)
    {
        var show = await group1.GetGroup(id);
        return show;
    }

    public async Task<List<Group>> GetGroups()
    {
        var showall = await group1.GetGroups();
        return showall;
    }

    public async Task UpdateGroupAsync(Group group)
    {
        var update = await group1.UpdateGroupAsync(group);
        if(update) System.Console.WriteLine("Updated Succassfylly!!");
        else System.Console.WriteLine("Samething wrong!!");
    }

}
