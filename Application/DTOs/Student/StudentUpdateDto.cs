namespace Application.DTOs.Student;

public class StudentUpdateDto
{
    public string Fullname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateOnly EnrollmentDate { get; set; }
}
