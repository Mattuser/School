using Desafio_Fiap.Api.Dtos.Requests.Student;
using Desafio_Fiap.Api.Dtos.Responses;
using Desafio_Fiap.Api.Entities;

namespace Desafio_Fiap.Api.Abstractions;

public interface IStudentHandler
{
    Task<Response<Student?>> CreateAsync(CreateStudentRequest request);
    Task<Response<Student?>> UpdateAsync(UpdateStudentRequest request);
}
