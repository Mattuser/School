namespace School.Api.Dtos.Requests.StudentClassroom;

public class AssociationExistsRequest : Request
{
    public string StudentUser { get; set; } = string.Empty;
    public string Classroom { get; set; } = string.Empty;
}
