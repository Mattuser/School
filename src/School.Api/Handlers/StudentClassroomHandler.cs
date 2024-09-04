using School.Api.Abstractions;
using School.Api.Dtos.Requests.StudentClassroom;
using School.Api.Dtos.Responses;

namespace School.Api.Handlers;

public class StudentClassroomHandler(IStudentClassroomRepository repository) : IStudentClassroomHandler
{
    public async Task<Response<Dictionary<string, object>>> AssociateAsync(CreateStudentClassroomAssociationRequest request)
    {
        //var association = await AssociationExistsAsync(request.StudentUser, request.Classroom);
        //if (association is true)
        //    return new Response<Dictionary<string, object>>(null, 400, "Aluno já está cadastrado na turma");

        var result = await repository.AssociateAsync(request.StudentUser, request.Classroom);
        
        return new Response<Dictionary<string, object>>(result, 201, "Associação feita com sucesso!");
    }

    public async Task<bool> AssociationExistsAsync(string studentUser, string classroom)
        => await repository.AssociationExists(studentUser, classroom);

}
