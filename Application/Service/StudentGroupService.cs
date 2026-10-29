using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Service;

public class StudentGroupService(StudentGroupRepository repository) : IStudentGroupService
{
    private StudentGroupRepository studRepo = repository;
    public void AddStudentGroup(StudentGroup studentGroup)
    {
        var group = studRepo.AddStudentGroup(studentGroup);
        if(group) System.Console.WriteLine("Added Successfully !!");
        else System.Console.WriteLine("Sameting wrong !!");
    }

    public void DeleteStudentGroup(int id)
    {
        var group = studRepo.DeleteStudentGroup(id);
        if(group) System.Console.WriteLine("Deleted Successfully !!");
        else System.Console.WriteLine("Sameting wrong !!");
    }

    public void GetAllStartDates()
    {
        var group = studRepo.GetAllStartDates();
        System.Console.WriteLine(group);
    }


    public void GetStudentGroup(int id)
    {
        var s = studRepo.GetStudentGroup(id);
        System.Console.WriteLine(s.StudentGroupId+" | "+s.StudentId+" | "+s.GroupId+" | "+s.Status);
    }

    public void GetStudentGroups()
    {
        var stud = studRepo.GetStudentGroups();
        foreach (var s in stud)
        {
            System.Console.WriteLine(s.StudentGroupId+" | "+s.StudentId+" | "+s.GroupId+" | "+s.Status);
        }
    }

    public void UpdateStudentGroup(StudentGroup studentGroup)
    {
        var group = studRepo.UpdateStudentGroup(studentGroup);
        if(group) System.Console.WriteLine("Updated Successfully !!");
        else System.Console.WriteLine("Sameting wrong !!");
    }

}
