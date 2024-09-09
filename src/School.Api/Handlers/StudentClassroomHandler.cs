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
    public async Task<Response<StudentClassroom>> AssociateAsync(
        CreateStudentClassroomAssociationRequest request)
    {
        var student = await studentRepository.AnyAsync(request.StudentId);
        var classroom = await classroomRepository.AnyAsync(request.ClassroomId);

        var verifyAssociation = await VerifyAssociation(student, classroom);
        if (verifyAssociation is not null)
            return verifyAssociation;

         var result = await repository.AssociateAsync(request.StudentId, request.ClassroomId)!;

        var studentClassroom = new StudentClassroom()
        {
            StudentId = (int)result["aluno_id"],
            ClassId = (int)result["class_id"],
        };
        return new Response<StudentClassroom>(studentClassroom, 201, "Associação feita com sucesso!");
    }

    private async Task<Response<StudentClassroom>?> VerifyAssociation(
        Student? student, 
        Classroom? classroom)
    {
        var studentAndClassroomExists = student is not null || classroom is not null;

        if (!studentAndClassroomExists)
            return new Response<StudentClassroom>(null, 400, "Aluno ou turma não cadastrado!");

        bool hasAsssociation = await AssociationExistsAsync(student!, classroom!);
        if (hasAsssociation is true)
            return new Response<StudentClassroom>(null, 400, "Aluno já está cadastrado na turma");

        return null;
       
    }

    public async Task<bool> AssociationExistsAsync(int studentUser, int classroom)
        =>  await repository.AssociationExistsAsync(studentUser, classroom);
    
    public async Task<bool> AssociationExistsAsync(Student student, Classroom classroom)
        =>  await repository.AssociationExistsAsync(student, classroom);

}
