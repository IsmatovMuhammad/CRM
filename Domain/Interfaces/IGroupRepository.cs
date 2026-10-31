using System.Text.RegularExpressions;

namespace Domain.Interfaces;

public interface IGroupRepository
{
    Task<bool> AddGroupAsync(Group group);
    Task<bool> DeleteGroupAsync(int id);
    Task<bool> UpdateGroupAsync(Group group);
    Task<Group> GetGroup(int id);
    Task<List<Group>> GetGroups();
    Task<int> GetStudentsPerGroup();
    Task<int> GetEmptyGroups();
}
