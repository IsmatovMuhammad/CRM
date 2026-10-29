
using System.Text.RegularExpressions;

namespace Application.Interfaces;

public interface IGroupService
{
    void AddGroup(Group group);
    void DeleteGroup(int id);
    void UpdateGroup(Group group);
    void GetGroup(int id);
    void GetGroups();
    void GetTotalGroupsCount();
}
