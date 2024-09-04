using School.Api.Abstractions;
using School.Api.Data;
using School.Api.Handlers;
using Microsoft.EntityFrameworkCore;
using School.Api.Repositories;

namespace School.Api.Extensions;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
       builder.Services.AddEndpointsApiExplorer();
       builder.Services.AddSwaggerGen(x =>
       {
           x.CustomSchemaIds(n => n.FullName);
       });
    }

    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDataContext>(options =>
        {
            options.UseSqlServer(Configuration.ConnectionString);
        });
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IStudentHandler, StudentHandler>();
        builder.Services.AddTransient<IStudentRepository, StudentRepository>();
        
        builder.Services.AddTransient<IClassroomHandler, ClassroomHandler>();
        builder.Services.AddTransient<IClassroomRepository, ClassroomRepository>();

        builder.Services.AddTransient<IStudentClassroomHandler, StudentClassroomHandler>();
        builder.Services.AddTransient<IStudentClassroomRepository, StudentClassroomRepository>();
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddCors();
    }
}
