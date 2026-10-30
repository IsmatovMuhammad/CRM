using Domain.Models;

namespace Domain.Interfaces;

public interface ICourseRepository
{
    Task<bool> AddCourseAsync(Course course);
    Task<bool> DeleteCourseAsync(int id);
    Task<bool> UpdateCourseAsync(Course course);
    Task<Course> GetCourseAsync(int id);
    Task<List<Course>> GetCoursesAsync();
    Task<int> GetTotalCoursesCountAsync();
}