using Domain.Models;

namespace Application.Interfaces;

public interface IStudentGroupService
{
    void AddStudentGroup(StudentGroup studentGroup);
    void DeleteStudentGroup(int id);
    void UpdateStudentGroup(StudentGroup studentGroup);
    void GetStudentGroup(int id);
    void GetStudentGroups();
    void GetAllStartDates();
}
