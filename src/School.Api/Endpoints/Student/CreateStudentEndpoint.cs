using School.Api.Abstractions;
using School.Api.Dtos.Requests.Student;
using School.Api.Dtos.Responses;

namespace School.Api.Endpoints.Student;

public class CreateStudentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/", HandleAsync)
            .WithName("Alunos: Create")
            .WithSummary("Cria um novo aluno")
            .WithDescription("Cria um novo aluno")
            .WithOrder(1)
            .Produces<Response<Entities.Student?>>();
    }

    private static async Task<IResult> HandleAsync(
        IStudentHandler handler,
        CreateStudentRequest request)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
           ?  TypedResults.Created($"/{result.Data?.Id}", result)
           :  TypedResults.BadRequest(result);
    }
}
