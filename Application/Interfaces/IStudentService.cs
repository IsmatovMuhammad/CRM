using Domain.Models;

namespace Application.Interfaces;

public interface IStudentService
{
    Task AddStudent(Student student);
    Task UpdateStudent(Student student);
    Task DeleteStudent(int id);
    Task GetStudent(int id);
    Task GetStudents();
    Task GetTotalStudentsCount();
}
