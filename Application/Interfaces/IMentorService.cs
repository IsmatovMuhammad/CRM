using Application.DTOs.Mentor;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IMentorService
{
    Task<ApiResponse<bool>> AddMentor(MentorCreateDto mentor);
    Task<ApiResponse<bool>> DeleteMentor(int id);
    Task<ApiResponse<bool>> UpdateMentor(int id, MentorUpdateDto mentor);
    Task<ApiResponse<MentorResponseDto>> GetMentor(int id);
    Task<ApiResponse<List<MentorResponseDto>>> GetMentors();
    Task<ApiResponse<int>> GetTotalMentorsCount();
    Task<ApiResponse<MentorResponseDto>> GetMentorWithMostStudents();
    Task<ApiResponse<List<MentorResponseDto>>> GetMentorsWithMultipleCourses();
}
