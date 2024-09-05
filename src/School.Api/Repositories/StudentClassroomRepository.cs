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
        => Any(studentId, classroomId) is not null;


    public bool AssociationExists(Student student, Classroom classroom)
        => Any(student.Id, classroom.Id) is not null;

    public async Task<bool> AssociationExistsAsync(Student student, Classroom classroom)
        => await AnyAsync(student.Id, classroom.Id) is not null;

    public async Task<bool> AssociationExistsAsync(int studentId, int classroomId)
    => await AnyAsync(studentId, classroomId) is not null;


    public Dictionary<string, object>? Any(int studentId, int classroomId)
     => AnyByEntities(studentId, classroomId)
           .FirstOrDefault();

    public Task<Dictionary<string, object>?> AnyAsync(int studentId, int classroomId)
        => AnyByEntities(studentId, classroomId)
           .FirstOrDefaultAsync();

    public Task<Dictionary<string, object>?> AnyAsync(Student student, Classroom classroom)
        => AnyByEntities(student.Id, classroom.Id)
           .FirstOrDefaultAsync();

    private IQueryable<Dictionary<string, object>> AnyByEntities(int studentId, int classroomId)
        => context.Set<Dictionary<string, object>>("aluno_turma")
            .Where(sc =>
             (int)sc["aluno_id"] == studentId &&
             (int)sc["class_id"] == classroomId);
    
}
