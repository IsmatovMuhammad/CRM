using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Service;

public class MentorService(MentorRepository repository) : IMentorService
{
    private MentorRepository mentorRepo = repository;
    public void AddMentor(Mentor mentor)
    {
        var mento = mentorRepo.AddMentor(mentor);
        if(mento) System.Console.WriteLine("Added succesfully !!");
        else System.Console.WriteLine("Sametings wrong !!");
    }

    public void DeleteMentor(int id)
    {
        var mento = mentorRepo.DeleteMentor(id);
        if(mento) System.Console.WriteLine("Deleted succesfully !!");
        else System.Console.WriteLine("Sametings wrong !!");
    }

    public void GetMentor(int id)
    {
        var m = mentorRepo.GetMentor(id);
        System.Console.WriteLine(m.MentorId+" | "+m.FullName+" | "+m.Email+" | "+m.Phone+" | "+m.Specialization);
    }

    public void GetMentor()
    {
        var mento = mentorRepo.GetMentors();
        foreach (var m in mento)
        {
            System.Console.WriteLine(m.MentorId+" | "+m.FullName+" | "+m.Email+" | "+m.Phone+" | "+m.Specialization);
        }
    }

    public void GetTotalMentorsCount()
    {
        var mento = mentorRepo.GetTotalMentorsCount();
        System.Console.WriteLine(mento);
    }   


    public void UpdateMentor(Mentor mentor)
    {
        var mento = mentorRepo.UpdateMentor(mentor);
        if(mento) System.Console.WriteLine("Updated succesfully !!");
        else System.Console.WriteLine("Sametings wrong !!");
    }

}
