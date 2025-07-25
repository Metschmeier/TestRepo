using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Praktikum.Services.Repository;
using Praktikum.Types.DTOs;
using Praktikum.Types;
using AutoMapper;

public class ValidationTest
{
    private readonly Mock<IPartnerRepository> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly PartnerController _controller;

    public ValidationTest()
    {
        _mockRepo = new Mock<IPartnerRepository>();
        _mockMapper = new Mock<IMapper>();
        _controller = new PartnerController(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public void Create_InvalidModel_ReturnsBadRequest()
    {
        var invalidDto = new PartnerDto
        {
            Kontonummer = "12345",
            Typ = "Test",
            Adresse = "Teststraße 1",
            EMail = "test@test.de"
        };

        _controller.ModelState.AddModelError("Name", "Name ist erforderlich");

        var result = _controller.Create(invalidDto);

        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.NotNull(badRequestResult.Value);
    }

    [Fact]
    public void Create_ValidModel_ReturnsCreatedAtAction()
    {
        var validDto = new PartnerDto
        {
            Id = null,
            Kontonummer = "12345",
            Name = "Partner X",
            Typ = "Typ A",
            Adresse = "Teststraße 1",
            EMail = "test@test.de"
        };

        var partnerEntity = new Partnerzeile { Id = 1 };

        _mockMapper.Setup(m => m.Map<Partnerzeile>(validDto)).Returns(partnerEntity);
        _mockRepo.Setup(r => r.Add(partnerEntity)).Callback(() => partnerEntity.Id = 1);
        _mockMapper.Setup(m => m.Map<PartnerDto>(partnerEntity)).Returns(new PartnerDto { Id = 1 });

        var result = _controller.Create(validDto);

        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(1, ((PartnerDto)createdAtActionResult.Value).Id);
    }
}