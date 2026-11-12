using Application.DTOs.StudentGroup;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IStudentGroupService
{
    Task<ApiResponse<bool>> AddStudentGroup(StudentGroupCreateDto studentGroup);
    Task<ApiResponse<bool>> DeleteStudentGroup(int id);
    Task<ApiResponse<bool>> UpdateStudentGroup(int id, StudentGroupUpdateDto studentGroup);
    Task<ApiResponse<StudentGroupResponseDto>> GetStudentGroup(int id);
    Task<ApiResponse<List<StudentGroupResponseDto>>> GetStudentGroups();
    Task<ApiResponse<int>> GetAllStartDates();
}
