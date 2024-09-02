using School.Api.Abstractions;
using School.Api.Dtos.Requests.Student;
using School.Api.Dtos.Responses;
using School.Api.Entities;

namespace School.Api.Handlers;

public class StudentHandler(IStudentRepository repository) : IStudentHandler
{
    public async Task<Response<Student?>> CreateAsync(CreateStudentRequest request)
    {
        try
        {
            var student = await repository.AnyAsync(request.User);
            if (student is not null)
                return new Response<Student?>(null, 400, "Aluno já cadastrado!");

            student = new Student
            {
                User = request.User,
                Name = request.Name,
                Password = request.Password,
            };

            await repository.CreateAsync(student);

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
            var student = await repository.AnyAsync(request.User);
            if (student is null)
                return new Response<Student?>(null, 400, "Aluno não cadastrado!");

            student.Name = request.Name;
            student.Password = request.Password;

            await repository.UpdateAsync(student);

            return new Response<Student?>(student, message: "Aluno atualizado com sucesso!");
        }
        catch
        {
            return new Response<Student?>(null, 500, "Não foi possível atualizar o aluno");
        }


    }
}
