using Domain.Models;

namespace Application.Interfaces;

public interface ICourseService
{
    Task AddCourse(Course course);
    Task DeleteCourse(int id);
    Task UpdateCourse(Course course);
    Task GetCourse(int id);
    Task GetCourses();
    Task GetTotalCoursesCount();
}
