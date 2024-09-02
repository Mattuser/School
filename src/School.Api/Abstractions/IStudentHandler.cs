using School.Api.Dtos.Requests.Student;
using School.Api.Dtos.Responses;
using School.Api.Entities;

namespace School.Api.Abstractions;

public interface IStudentHandler
{
    Task<Response<Student?>> CreateAsync(CreateStudentRequest request);
    Task<Response<Student?>> UpdateAsync(UpdateStudentRequest request);
}
