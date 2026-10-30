using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Service;

public class CourseService(CourseRepository courserepo) : ICourseService
{
    private CourseRepository course1 = courserepo;
    public async Task AddCourse(Course course)
    {
        var conn = await course1.AddCourseAsync(course);
        if(conn) System.Console.WriteLine("Added successfully !!");
        else System.Console.WriteLine("Sameting wrongs !!");
    }

    public async Task DeleteCourse(int id)
    {
        var conn = await course1.DeleteCourseAsync(id);
        if(conn) System.Console.WriteLine("Deleted Successfully !!");
        else System.Console.WriteLine("Sameting wrongs !!");
    }

    public async Task GetCourse(int id)
    {
        await course1.GetCourseAsync(id);
    }

    public async Task GetCourses()
    {
        await course1.GetCoursesAsync();
    }

    public async Task GetTotalCoursesCount()
    {
        await course1.GetTotalCoursesCountAsync();
    }


    public async Task UpdateCourse(Course course)
    {
        var conn = await course1.UpdateCourseAsync(course);
        if(conn) System.Console.WriteLine("Update Successfully !!");
        else System.Console.WriteLine("Sameting wrongs !!");
    }

}
