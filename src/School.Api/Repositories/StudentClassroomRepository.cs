using Microsoft.EntityFrameworkCore;
using School.Api.Abstractions;
using School.Api.Data;
using School.Api.Entities;

namespace School.Api.Repositories;

public class StudentClassroomRepository(
    IStudentRepository studentRepository,
    IClassroomRepository classroomRepository,
    AppDataContext context) : IStudentClassroomRepository
{
    public async Task<Dictionary<string, object>> AssociateAsync(int studentId, int classroomId)
    {
        var student = await studentRepository.AnyAsync(studentId);
        var classroomEntity = await classroomRepository.AnyAsync(classroomId);
        var studentClassroom = new Dictionary<string, object>
        {
            {"aluno_id", student.Id},
            {"class_id", classroomEntity.Id}
        };

       context.Set<Dictionary<string, object>>("aluno_turma").Add(studentClassroom);
        
        var addedUserRole = context.Set<Dictionary<string, object>>("aluno_turma")
                                   .FirstOrDefault(sc =>
                                       (int)sc["aluno_id"] == student.Id &&
                                       (int)sc["class_id"] == classroomEntity.Id);

        await context.SaveChangesAsync();

        return addedUserRole;
    }

    public bool AssociationExists(int studentId, int classroomId)
    {
        var result = context.Set<Dictionary<string, object>>("aluno_turma")
            .FirstOrDefault(sc =>
                (int)sc["aluno_id"] == studentId &&
                (int)sc["class_id"] == classroomId);
          

        return result is not null;
    }

    public bool AssociationExists(Student student, Classroom classroom)
    {
        var result = context.Set<Dictionary<string, object>>("aluno_turma")
              .FirstOrDefault(sc =>
                  (int)sc["aluno_id"] == student.Id &&
                  (int)sc["class_id"] == classroom.Id);
                

        return result is not null;
    }
}
