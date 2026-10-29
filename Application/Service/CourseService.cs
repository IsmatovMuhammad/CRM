using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Service;

public class CourseService(CourseRepository courserepo) : ICourseService
{
    private CourseRepository course1 = courserepo;
    public void AddCourse(Course course)
    {
        var conn = course1.AddCourse(course);
        if(conn) System.Console.WriteLine("Added successfully !!");
        else System.Console.WriteLine("Sameting wrongs !!");
    }

    public void DeleteCourse(int id)
    {
        var conn = course1.DeleteCourse(id);
        if(conn) System.Console.WriteLine("Deleted Successfully !!");
        else System.Console.WriteLine("Sameting wrongs !!");
    }

    public void GetCourse(int id)
    {
        var conn = course1.GetCourse(id);
        System.Console.WriteLine(conn.CourseId+" | "+conn.Title+" | "+conn.Description+" | "+conn.DurationWeeks);
    }

    public void GetCourses()
    {
        var conn = course1.GetCourses();
        foreach (var i in conn)
        {
            System.Console.WriteLine(i.CourseId+" | "+i.Title+" | "+i.Description+" | "+i.DurationWeeks);
        }
    }

    public void GetTotalCoursesCount()
    {
        var count = course1.GetTotalCoursesCount();
        System.Console.WriteLine(count);
    }


    public void UpdateCourse(Course course)
    {
        var conn = course1.UpdateCourse(course);
        if(conn) System.Console.WriteLine("Update Successfully !!");
        else System.Console.WriteLine("Sameting wrongs !!");
    }

}
