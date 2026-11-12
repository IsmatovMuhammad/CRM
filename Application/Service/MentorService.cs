using System.Net;
using System.Reflection;
using Application.DTOs.Mentor;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Service;

public class MentorService(IMentorRepository repository) : IMentorService
{
    private IMentorRepository service = repository;

    public async Task<ApiResponse<bool>> AddMentor(MentorCreateDto mentor)
    {
        var men = new Mentor()
        {
            FullName = mentor.FullName,
            Email = mentor.Email,
            Phone = mentor.Phone,
            Specialization = mentor.Specialization
        };
        var con = await service.AddMentor(men);
        return con == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Mentor added !", con)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Mentor not added !");
    }

    public async Task<ApiResponse<bool>> DeleteMentor(int id)
    {
        var con = await service.DeleteMentor(id);
        return con == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Mentor deleted !", con)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Mentor not deleted !");
    }

    public async Task<ApiResponse<MentorResponseDto>> GetMentor(int id)
    {
        var con = await service.GetMentor(id);
        var men = new MentorResponseDto
        {
            MentorId = con.MentorId,
            FullName = con.FullName,
            Email = con.Email,
            Phone = con.Phone,
            Specialization = con.Specialization
        };
        return new ApiResponse<MentorResponseDto>(HttpStatusCode.OK, "Mentor by id. ", men);
    }

    public async Task<ApiResponse<List<MentorResponseDto>>> GetMentors()
    {
        var con = await service.GetMentors();
        var men = con.Select(s => new MentorResponseDto
        {
            MentorId = s.MentorId,
            FullName = s.FullName,
            Email = s.Email,
            Phone = s.Phone,
            Specialization = s.Specialization
            
        }).ToList();
        return new ApiResponse<List<MentorResponseDto>>(HttpStatusCode.OK, "List of Metor", men);
    }

    public async Task<ApiResponse<List<MentorResponseDto>>> GetMentorsWithMultipleCourses()
    {
        var con = await service.GetMentorsWithMultipleCourses();
        var men = con.Select(s => new MentorResponseDto
        {
            MentorId = s.MentorId,
            FullName = s.FullName,
            Email = s.Email,
            Phone = s.Phone,
            Specialization = s.Specialization
            
        }).ToList();
        return new ApiResponse<List<MentorResponseDto>>(HttpStatusCode.OK, " Mentir with multiple course. ", men);
    }

    public async Task<ApiResponse<MentorResponseDto>> GetMentorWithMostStudents()
    {
        var con = await service.GetMentorWithMostStudents();
        var men = new MentorResponseDto
        {
            MentorId = con.MentorId,
            FullName = con.FullName,
            Email = con.Email,
            Phone = con.Phone,
            Specialization = con.Specialization
        };
        return new ApiResponse<MentorResponseDto>(HttpStatusCode.OK, "Mentor with Most Student", men);
    }

    public async Task<ApiResponse<int>> GetTotalMentorsCount()
    {
        var con = await service.GetTotalMentorsCount();
        return new ApiResponse<int>(HttpStatusCode.OK, "Total Mentor Count. ", con);
    }

    public async Task<ApiResponse<bool>> UpdateMentor(int id, MentorUpdateDto mentor)
    {
        var men = new Mentor()
        {
            MentorId = id,
            FullName = mentor.FullName,
            Email = mentor.Email,
            Phone = mentor.Phone,
            Specialization = mentor.Specialization
        };
        var con = await service.UpdateMentor(men);
        return con == true 
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated mentor !", con)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Mentor not updated");
    }

}
