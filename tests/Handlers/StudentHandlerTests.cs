using Moq;
using School.Api.Abstractions;
using School.Api.Dtos.Requests.Student;
using School.Api.Entities;
using School.Api.Handlers;

namespace tests.Handlers;
public class StudentHandlerTests
{
    private readonly StudentHandler _studentHandler;
    private readonly Mock<IStudentRepository> _studentRepositoryMock;

    public StudentHandlerTests()
    {
        _studentRepositoryMock = new Mock<IStudentRepository>();
        _studentHandler = new StudentHandler(_studentRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateAsync_Should_ReturnAlunoCadastrado_When_StudentAlreadyExists()
    {
        // Arrange
        var existingStudent = new Student { Name = "student1", User = "student_1"};
        _studentRepositoryMock.Setup(repo => repo.AnyAsync("student_1"))
            .ReturnsAsync(existingStudent);

        var request = new CreateStudentRequest { Name = "student1", User = "student_1" };

        //Act 
        var result = await _studentHandler.CreateAsync(request);


        //Assert
        Assert.Equal("Aluno já cadastrado!", result.Message);
    }
}
