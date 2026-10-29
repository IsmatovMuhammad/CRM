using Domain.Models;

namespace Application.Interfaces;

public interface IStudentService
{
    void AddStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(int id);
    void GetStudent(int id);
    void GetStudents();
    void GetTotalStudentsCount();
}
