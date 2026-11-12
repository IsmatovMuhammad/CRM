using Application.DTOs.Student;
using Application.DTOs.StudentGroup;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class StudentController(
    IStudentService studentService,
    ILogger<StudentController> logger
    ) : ControllerBase
{
    private IStudentService service = studentService;
    private ILogger<StudentController> _logger = logger;
    [HttpGet]
    public async Task<ApiResponse<List<StudentResponse>>> GetStudents()
    {
        _logger.LogInformation("List of Student {Time}", DateTime.Now);
        return await service.GetStudentsAsync();
    }
    
    [HttpGet("{id:int}")]
    public async Task<ApiResponse<StudentResponse>> GetStduent(int id)
    {
        _logger.LogInformation("Student by id {Time}", DateTime.Now);
        return await service.GetStudentAsync(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudent(StudentCreateDto student)
    {
        _logger.LogInformation("Student added {Time}", DateTime.Now);
        return await service.AddStudentAsync(student);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteStudent(int id)
    {
        _logger.LogInformation("Student deleted {Time}", DateTime.Now);
        return await service.DeleteStudentAsync(id);
    }
    
    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateStudent(int id, StudentUpdateDto student)
    {
        _logger.LogInformation("Student updated {Time}", DateTime.Now);
        return await service.UpdateStudentAsync(id, student);
    }

    [HttpGet("total-student-count")]
    public async Task<ApiResponse<int>> GetTotalStudentCount()
    {
        _logger.LogInformation("total student {Time}", DateTime.Now);
        return await service.GetTotalStudentsCountAsync();
    }

    [HttpGet("Student-with-group")]
    public async Task<ApiResponse<List<StudentGroupResponseDto>>> GetStudentWithGroup()
    {
        _logger.LogInformation("Student with group {Time}", DateTime.Now);
        return await service.GetStudentsWithGroupsAsync();
    }

    [HttpGet("Student-without-group")]
    public async Task<ApiResponse<List<StudentGroupResponseDto>>> GetStudentWithoutGruop()
    {
        _logger.LogInformation("Student without group {Time}", DateTime.Now);
        return await service.GetStudentsWithoutGroupsAsync();
    }

    [HttpGet("dropped-out-student")]
    public async Task<ApiResponse<List<StudentGroupResponseDto>>> GetDroppedOutStudent()
    {
        _logger.LogInformation("Get dropped Student {Time}", DateTime.Now);
        return await service.GetDroppedOutStudents();
    }

    [HttpGet("graduated-student")]
    public async Task<ApiResponse<List<StudentGroupResponseDto>>> GetGraduatedStudent()
    {
        _logger.LogInformation("Graduated Student {Time}", DateTime.Now);
        return await service.GetGraduatedStudents();
    }
}
