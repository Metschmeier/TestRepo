using Xunit;
using Moq;
using AutoMapper;
using Praktikum.Services.Repository;
using Praktikum.Types.DTOs;
using Praktikum.Types;
using Microsoft.AspNetCore.Mvc;

public class IsolationTest
{
    private readonly Mock<IPartnerRepository> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly PartnerController _controller;

    public IsolationTest()
    {
        _mockRepo = new Mock<IPartnerRepository>();
        _mockMapper = new Mock<IMapper>();
        _controller = new PartnerController(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public void Create_CallsMapperAndRepository()
    {
        var inputDto = new PartnerDto
        {
            Name = "TestPartner",
            Kontonummer = "123",
            Typ = "TypA",
            Adresse = "Teststraße 1",
            EMail = "test@example.com"
        };

        var mappedEntity = new Partnerzeile();

        _mockMapper.Setup(m => m.Map<Partnerzeile>(inputDto)).Returns(mappedEntity);

        _mockRepo.Setup(r => r.Add(mappedEntity));

        _mockMapper.Setup(m => m.Map<PartnerDto>(mappedEntity)).Returns(inputDto);

        var result = _controller.Create(inputDto);

        _mockMapper.Verify(m => m.Map<Partnerzeile>(inputDto), Times.Once);

        _mockRepo.Verify(r => r.Add(mappedEntity), Times.Once);

        _mockMapper.Verify(m => m.Map<PartnerDto>(mappedEntity), Times.Once);

        Assert.IsType<CreatedAtActionResult>(result);
    }
}