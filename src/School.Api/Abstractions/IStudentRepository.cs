using School.Api.Dtos.Requests.Student;
using School.Api.Dtos.Responses;
using School.Api.Entities;

namespace School.Api.Abstractions;

public interface IStudentRepository
{
    public Task CreateAsync(Student student);
    public Task UpdateAsync(Student student);
    public Task<Student?> AnyAsync(string user);
}
