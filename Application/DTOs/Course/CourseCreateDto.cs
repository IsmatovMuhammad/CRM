namespace Application.DTOs.Course;

public class CourseCreateDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int DurationWeeks { get; set; }
}
