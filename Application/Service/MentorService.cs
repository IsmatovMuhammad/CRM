using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Service;

public class MentorService(MentorRepository repository) : IMentorService
{
    private MentorRepository mentorRepo = repository;
    public async Task AddMentor(Mentor mentor)
    {
        var mento = await mentorRepo.AddMentor(mentor);
        if(mento) System.Console.WriteLine("Added succesfully !!");
        else System.Console.WriteLine("Sametings wrong !!");
    }

    public async Task DeleteMentor(int id)
    {
        var mento = await mentorRepo.DeleteMentor(id);
        if(mento) System.Console.WriteLine("Deleted succesfully !!");
        else System.Console.WriteLine("Sametings wrong !!");
    }

    public async Task GetMentor(int id)
    {
        await mentorRepo.GetMentor(id);
    }

    public async Task GetMentor()
    {
        await mentorRepo.GetMentors();
    }

    public async Task GetTotalMentorsCount()
    {
        await mentorRepo.GetTotalMentorsCount();
    }   


    public async Task UpdateMentor(Mentor mentor)
    {
        var mento = await mentorRepo.UpdateMentor(mentor);
        if(mento) System.Console.WriteLine("Updated succesfully !!");
        else System.Console.WriteLine("Sametings wrong !!");
    }

}
