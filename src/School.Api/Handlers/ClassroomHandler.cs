using School.Api.Abstractions;
using School.Api.Dtos.Requests.Classroom;
using School.Api.Dtos.Responses;
using School.Api.Entities;

namespace School.Api.Handlers;

public class ClassroomHandler(IClassroomRepository repository) : IClassroomHandler
{
    public async Task<Response<Classroom?>> CreateAsync(CreateClassroomRequest request)
    {
        var classroom = await repository.AnyAsync(request.CourseId);
        if(classroom is not null)
            return new Response<Classroom?>(null, 400, "Turma já cadastrada!");

        classroom = new Classroom
        {
            CourseId = request.CourseId,
            Name = request.Classroom,
        };

        await repository.CreateAsync(classroom);

        return new Response<Classroom?>(classroom, 201, "Cadastro realizado com sucesso!");
    }

    public Task<Response<Classroom?>> UpdateAsync(UpdateClassroomRequest request)
    {
        throw new NotImplementedException();
    }
}
