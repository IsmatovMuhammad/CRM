using System.Net;
using Application.DTOs.Student;
using Application.DTOs.StudentGroup;
using Application.Interfaces;
using Application.Responses;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Application.Service;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    private IStudentRepository repository = studentRepository;

    public async Task<ApiResponse<bool>> AddStudentAsync(StudentCreateDto student)
    {
        var res = new Student()
        {
            Fullname = student.Fullname,
            Email = student.Email,
            Phone = student.Phone,
            EnrollmentDate = student.EnrollmentDate
        };
        var con = await repository.AddStudentAsync(res);
        return con == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Student added !")
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Student not added !");
    }

    public async Task<ApiResponse<bool>> DeleteStudentAsync(int id)
    {
        var con = await repository.DeleteStudentAsync(id);
        return con == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Student deleted", con)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Student not deleted !");
    }

    public async Task<ApiResponse<List<StudentGroupResponseDto>>> GetDroppedOutStudents()
    {
        var con = await repository.GetDroppedOutStudents();
        var res = con.Select(s => new StudentGroupResponseDto
        {
            StudentGroupId = s.StudentGroupId,
            StudentId = s.StudentId,
            GroupId = s.GroupId,
            Status = s.Status
        }).ToList();
        return new ApiResponse<List<StudentGroupResponseDto>>(HttpStatusCode.OK, "Dropped out Student !", res);
    }

    public async Task<ApiResponse<List<StudentGroupResponseDto>>> GetGraduatedStudents()
    {
        var con = await repository.GetGraduatedStudents();
        var res = con.Select(s => new StudentGroupResponseDto
        {
            StudentGroupId = s.StudentGroupId,
            StudentId = s.StudentId,
            GroupId = s.GroupId,
            Status = s.Status
        }).ToList();
        return new ApiResponse<List<StudentGroupResponseDto>>(HttpStatusCode.OK, "Dropped out Student !", res);
    }

    public async Task<ApiResponse<StudentResponse>> GetStudentAsync(int id)
    {
        var con = await repository.GetStudentAsync(id);
        var res = new StudentResponse
        {
            StudentId = con.StudentId,
            Fullname = con.Fullname,
            Email = con.Email,
            Phone = con.Phone,
            EnrollmentDate = con.EnrollmentDate
        };
        return new ApiResponse<StudentResponse>(HttpStatusCode.OK, "Student by id. ", res);
    }

    public async Task<ApiResponse<List<StudentResponse>>> GetStudentsAsync()
    {
        var con = await repository.GetStudentsAsync();
        var res = con.Select(s => new StudentResponse
        {
            StudentId = s.StudentId,
            Fullname = s.Fullname,
            Email = s.Email,
            Phone = s.Phone,
            EnrollmentDate = s.EnrollmentDate
        }).ToList();
        return new ApiResponse<List<StudentResponse>>(HttpStatusCode.OK, "List Of Student", res);
    }

    public async Task<ApiResponse<List<StudentGroupResponseDto>>> GetStudentsWithGroupsAsync()
    {
        var con = await repository.GetStudentsWithGroupsAsync();
        var res = con.Select(s => new StudentGroupResponseDto
        {
            StudentGroupId = s.StudentGroupId,
            StudentId = s.StudentId,
            GroupId = s.GroupId,
            Status = s.Status
        }).ToList();
        return new ApiResponse<List<StudentGroupResponseDto>>(HttpStatusCode.OK, "Student With Group. ", res);
    }

    public async Task<ApiResponse<List<StudentGroupResponseDto>>> GetStudentsWithoutGroupsAsync()
    {
        var con = await repository.GetStudentsWithoutGroupsAsync();
        var res = con.Select(s => new StudentGroupResponseDto
        {
            StudentGroupId = s.StudentGroupId,
            StudentId = s.StudentId,
            GroupId = s.GroupId,
            Status = s.Status
        }).ToList();
        return new ApiResponse<List<StudentGroupResponseDto>>(HttpStatusCode.OK, "Student without group. ", res);
    }

    public async Task<ApiResponse<int>> GetTotalStudentsCountAsync()
    {
        var con = await repository.GetTotalStudentsCountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Total student count. ", con);
    }

    public async Task<ApiResponse<bool>> UpdateStudentAsync(int id, StudentUpdateDto student)
    {
        var res = new Student()
        {
            Fullname = student.Fullname,
            Email = student.Email,
            Phone = student.Phone,
            EnrollmentDate = student.EnrollmentDate
        };
        var con = await repository.UpdateStudentAsync(res);
        return con == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Student updated !", con)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Student not updated");
    }

}
