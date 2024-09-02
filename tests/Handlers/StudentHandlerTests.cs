using Azure.Core;
using Moq;
using School.Api.Abstractions;
using School.Api.Dtos.Requests.Student;
using School.Api.Entities;
using School.Api.Handlers;
using School.Api.Models.TestClasses;

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

    [Theory]
    [ClassData(typeof(TestStudentGenerator))]
    public async Task CreateAsync_Should_ReturnAlunoCadastrado_When_StudentAlreadyExists(
        List<CreateStudentRequest> requests)
    {
        // Arrange

        var existingStudent = new Student { Name = "student_1", User = "student_1" };

        foreach(var request in requests)
        {
            _studentRepositoryMock.Setup(repo => repo.AnyAsync(request.User))
                .ReturnsAsync(existingStudent);
        }

        //Act & Assert 

        foreach (var request in requests)
        {
            var result = await _studentHandler.CreateAsync(request);
            Assert.Equal("Aluno já cadastrado!", result.Message);
        }
        
    }

    [Theory]
    [ClassData(typeof(TestStudentGenerator))]
    public async Task CreateAsync_Should_ReturnCadastroRealizadoComSucesso_When_StudentNotExists(
        List<CreateStudentRequest> requests)
    {
        //Arrange

        foreach (var request in requests)
        {
            _studentRepositoryMock.Setup(repo => repo.AnyAsync(request.User))
               .ReturnsAsync(default(Student));
        }

        //Act & Assert

        foreach (var request in requests)
        {
            var result = await _studentHandler.CreateAsync(request);
            Assert.Equal("Cadastro realizado com sucesso!", result.Message);
        }


    }

    [Fact]
    public async Task UpdateAsync_Should_ReturnAlunoNaoCadastrado_When_StudentNotExists()
    {
        //Arrange
        var student = new UpdateStudentRequest{ User = "student_user", Name = "student" };

        //Act
        var result = await _studentHandler.UpdateAsync(student);

        //Assert
        Assert.Equal("Aluno não cadastrado!", result.Message);
    }

}
