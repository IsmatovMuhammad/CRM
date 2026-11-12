using Application.DTOs.Course;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface ICourseService
{ 
    Task<ApiResponse<bool>> AddCourseAsync(CourseCreateDto course);
    Task<ApiResponse<bool>> DeleteCourseAsync(int id);
    Task<ApiResponse<bool>> UpdateCourseAsync(int id, CourseUpdateDto course);
    Task<ApiResponse<CourseResponseDto>> GetCourseAsync(int id);
    Task<ApiResponse<List<CourseResponseDto>>> GetCoursesAsync();
    Task<ApiResponse<int>> GetTotalCoursesCountAsync();
    Task<ApiResponse<int>> GetStudentsPerCourse();
    Task<ApiResponse<int>> GetLeastPopularCourses();
    Task<ApiResponse<int>> GetTopThreeCourses();
}
