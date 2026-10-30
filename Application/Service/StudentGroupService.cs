using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Service;

public class StudentGroupService(StudentGroupRepository repository) : IStudentGroupService
{
    private StudentGroupRepository studRepo = repository;
    public async Task AddStudentGroup(StudentGroup studentGroup)
    {
        var group = await studRepo.AddStudentGroup(studentGroup);
        if(group) System.Console.WriteLine("Added Successfully !!");
        else System.Console.WriteLine("Sameting wrong !!");
    }

    public async Task DeleteStudentGroup(int id)
    {
        var group = await studRepo.DeleteStudentGroup(id);
        if(group) System.Console.WriteLine("Deleted Successfully !!");
        else System.Console.WriteLine("Sameting wrong !!");
    }

    public async Task GetAllStartDates()
    {
        await studRepo.GetAllStartDates();
    }


    public async Task GetStudentGroup(int id)
    {
        await studRepo.GetStudentGroup(id);
    }

    public async Task GetStudentGroups()
    {
        await studRepo.GetStudentGroups();
    }

    public async Task UpdateStudentGroup(StudentGroup studentGroup)
    {
        var group = await studRepo.UpdateStudentGroup(studentGroup);
        if(group) System.Console.WriteLine("Updated Successfully !!");
        else System.Console.WriteLine("Sameting wrong !!");
    }

}
