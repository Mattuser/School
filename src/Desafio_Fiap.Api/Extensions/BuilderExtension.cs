using Desafio_Fiap.Api.Abstractions;
using Desafio_Fiap.Api.Data;
using Desafio_Fiap.Api.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Fiap.Api.Extensions;

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
    }
}
