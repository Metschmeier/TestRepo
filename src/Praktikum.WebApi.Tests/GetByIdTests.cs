using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Praktikum.Services.Repository;
using Praktikum.Types.DTOs;
using Praktikum.Types;

public class PartnerControllerTests
{
    private readonly Mock<IPartnerRepository> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly PartnerController _controller;

    public PartnerControllerTests()
    {
        _mockRepo = new Mock<IPartnerRepository>();
        _mockMapper = new Mock<IMapper>();
        _controller = new PartnerController(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public void GetDtoById_ReturnsOkObjectResult_WithCorrectDto()
    {
        // Arrange
        int testId = 42;
        var partnerDto = new PartnerDto { Id = testId, Name = "Test Partner" };

        _mockRepo.Setup(repo => repo.GetDtoById(testId)).Returns(partnerDto);
        _mockMapper.Setup(m => m.Map<PartnerDto>(It.IsAny<PartnerDto>())).Returns(partnerDto);

        // Act
        var result = _controller.GetDtoById(testId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedDto = Assert.IsType<PartnerDto>(okResult.Value);
        Assert.Equal(testId, returnedDto.Id);
    }

    [Fact]
    public void GetDtoById_ReturnsNotFoundResult_WhenEntityIsNull()
    {
        // Arrange
        int testId = 42;

        _mockRepo.Setup(repo => repo.GetDtoById(testId)).Returns((PartnerDto?)null);

        // Act
        var result = _controller.GetDtoById(testId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}