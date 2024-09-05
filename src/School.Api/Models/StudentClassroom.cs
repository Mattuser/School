using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Models;

public class StudentClassroom
{
    [Column("aluno_id")]
    public int StudentId { get; set; }
    [Column("class_id")]
    public int ClassroomId { get; set; }
}
