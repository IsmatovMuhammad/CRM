using System.Net;
using Domain.Models;

namespace Domain.Interfaces;

public interface IMentorRepository
{
    Task<bool> AddMentor(Mentor mentor);
    Task<bool> DeleteMentor(int id);
    Task<bool> UpdateMentor(Mentor mentor);
    Task<Mentor> GetMentor(int id);
    Task<List<Mentor>> GetMentors();
    Task<int> GetTotalMentorsCount();
}
