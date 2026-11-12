namespace Application.DTOs.Mentor;

public class MentorCreateDto
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Specialization { get; set; } = null!;
}
