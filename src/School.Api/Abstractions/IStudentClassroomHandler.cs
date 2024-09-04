using School.Api.Dtos.Requests.StudentClassroom;
using School.Api.Dtos.Responses;

namespace School.Api.Abstractions;

public interface IStudentClassroomHandler
{
    bool AssociationExistsAsync(int studentUser, int classroom);
    Task<Response<Dictionary<string, object>>> AssociateAsync(CreateStudentClassroomAssociationRequest request);
}
