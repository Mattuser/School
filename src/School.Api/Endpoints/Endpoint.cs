using School.Api.Endpoints.Clasroom;
using School.Api.Endpoints.Student;

namespace School.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("")
                .MapGet("/", () => new { message = "Ok" })
                .WithTags("Health Check");

        endpoints.MapGroup("v1/Alunos")
            .WithTags("Alunos")
            .MapEndpoint<CreateStudentEndpoint>()
            .MapEndpoint<UpdateStudentEndpoint>();

        endpoints.MapGroup("v1/Turmas")
            .WithTags("Turmas")
            .MapEndpoint<CreateClassroomEndpoint>();
    }

    public static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
