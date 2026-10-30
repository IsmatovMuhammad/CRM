using Domain.Models;

namespace Application.Interfaces;

public interface IMentorService
{
    Task AddMentor(Mentor mentor);
    Task DeleteMentor(int id);
    Task UpdateMentor(Mentor mentor);
    Task GetMentor(int id);
    Task GetMentor();
    Task GetTotalMentorsCount();
}
