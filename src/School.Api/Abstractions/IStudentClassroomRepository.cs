using School.Api.Dtos.Requests.StudentClassroom;

namespace School.Api.Abstractions;

public interface IStudentClassroomRepository
{
    Task<bool> AssociationExists(string user, string classroom);
    Task<Dictionary<string, object>> AssociateAsync(string user, string classroom);
};