using School.Api.Abstractions;
using School.Api.Data;
using School.Api.Entities;

namespace School.Api.Repositories;

public class StudentClassroomRepository(
    IStudentRepository studentRepository,
    IClassroomRepository classroomRepository,
    AppDataContext context) : IStudentClassroomRepository
{
    public async Task<Dictionary<string, object>> AssociateAsync(string user, string classroom)
    {
        var student = await studentRepository.AnyAsync(user);
        var classroomEntity = await classroomRepository.AnyAsync(classroom);
        var studentClassroom = new Dictionary<string, object>
        {
            {"aluno_id", student.Id},
            {"turma_id", classroomEntity.Id}
        };

        
        context.Set<Dictionary<string, object>>("aluno_turma").Add(studentClassroom);

        await context.SaveChangesAsync();
    }

    public Task<bool> AssociationExists(string user, string classroom)
    {
        throw new NotImplementedException();
    }
}
