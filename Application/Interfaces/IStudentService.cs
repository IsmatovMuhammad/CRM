using Application.DTOs.Student;
using Application.DTOs.StudentGroup;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IStudentService
{
    Task<ApiResponse<bool>> AddStudentAsync(StudentCreateDto student);
    Task<ApiResponse<bool>> UpdateStudentAsync(int id, StudentUpdateDto student);
    Task<ApiResponse<bool>> DeleteStudentAsync(int id);
    Task<ApiResponse<StudentResponse>> GetStudentAsync(int id);
    Task<ApiResponse<List<StudentResponse>>> GetStudentsAsync();
    Task<ApiResponse<int>> GetTotalStudentsCountAsync();
    Task<ApiResponse<List<StudentGroupResponseDto>>> GetStudentsWithGroupsAsync();
    Task<ApiResponse<List<StudentGroupResponseDto>>> GetStudentsWithoutGroupsAsync();
    Task<ApiResponse<List<StudentGroupResponseDto>>> GetDroppedOutStudents();
    Task<ApiResponse<List<StudentGroupResponseDto>>> GetGraduatedStudents();
}
