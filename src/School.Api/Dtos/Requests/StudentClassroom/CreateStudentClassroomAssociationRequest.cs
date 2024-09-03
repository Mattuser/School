namespace School.Api.Dtos.Requests.StudentClassroom;

public class CreateStudentClassroomAssociationRequest : Request
{
    public string StudentUser { get; set; } = string.Empty;
    public string Classroom { get; set; } = string.Empty;
}
