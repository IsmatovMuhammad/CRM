using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentRepository
{
    bool AddStudent(Student student);
    bool UpdateStudent(Student student);
    bool DeleteStudent(int id);
    Student GetStudent(int id);
    List<Student> GetStudents();
    int GetTotalStudentsCount();
    List<StudentGroup> GetStudentsWithGroups();
    List<StudentGroup> GetStudentsWithoutGroups();
}
