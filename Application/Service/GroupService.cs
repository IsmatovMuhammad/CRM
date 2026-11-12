using System.Net;
using System.Text.RegularExpressions;
using Application.DTOs.Group;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;


namespace Application.Service;

public class GroupService(IGroupRepository repository1) : IGroupService
{
    private IGroupRepository repository = repository1;

    public async Task<ApiResponse<bool>> AddGroupAsync(GroupCreateDto group)
    {
        var gr = new Groups()
        {
            GroupName = group.GroupName,
            CourseId = group.CourseId,
            MentorId = group.MentorId,
            StartDate = group.StartDate,
            EndDate = group.EndDate
        };
        var res = await repository.AddGroupAsync(gr);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Group added !")
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Group not added !");
    }

    public async Task<ApiResponse<bool>> DeleteGroupAsync(int id)
    {
        var con = await repository.DeleteGroupAsync(id);
        return con == true 
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Group deleted !", con)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Group not deleted !");
    }

    public async Task<ApiResponse<int>> GetEmptyGroups()
    {
        var con = await repository.GetEmptyGroups();
        return new ApiResponse<int>(HttpStatusCode.OK, "Empty group !", con);
    }

    public async Task<ApiResponse<GroupResponseDto>> GetGroup(int id)
    {
        var gt = await repository.GetGroup(id);
        var group = new Groups()
        {
            GroupsId = gt.GroupsId,
            GroupName = gt.GroupName,
            CourseId = gt.CourseId,
            MentorId = gt.MentorId,
            StartDate = gt.StartDate,
            EndDate = gt.EndDate
        };
        return new ApiResponse<GroupResponseDto>(HttpStatusCode.OK, "Group by id. ", group);
    }

    public async Task<ApiResponse<List<GroupResponseDto>>> GetGroups()
    {
        var con = await repository.GetGroups();
        var group = con.Select(s => new GroupResponseDto
        {
            GroupId = s.GroupsId,
            GroupName = s.GroupName,
            CourseId = s.CourseId,
            MentorId = s.MentorId,
            StartDate = s.StartDate,
            EndDate = s.EndDate
        }).ToList();
        return new ApiResponse<List<GroupResponseDto>>(HttpStatusCode.OK, "List of Group. ", group);
    }

    public async Task<ApiResponse<int>> GetStudentsPerGroup()
    {
        var con = await repository.GetStudentsPerGroup();
        return new ApiResponse<int>(HttpStatusCode.OK, "Students group", con);
    }

    public async Task<ApiResponse<bool>> UpdateGroupAsync(int id, GroupUpdateDto group)
    {
        var gr = new Groups()
        {
            GroupsId = id,
            GroupName = group.GroupName,
            CourseId = group.CourseId,
            MentorId = group.MentorId,
            StartDate = group.StartDate,
            EndDate = group.EndDate
        };
        var con = await repository.UpdateGroupAsync(gr);
        return con == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Group updated !", con)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Group not updated !");
    }
}
