namespace School.Api.Dtos.Requests.StudentClassroom;

public class CreateStudentClassroomAssociationRequest : Request
{
    public int StudentId { get; set; } 
    public int ClassroomId { get; set; } 
}
