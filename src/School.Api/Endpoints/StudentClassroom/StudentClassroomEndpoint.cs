
using Azure;
using School.Api.Abstractions;
using School.Api.Dtos.Requests.Student;
using School.Api.Dtos.Requests.StudentClassroom;

namespace School.Api.Endpoints.StudentClassroom;

public class StudentClassroomEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/", HandleAsync)
            .WithName("Aluno Turma: Create")
            .WithSummary("Associa um aluno à uma turma")
            .WithDescription("Associa um aluno à uma turma")
            .WithOrder(1)
            .Produces<Response<Dictionary<string, object>>>();
    }

    private static async Task<IResult> HandleAsync(
        IStudentClassroomHandler handler,
        CreateStudentClassroomAssociationRequest request)
    {
        var result = await handler.AssociateAsync(request);
        return result.IsSuccess
           ? TypedResults.Created($"/", result)
           : TypedResults.BadRequest(result);
    }
}
