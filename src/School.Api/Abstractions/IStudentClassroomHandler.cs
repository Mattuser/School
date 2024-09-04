using School.Api.Dtos.Requests.StudentClassroom;
using School.Api.Dtos.Responses;

namespace School.Api.Abstractions;

public interface IStudentClassroomHandler
{
    Task<bool> AssociationExistsAsync(string studentUser, string classroom);
    Task<Response<Dictionary<string, object>>> AssociateAsync(CreateStudentClassroomAssociationRequest request);
}
