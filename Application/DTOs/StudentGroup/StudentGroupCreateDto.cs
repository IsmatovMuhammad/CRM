using Domain.Enum;

namespace Application.DTOs.StudentGroup;

public class StudentGroupCreateDto
{
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public StudentGroupStatus Status { get; set; }
}
