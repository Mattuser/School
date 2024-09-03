using Moq;
using School.Api.Abstractions;
using School.Api.Dtos.Requests.Classroom;
using School.Api.Entities;
using School.Api.Handlers;

namespace tests.Handlers;
public class ClassroomHandlerTests
{
    private readonly Mock<IClassroomRepository> _classroomRepositoryMock;
    private readonly IClassroomHandler _classroomHandler;
    public ClassroomHandlerTests() 
    {
        _classroomRepositoryMock = new Mock<IClassroomRepository>();
        _classroomHandler = new ClassroomHandler(_classroomRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateAsync_Should_ReturnTurmaJaCadastrada_When_ClassroomExists()
    {
        // Arrange
        var existingClassroom = new Classroom();
        var createClassroomRequest = new CreateClassroomRequest {  Classroom = "turma_1" };
         _classroomRepositoryMock.Setup(r => r.AnyAsync(createClassroomRequest.Classroom))
            .ReturnsAsync(existingClassroom);

        // Act
        var result = await _classroomHandler.CreateAsync(createClassroomRequest);

        // Assert
        Assert.Equal("Turma já cadastrada!", result.Message);

    }

    [Fact]
    public async Task CreateAsync_Should_ReturnCadastroRealizadoComSucesso_When_ClassroomNotExists()
    {
        // Arrange
        var createClassroomRequest = new CreateClassroomRequest() { Classroom = "turma1"};
        _classroomRepositoryMock.Setup(r => r.AnyAsync("turma_01"))
           .ReturnsAsync(default(Classroom));

        // Act
        var result = await _classroomHandler.CreateAsync(createClassroomRequest);

        // Assert
        Assert.Equal("Cadastro realizado com sucesso!", result.Message);

    }
}
