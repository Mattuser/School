namespace School.Api.Dtos.Requests.Student;

public class CreateStudentRequest : Request
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
