using Application.Interfaces;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Application.Service;

public class StudentService(StudentRepository studentRepository) : IStudentService
{
    private StudentRepository studrepo = studentRepository;
    public async Task AddStudent(Student student)
    {
        var result = await studrepo.AddStudentAsync(student);
        if(result) System.Console.WriteLine("Added successfully !!");
        else System.Console.WriteLine("Someting wrongs !!");
    }

    public async Task DeleteStudent(int id)
    {
        var result = await studrepo.DeleteStudentAsync(id);
        if(result) System.Console.WriteLine("Delete successfully !!");
        else System.Console.WriteLine("Sometings wrongs !!");
    }

    public async Task GetStudent(int id)
    {
        await studrepo.GetStudentAsync(id);
    }

    public async Task GetStudents()
    {
        await studrepo.GetStudentsAsync();
    }

    public async Task GetTotalStudentsCount()
    {
        var count = await studrepo.GetTotalStudentsCountAsync();
        System.Console.WriteLine(count);
    }


    public async Task UpdateStudent(Student student)
    {
        var s = await studrepo.UpdateStudentAsync(student);
        if(s) System.Console.WriteLine("Update Succassfylly !!");
        else System.Console.WriteLine("Someting wrong !!");
    }

}
