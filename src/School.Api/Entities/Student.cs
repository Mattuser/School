namespace School.Api.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public ICollection<Classroom> Classes { get; set; } = new List<Classroom>();
}
