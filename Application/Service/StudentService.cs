using Application.Interfaces;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Application.Service;

public class StudentService(StudentRepository studentRepository) : IStudentService
{
    private StudentRepository studrepo = studentRepository;
    public void AddStudent(Student student)
    {
        var result = studrepo.AddStudent(student);
        if(result) System.Console.WriteLine("Added successfully !!");
        else System.Console.WriteLine("Someting wrongs !!");
    }

    public void DeleteStudent(int id)
    {
        var result = studrepo.DeleteStudent(id);
        if(result) System.Console.WriteLine("Delete successfully !!");
        else System.Console.WriteLine("Sometings wrongs !!");
    }

    public void GetStudent(int id)
    {
        var s = studrepo.GetStudent(id);
        System.Console.WriteLine(s.StudentId+" | "+s.Fullname+" | "+s.Email+" | "+s.EnrollmentDate);
    }

    public void GetStudents()
    {
        var s = studrepo.GetStudents();
        foreach (var i in s)
        {
            System.Console.WriteLine(i.StudentId+" | "+i.Fullname+" | "+i.Email+" | "+i.EnrollmentDate);
        }
    }

    public void GetTotalStudentsCount()
    {
        var count = studrepo.GetTotalStudentsCount();
        System.Console.WriteLine(count);
    }


    public void UpdateStudent(Student student)
    {
        var s = studrepo.UpdateStudent(student);
        if(s) System.Console.WriteLine("Update Succassfylly !!");
        else System.Console.WriteLine("Someting wrong !!");
    }

}
