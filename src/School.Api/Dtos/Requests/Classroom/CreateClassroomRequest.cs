namespace School.Api.Dtos.Requests.Classroom;

public class CreateClassroomRequest : Request
{
    public int CourseId { get; set; }
    public string Classroom { get; set; } = string.Empty;
    public int Year { get; set; }
}
