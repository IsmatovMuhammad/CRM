using System.Text.RegularExpressions;
using Domain.Models;

namespace Domain.Interfaces;

public interface IGroupRepository
{
    Task<bool> AddGroupAsync(Groups group);
    Task<bool> DeleteGroupAsync(int id);
    Task<bool> UpdateGroupAsync(Groups group);
    Task<Groups> GetGroup(int id);
    Task<List<Groups>> GetGroups();
    Task<int> GetStudentsPerGroup();
    Task<int> GetEmptyGroups();

}
