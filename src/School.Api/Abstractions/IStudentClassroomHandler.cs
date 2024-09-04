using School.Api.Dtos.Requests.StudentClassroom;
using School.Api.Dtos.Responses;
using School.Api.Entities;

namespace School.Api.Abstractions;

public interface IStudentClassroomHandler
{
    bool AssociationExistsAsync(int studentUser, int classroom);
    Task<Response<StudentClasroom>> AssociateAsync(CreateStudentClassroomAssociationRequest request);
}
