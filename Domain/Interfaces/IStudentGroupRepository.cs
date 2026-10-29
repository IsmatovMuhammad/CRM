using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentGroupRepository
{
    bool AddStudentGroup(StudentGroup studentGroup);
    bool DeleteStudentGroup(int id);
    bool UpdateStudentGroup(StudentGroup studentGroup);
    StudentGroup GetStudentGroup(int id);
    List<StudentGroup> GetStudentGroups();
    int GetAllStartDates();
}
