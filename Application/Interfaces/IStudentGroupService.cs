using Domain.Models;

namespace Application.Interfaces;

public interface IStudentGroupService
{
    Task AddStudentGroup(StudentGroup studentGroup);
    Task DeleteStudentGroup(int id);
    Task UpdateStudentGroup(StudentGroup studentGroup);
    Task GetStudentGroup(int id);
    Task GetStudentGroups();
    Task GetAllStartDates();
}
