using System.Text.RegularExpressions;

namespace Application.Interfaces;

public interface IGroupService
{
    Task AddGroupAsync(Group group);
    Task DeleteGroupAsync(int id);
    Task UpdateGroupAsync(Group group);
    Task<Group> GetGroup(int id);
    Task<List<Group>> GetGroups();
}
