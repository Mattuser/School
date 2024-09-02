using Desafio_Fiap.Api.Abstractions;
using Desafio_Fiap.Api.Dtos.Requests.Student;
using Desafio_Fiap.Api.Dtos.Responses;

namespace Desafio_Fiap.Api.Endpoints.Student;

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
