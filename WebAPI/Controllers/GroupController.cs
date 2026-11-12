using System.Text.RegularExpressions;
using Application.DTOs.Group;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GroupController(
    IGroupService groupService,
    ILogger<GroupController> logger
    ) : ControllerBase
{
    private IGroupService service = groupService;
    private ILogger<GroupController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<GroupResponseDto>>> GetGroups()
    {
        _logger.LogInformation("List of Group {Time}", DateTime.Now);
        return await service.GetGroups();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGroup(GroupCreateDto group)
    {
        _logger.LogInformation("Group added {Time}", DateTime.Now);
        return await service.AddGroupAsync(group);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGroup(int id)
    {
        _logger.LogInformation("Group deleted {Time}", DateTime.Now);
        return await service.DeleteGroupAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateGroup(int id, GroupUpdateDto group)
    {
        _logger.LogInformation("Group updated {Time}", DateTime.Now);
        return await service.UpdateGroupAsync(id, group);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GroupResponseDto>> GetGroup(int id)
    {
        _logger.LogInformation("Group by id {Time}", DateTime.Now);
        return await service.GetGroup(id);
    }

    [HttpGet("student-per-group")]
    public async Task<ApiResponse<int>> GetStudentsPerGroup()
    {
        _logger.LogInformation("Student per Group {Time}", DateTime.Now);
        return await service.GetStudentsPerGroup();
    }

    [HttpGet("empty-group")]
    public async Task<ApiResponse<int>> GetEmptyGroups()
    {
        _logger.LogInformation("Get empty group {Time}", DateTime.Now);
        return await service.GetEmptyGroups();
    }
}
