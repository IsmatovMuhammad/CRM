using Domain.Enum;

namespace Application.DTOs.StudentGroup;

public class StudentGroupUpdateDto
{
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public StudentGroupStatus Status { get; set; }
}
