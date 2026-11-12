using Application.DTOs.Course;
using Application.Interfaces;
using Application.Responses;
using Application.Service;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]

public class CourseController(
    ICourseService courseService,
    ILogger<CourseController> logger
    ) : ControllerBase
{
    private ICourseService service = courseService;
    private ILogger<CourseController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<CourseResponseDto>>> GetCourses()
    {
        _logger.LogInformation("List of Course. {Time}", DateTime.Now);
        return await service.GetCoursesAsync();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCourse(CourseCreateDto course)
    {
        _logger.LogInformation("Course Added {Time}", DateTime.Now);
        return await service.AddCourseAsync(course);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCourse(int id)
    {
        _logger.LogInformation("Course deleted {Time}", DateTime.Now);
        return await service.DeleteCourseAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCourse(int id, CourseUpdateDto course)
    {
        _logger.LogInformation("Course updated {Time}", DateTime.Now);
        return await service.UpdateCourseAsync(id, course);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CourseResponseDto>> GetCourse(int id)
    {
        _logger.LogInformation("Course by id {Time}", DateTime.Now);
        return await service.GetCourseAsync(id);
    }

    [HttpGet("least-popular")]
    public async Task<ApiResponse<int>> GetLeastPopularCourses()
    {
        _logger.LogInformation("Least popular course {Time}", DateTime.Now);
        return await service.GetLeastPopularCourses();
    }

    [HttpGet("top-tree")]
    public async Task<ApiResponse<int>> GetTopThreeCourses()
    {
        _logger.LogInformation("Top three course {Time}", DateTime.Now);
        return await service.GetTopThreeCourses();
    }

    [HttpGet("students-per-course")]
    public async Task<ApiResponse<int>> GetStudentsPerCourse()
    {
        _logger.LogInformation("Student per course {Time}", DateTime.Now);
        return await service.GetStudentsPerCourse();
    }

    [HttpGet("total-count")]
    public async Task<ApiResponse<int>> GetTotalCoursesCount()
    {
        _logger.LogInformation("Total course count {Time}", DateTime.Now);
        return await service.GetTotalCoursesCountAsync();
    }
}