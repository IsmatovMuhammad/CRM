using Domain.Models;

namespace Application.Interfaces;

public interface ICourseService
{
    void AddCourse(Course course);
    void DeleteCourse(int id);
    void UpdateCourse(Course course);
    void GetCourse(int id);
    void GetCourses();
    void GetTotalCoursesCount();
}
