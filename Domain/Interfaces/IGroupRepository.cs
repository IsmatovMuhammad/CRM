using System.Text.RegularExpressions;

namespace Domain.Interfaces;

public interface IGroupRepository
{
    bool AddGroup(Group group);
    bool DeleteGroup(int id);
    bool UpdateGroup(Group group);
    Group GetGroup(int id);
    List<Group> GetGroups();
    int GetTotalGroupsCount();
}
