using System.Text.RegularExpressions;
using Application.DTOs.Group;
using Application.Responses;

namespace Application.Interfaces;

public interface IGroupService
{
    Task<ApiResponse<bool>> AddGroupAsync(GroupCreateDto group);
    Task<ApiResponse<bool>> DeleteGroupAsync(int id);
    Task<ApiResponse<bool>> UpdateGroupAsync(int id, GroupUpdateDto group);
    Task<ApiResponse<GroupResponseDto>> GetGroup(int id);
    Task<ApiResponse<List<GroupResponseDto>>> GetGroups();
    Task<ApiResponse<int>> GetStudentsPerGroup();
    Task<ApiResponse<int>> GetEmptyGroups();
}
