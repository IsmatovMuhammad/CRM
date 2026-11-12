using System.Net;
using Application.DTOs.StudentGroup;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Service;

public class StudentGroupService(IStudentGroupRepository repository1) : IStudentGroupService
{
    private IStudentGroupRepository repository = repository1;

    public async Task<ApiResponse<bool>> AddStudentGroup(StudentGroupCreateDto studentGroup)
    {
        var res = new StudentGroup()
        {
            StudentId = studentGroup.StudentId,
            GroupId = studentGroup.GroupId,
            Status = studentGroup.Status
        };
        var con = await repository.AddStudentGroup(res);
        return con == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "StudentGroup added !", con)
        : new ApiResponse<bool>(HttpStatusCode.OK, "StudentGroup not added !");
    }

    public async Task<ApiResponse<bool>> DeleteStudentGroup(int id)
    {
        var con = await repository.DeleteStudentGroup(id);
        return con == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "StudentGroup deleted !", con)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "StudentGroup not deleted !");
    }

    public async Task<ApiResponse<int>> GetAllStartDates()
    {
        var con = await repository.GetAllStartDates();
        return new ApiResponse<int>(HttpStatusCode.OK, "All start dates !", con);
    }

    public async Task<ApiResponse<StudentGroupResponseDto>> GetStudentGroup(int id)
    {
        var con = await repository.GetStudentGroup(id);
        var res = new StudentGroupResponseDto
        {
            StudentGroupId = con.StudentGroupId,
            StudentId = con.StudentId,
            GroupId = con.GroupId,
            Status = con.Status
        };
        return new ApiResponse<StudentGroupResponseDto>(HttpStatusCode.OK, "StudentGroup by id. ", res);
    }

    public async Task<ApiResponse<List<StudentGroupResponseDto>>> GetStudentGroups()
    {
        var con = await repository.GetStudentGroups();
        var res = con.Select(s => new StudentGroupResponseDto
        {
            StudentGroupId = s.StudentGroupId,
            StudentId = s.StudentId,
            GroupId = s.GroupId,
            Status = s.Status
        }).ToList();
        return new ApiResponse<List<StudentGroupResponseDto>>(HttpStatusCode.OK, "List of group. ", res);
    }

    public async Task<ApiResponse<bool>> UpdateStudentGroup(int id, StudentGroupUpdateDto studentGroup)
    {
        var res = new StudentGroup()
        {
            StudentId = studentGroup.StudentId,
            GroupId = studentGroup.GroupId,
            Status = studentGroup.Status
        };
        var con = await repository.AddStudentGroup(res);
        return con == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "StudentGroup updated !", con)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "StudentGroup not updated !");
    }
}
