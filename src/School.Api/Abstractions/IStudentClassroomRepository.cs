using School.Api.Dtos.Requests.StudentClassroom;
using School.Api.Entities;

namespace School.Api.Abstractions;

public interface IStudentClassroomRepository
{
    bool AssociationExists(int studentId, int classroomId);
    bool AssociationExists(Student student, Classroom classroom);
    Task<bool> AssociationExistsAsync(int studentId, int classroomId);
    Task<bool> AssociationExistsAsync(Student student, Classroom classroom);
    Task<Dictionary<string, object>>? AssociateAsync(int userId, int classroomId);
    Dictionary<string, object>? Any(int studentId, int classroomId);
    Task<Dictionary<string, object>?> AnyAsync(int studentId, int classroomId);
};