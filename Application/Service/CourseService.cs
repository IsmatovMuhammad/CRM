using System.Diagnostics.CodeAnalysis;
using System.Net;
using Application.DTOs.Course;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.VisualBasic;

namespace Application.Service;

public class CourseService(ICourseRepository courserepo) : ICourseService
{
    private ICourseRepository repository = courserepo;

    public async Task<ApiResponse<bool>> AddCourseAsync(CourseCreateDto course)
    {
        var cour = new Course()
        {
            Title = course.Title,
            Description = course.Description,
            DurationWeeks = course.DurationWeeks
        };
        var res = await repository.AddCourseAsync(cour);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Course added !")
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Course not added !");
    }

    public async Task<ApiResponse<bool>> DeleteCourseAsync(int id)
    {
        var con = await repository.DeleteCourseAsync(id);
        return con == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Course deleted !", con)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Course not deleted !");
    }

    public async Task<ApiResponse<CourseResponseDto>> GetCourseAsync(int id)
    {
        var con = await repository.GetCourseAsync(id);
        var res = new CourseResponseDto
        {
            CourseId = con.CourseId,
            Title = con.Title,
            Description = con.Description,
            DurationWeeks = con.DurationWeeks
        };
        return new ApiResponse<CourseResponseDto>(HttpStatusCode.OK, "Course by id. ", res);
    }

    public async Task<ApiResponse<List<CourseResponseDto>>> GetCoursesAsync()
    {
        var con = await repository.GetCoursesAsync();
        var res = con.Select(s => new CourseResponseDto
        {
            CourseId = s.CourseId,
            Title = s.Title,
            Description = s.Description,
            DurationWeeks = s.DurationWeeks
        }).ToList();
        return new ApiResponse<List<CourseResponseDto>>(HttpStatusCode.OK, "List of course. ", res);
    }

    public async Task<ApiResponse<int>> GetLeastPopularCourses()
    {
        var con = await repository.GetLeastPopularCourses();
        return new ApiResponse<int>(HttpStatusCode.OK, "Popular course", con);
    }

    public async Task<ApiResponse<int>> GetStudentsPerCourse()
    {
        var con = await repository.GetStudentsPerCourse();
        return new ApiResponse<int>(HttpStatusCode.OK, "Student per course", con);
    }

    public async Task<ApiResponse<int>> GetTopThreeCourses()
    {
        var con = await repository.GetTopThreeCourses();
        return new ApiResponse<int>(HttpStatusCode.OK, "Top three course. ", con);
    }

    public async Task<ApiResponse<int>> GetTotalCoursesCountAsync()
    {
        var con = await repository.GetTotalCoursesCountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Total course count. ", con);
    }

    public async Task<ApiResponse<bool>> UpdateCourseAsync(int id, CourseUpdateDto course)
    {
        var cour = new Course()
        {
            CourseId = id,
            Title = course.Title,
            Description = course.Description,
            DurationWeeks = course.DurationWeeks
        };
        var con = await repository.UpdateCourseAsync(cour);
        return con == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Course updated !", con)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Course not updated !");
    }
}
