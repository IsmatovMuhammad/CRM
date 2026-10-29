using System.Net;
using Domain.Models;

namespace Domain.Interfaces;

public interface IMentorRepository
{
    bool AddMentor(Mentor mentor);
    bool DeleteMentor(int id);
    bool UpdateMentor(Mentor mentor);
    Mentor GetMentor(int id);
    List<Mentor> GetMentors();
    int GetTotalMentorsCount();
}
