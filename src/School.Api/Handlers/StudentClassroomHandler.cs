using School.Api.Abstractions;
using School.Api.Dtos.Requests.StudentClassroom;
using School.Api.Dtos.Responses;
using School.Api.Entities;

namespace School.Api.Handlers;

public class StudentClassroomHandler(
    IStudentClassroomRepository repository,
    IStudentRepository studentRepository,
    IClassroomRepository classroomRepository) : IStudentClassroomHandler
{
    public async Task<Response<Dictionary<string, object>>> AssociateAsync(CreateStudentClassroomAssociationRequest request)
    {
        bool hasAsssociation = false;
        var student = await studentRepository.AnyAsync(request.StudentId);
        var classroom = await classroomRepository.AnyAsync(request.StudentId);
        var studentAndClassroomExists = student is not null && classroom is not null;

        if (!studentAndClassroomExists)
            return new Response<Dictionary<string, object>>(null, 400, "Aluno ou turma não cadastrado!");

        hasAsssociation = AssociationExistsAsync(student!, classroom!);
        if (hasAsssociation is true)
            return new Response<Dictionary<string, object>>(null, 400, "Aluno já está cadastrado na turma");

        var result = await repository.AssociateAsync(request.StudentId, request.ClassroomId);
        
        return new Response<Dictionary<string, object>>(result, 201, "Associação feita com sucesso!");
    }

    public bool AssociationExistsAsync(int studentUser, int classroom)
        =>  repository.AssociationExists(studentUser, classroom);
    
    public bool AssociationExistsAsync(Student student, Classroom classroom)
        =>  repository.AssociationExists(student, classroom);

}
