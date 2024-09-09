using School.Api.Dtos.Requests.StudentClassroom;
using School.Api.Dtos.Responses;
using School.Api.Entities;

namespace School.Api.Abstractions;

public interface IStudentClassroomHandler
{
    Task<bool> AssociationExistsAsync(int studentUser, int classroom);
    Task<Response<StudentClassroom>> AssociateAsync(CreateStudentClassroomAssociationRequest request);
}
