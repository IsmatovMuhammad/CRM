using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentRepository
{
    Task<bool> AddStudentAsync(Student student);
    Task<bool> UpdateStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(int id);
    Task<Student> GetStudentAsync(int id);
    Task<List<Student>> GetStudentsAsync();
    Task<int> GetTotalStudentsCountAsync();
    Task<List<StudentGroup>> GetStudentsWithGroupsAsync();
    Task<List<StudentGroup>> GetStudentsWithoutGroupsAsync();
}
