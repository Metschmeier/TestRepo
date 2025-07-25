using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Praktikum.Services.Repository;
using Praktikum.Types.DTOs;
using Praktikum.Types;

public class CreateTest
{
    private readonly Mock<IPartnerRepository> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly PartnerController _controller;

    public CreateTest()
    {
        _mockRepo = new Mock<IPartnerRepository>();
        _mockMapper = new Mock<IMapper>();
        _controller = new PartnerController(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public void Create_ValidDto_ReturnsCreatedAtActionResult_WithCorrectId()
    {
        var inputDto = new PartnerDto
        {
            Name = "Neuer Partner",
            Kontonummer = "1234",
            Typ = "Typ1",
            Adresse = "Adresse",
            EMail = "test@example.com"
        };
        var entity = new Partnerzeile
        {
            Id = 0,
            Name = inputDto.Name,
            Kontonummer = inputDto.Kontonummer,
            Typ = inputDto.Typ,
            Adresse = inputDto.Adresse,
            EMail = inputDto.EMail
        };

        _mockMapper.Setup(m => m.Map<Partnerzeile>(inputDto)).Returns(entity);
        _mockRepo.Setup(r => r.Add(entity)).Callback(() => entity.Id = 99);
        _mockMapper.Setup(m => m.Map<PartnerDto>(entity)).Returns(new PartnerDto
        {
            Id = 99,
            Name = entity.Name,
            Kontonummer = entity.Kontonummer,
            Typ = entity.Typ,
            Adresse = entity.Adresse,
            EMail = entity.EMail
        });

        var result = _controller.Create(inputDto);

        var createdAtResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(_controller.GetDtoById), createdAtResult.ActionName);

        var returnDto = Assert.IsType<PartnerDto>(createdAtResult.Value);
        Assert.Equal(99, returnDto.Id);
    }

    [Fact]
    public void Create_InvalidModelState_ReturnsBadRequest()
    {
        var invalidDto = new PartnerDto(); 

        _controller.ModelState.AddModelError("Name", "Name ist erforderlich.");

        var result = _controller.Create(invalidDto);

        Assert.IsType<BadRequestObjectResult>(result);
    }
}