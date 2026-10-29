using Domain.Models;

namespace Domain.Interfaces;

public interface ICourseRepository
{
    bool AddCourse(Course course);
    bool DeleteCourse(int id);
    bool UpdateCourse(Course course);
    Course GetCourse(int id);
    List<Course> GetCourses();
    int GetTotalCoursesCount();
}