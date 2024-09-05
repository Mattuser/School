using Microsoft.EntityFrameworkCore;
using School.Api.Abstractions;
using School.Api.Data;
using School.Api.Entities;

namespace School.Api.Repositories;

public class StudentClassroomRepository(AppDataContext context) : IStudentClassroomRepository
{
    public async Task<Dictionary<string, object>?> AssociateAsync(int studentId, int classroomId)
    {
        var studentClassroom = new Dictionary<string, object>
        {
            {"aluno_id", studentId},
            {"class_id", classroomId}
        };

        context.Set<Dictionary<string, object>>("aluno_turma").Add(studentClassroom);

        await context.SaveChangesAsync();

        var addedStudentClassroom = await AnyAsync(studentId, classroomId);

        return addedStudentClassroom;
    }

    public bool AssociationExists(int studentId, int classroomId)
    {
        var result = Any(studentId, classroomId);;

        return result is not null;
    }

    public bool AssociationExists(Student student, Classroom classroom)
    {
        var result = Any(student.Id, classroom.Id);

        return result is not null;
    }

    public async Task<bool> AssociationExistsAsync(Student student, Classroom classroom)
        => await AnyAsync(student.Id, classroom.Id) is not null;

    public async Task<bool> AssociationExistsAsync(int studentId, int classroomId)
    => await AnyAsync(studentId, classroomId) is not null;

    public Dictionary<string, object>? Any(int studentId, int classroomId)
     => context.Set<Dictionary<string, object>>("aluno_turma")
         .FirstOrDefault(sc =>
             (int)sc["aluno_id"] == studentId &&
             (int)sc["class_id"] == classroomId);

    public Task<Dictionary<string, object>?> AnyAsync(int studentId, int classroomId)
        => context.Set<Dictionary<string, object>>("aluno_turma")
         .FirstOrDefaultAsync(sc =>
             (int)sc["aluno_id"] == studentId &&
             (int)sc["class_id"] == classroomId);

    public Task<Dictionary<string, object>?> AnyAsync(Student student, Classroom classroom)
        => context.Set<Dictionary<string, object>>("aluno_turma")
         .FirstOrDefaultAsync(sc =>
             (int)sc["aluno_id"] == student.Id &&
             (int)sc["class_id"] == classroom.Id);

    
}
