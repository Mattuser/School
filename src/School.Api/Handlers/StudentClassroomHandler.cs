using School.Api.Abstractions;
using School.Api.Dtos.Requests.StudentClassroom;
using School.Api.Dtos.Responses;
using School.Api.Entities;
using School.Api.Models;

namespace School.Api.Handlers;

public class StudentClassroomHandler(
    IStudentClassroomRepository repository,
    IStudentRepository studentRepository,
    IClassroomRepository classroomRepository) : IStudentClassroomHandler
{
    public async Task<Response<StudentClasroom>> AssociateAsync(
        CreateStudentClassroomAssociationRequest request)
    {
        var student = await studentRepository.AnyAsync(request.StudentId);
        var classroom = await classroomRepository.AnyAsync(request.ClassroomId);
        var studentAndClassroomExists = student is not null || classroom is not null;

        if (!studentAndClassroomExists)
            return new Response<StudentClasroom>(null, 400, "Aluno ou turma não cadastrado!");

        bool hasAsssociation = AssociationExistsAsync(student!, classroom!);
        if (hasAsssociation is true)
            return new Response<StudentClasroom>(null, 400, "Aluno já está cadastrado na turma");

        var result = await repository.AssociateAsync(request.StudentId, request.ClassroomId);

        var studentClassroom = new StudentClasroom()
        {
            StudentId = request.StudentId,
            ClassId = request.ClassroomId,
        };
        return new Response<StudentClasroom>(studentClassroom, 201, "Associação feita com sucesso!");
    }

    public bool AssociationExistsAsync(int studentUser, int classroom)
        =>  repository.AssociationExists(studentUser, classroom);
    
    public bool AssociationExistsAsync(Student student, Classroom classroom)
        =>  repository.AssociationExists(student, classroom);

}
