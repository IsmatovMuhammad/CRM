using System.Net;
using Application.DTOs.Mentor;
using Application.Interfaces;
using Application.Responses;
using Application.Service;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MentorController(
    IMentorService mentorService,
    ILogger<MentorController> logger
    ) : ControllerBase
{
    private IMentorService service = mentorService;
    private ILogger<MentorController> _logger = logger;
    
    [HttpGet]
    public async Task<ApiResponse<List<MentorResponseDto>>> GetMentors()
    {
        _logger.LogInformation("List of Mentor. {Time}", DateTime.Now);
        return await service.GetMentors();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<MentorResponseDto>> GetMentor(int id)
    {
        _logger.LogInformation("Mentor by id. {Time}", DateTime.Now);
        return await service.GetMentor(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMentor(MentorCreateDto mentor)
    {
        _logger.LogInformation("Mentor added ! {Time}", DateTime.Now);
        return await service.AddMentor(mentor);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeletedMentor(int id)
    {
        _logger.LogInformation("Mentor deleted. {Time}", DateTime.Now);
        return await service.DeleteMentor(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateMentor(int id, MentorUpdateDto mentor)
    {
        _logger.LogInformation("Mentor updated ! {Time}", DateTime.Now);
        return await service.UpdateMentor(id, mentor);
    }

    [HttpGet("total-mentor-count")]
    public async Task<ApiResponse<int>> GetTotalMentorCount()
    {
        _logger.LogInformation("Total mentor count {Time}", DateTime.Now);
        return await service.GetTotalMentorsCount();
    }

    [HttpGet("mentor-with most-student")]
    public async Task<ApiResponse<MentorResponseDto>> GetMentorWithMostStudent()
    {
        _logger.LogInformation("Mentor with most student {Time}", DateTime.Now);
        return await service.GetMentorWithMostStudents();
    }

    [HttpGet("mentor-with-multiole-course")]
    public async Task<ApiResponse<List<MentorResponseDto>>> GetMentorWithMultipleCourse()
    {
        _logger.LogInformation("Mentor With Multiple Course {Time}", DateTime.Now);
        return await service.GetMentorsWithMultipleCourses();
    }
}
