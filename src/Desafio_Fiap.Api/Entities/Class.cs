namespace Desafio_Fiap.Api.Entities;

public class Class
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
}
