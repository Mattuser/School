using School.Api.Dtos.Requests.Classroom;
using School.Api.Dtos.Requests.Student;
using School.Api.Dtos.Responses;
using School.Api.Entities;

namespace School.Api.Abstractions;

public interface IClassroomHandler
{
    Task<Response<Classroom?>> CreateAsync(CreateClassroomRequest request);
    Task<Response<Classroom?>> UpdateAsync(UpdateClassroomRequest request);
}
