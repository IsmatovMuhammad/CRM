using Application.DTOs.StudentGroup;
using Application.Interfaces;
using Application.Responses;
using Application.Service;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class StudentGroupController(
    IStudentGroupService studentGroupService,
    ILogger<StudentGroupController> logger 
    ) : ControllerBase
{
    private IStudentGroupService service = studentGroupService;
    private ILogger<StudentGroupController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<StudentGroupResponseDto>>> GetStudentGroups()
    {
        _logger.LogInformation("List of Studentgroup {Time}", DateTime.Now);
        return await service.GetStudentGroups();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<StudentGroupResponseDto>> GetStudentGroup(int id)
    {
        _logger.LogInformation("Studentgroup by id {Time}", DateTime.Now);
        return await service.GetStudentGroup(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudentGroup(StudentGroupCreateDto studentGroup)
    {
        _logger.LogInformation("Studentgroup added {Time}", DateTime.Now);
        return await service.AddStudentGroup(studentGroup);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeletedStudentGroup(int id)
    {
        _logger.LogInformation("Studentgroup deleted {Time}", DateTime.Now);
        return await service.DeleteStudentGroup(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateStudentGroup(int id, StudentGroupUpdateDto studentGroup)
    {
        _logger.LogInformation("Studentgroup updated {Time}", DateTime.Now);
        return await service.UpdateStudentGroup(id, studentGroup);
    }

    [HttpGet("start-dates")]
    public async Task<ApiResponse<int>> GetAllStartDates()
    {
        _logger.LogInformation("Start dates by id {Time}", DateTime.Now);
        return await service.GetAllStartDates();
    }
}
