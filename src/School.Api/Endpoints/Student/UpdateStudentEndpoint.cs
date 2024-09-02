using School.Api.Abstractions;
using School.Api.Dtos.Requests.Student;
using School.Api.Dtos.Responses;

namespace School.Api.Endpoints.Student;

public class UpdateStudentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPut("/", HandleAsync)
            .WithName("Alunos: Update")
            .WithSummary("Atualiza um aluno")
            .WithDescription("Atualiza um aluno")
            .WithOrder(1)
            .Produces<Response<Entities.Student?>>();
    }

    private static async Task<IResult> HandleAsync(
        IStudentHandler handler,
        UpdateStudentRequest request)
    {
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
           ?  TypedResults.Ok(result)
           :  TypedResults.BadRequest(result);
    }
}
