using Domain.Enum;

namespace Application.DTOs.StudentGroup;

public class StudentGroupResponseDto
{
    public int StudentGroupId { get; set; }
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public StudentGroupStatus Status { get; set; }
}
