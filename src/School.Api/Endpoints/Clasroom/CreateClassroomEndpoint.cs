
using School.Api.Abstractions;
using School.Api.Dtos.Requests.Classroom;
using School.Api.Dtos.Responses;

namespace School.Api.Endpoints.Clasroom;

public class CreateClassroomEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/", HandleAsync)
            .WithName("Turma: Create")
            .WithSummary("Cria uma nova turma")
            .WithDescription("Cria uma nova turma")
            .WithOrder(1)
            .Produces<Response<Entities.Classroom?>>();

    }

    private static async Task<IResult> HandleAsync(
        IClassroomHandler handler,
        CreateClassroomRequest request)
    {
        var result = await handler.CreateAsync(request);
         
        return result.IsSuccess
            ? Results.Created($"/{result.Data?.Id}", result)
            : Results.BadRequest(result);

    }
}
