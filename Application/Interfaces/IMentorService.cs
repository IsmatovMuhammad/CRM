using Domain.Models;

namespace Application.Interfaces;

public interface IMentorService
{
    void AddMentor(Mentor mentor);
    void DeleteMentor(int id);
    void UpdateMentor(Mentor mentor);
    void GetMentor(int id);
    void GetMentor();
    void GetTotalMentorsCount();
}
