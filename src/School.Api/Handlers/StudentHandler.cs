using School.Api.Abstractions;
using School.Api.Data;
using School.Api.Dtos.Requests.Student;
using School.Api.Dtos.Responses;
using School.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace School.Api.Handlers;

public class StudentHandler(AppDataContext context) : IStudentHandler
{
    public async Task<Response<Student?>> CreateAsync(CreateStudentRequest request)
    {
 
        try
        {
            var student = await context.Students.FirstOrDefaultAsync(x => x.User == request.User);
            if (student is not null)
                return new Response<Student?>(null, 400, "Aluno já cadastrado!");

            student = new Student
            {
                User = request.User,
                Name = request.Name,
                Password = request.Password,
            };

            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();

            return new Response<Student?>(student, 201, "Cadastro realizado com sucesso!");
        }
        catch
        {
            return new Response<Student?>(null, 500, "Não foi possível cadastrar o aluno");
        }


    }

    public async Task<Response<Student?>> UpdateAsync(UpdateStudentRequest request)
    {
        try
        {
            var student = await context.Students.FirstOrDefaultAsync(x => x.User == request.User);
            if (student is null)
                return new Response<Student?>(null, 400, "Aluno não cadastrado!");

            student.Name = request.Name;
            student.Password = request.Password;

            context.Students.Update(student);
            await context.SaveChangesAsync();

            return new Response<Student?>(student, message: "Aluno atualizado com sucesso!");
        }
        catch
        {
            return new Response<Student?>(null, 500, "Não foi possível atualizar o aluno");
        }


    }
}
