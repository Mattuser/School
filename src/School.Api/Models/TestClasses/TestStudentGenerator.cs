using School.Api.Dtos.Requests.Student;
using System.Collections;

namespace School.Api.Models.TestClasses;

public class TestStudentGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
         {
            new List<CreateStudentRequest>
            {
                new CreateStudentRequest { Name = "student2", User = "student_2" },
                new CreateStudentRequest { Name = "student3", User = "student_3" },
                new CreateStudentRequest { Name = "student4", User = "student_4" },
                new CreateStudentRequest { Name = "student5", User = "student_5" }
            }
         };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
