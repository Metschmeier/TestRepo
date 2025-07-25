using Xunit;
using Moq;
using AutoMapper;
using Praktikum.Services.Repository;
using Praktikum.Types.DTOs;
using Praktikum.Types;
using Microsoft.AspNetCore.Mvc;

public class APITest
{
    private readonly Mock<IPartnerRepository> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly PartnerController _controller;

    public APITest()
    {
        _mockRepo = new Mock<IPartnerRepository>();
        _mockMapper = new Mock<IMapper>();
        _controller = new PartnerController(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public void Update_ExistingEntity_ReturnsNoContent()
    {
        int testId = 1;
        var dto = new PartnerDto { Id = testId, Name = "Neu", Kontonummer = "456", Typ = "TypB", Adresse = "Neue Straße", EMail = "neu@example.com" };
        var entity = new Partnerzeile { Id = testId };

        _mockMapper.Setup(m => m.Map<Partnerzeile>(dto)).Returns(entity);

        _mockRepo.Setup(r => r.Update(testId, entity)).Returns(true);

        var result = _controller.Update(testId, dto);

        Assert.IsType<NoContentResult>(result);
        _mockMapper.Verify(m => m.Map<Partnerzeile>(dto), Times.Once);
        _mockRepo.Verify(r => r.Update(testId, entity), Times.Once);
    }

    [Fact]
    public void Update_NonExistingEntity_ReturnsNotFound()
    {
        int testId = 99;
        var dto = new PartnerDto { Id = testId };

        var entity = new Partnerzeile { Id = testId };
        _mockMapper.Setup(m => m.Map<Partnerzeile>(dto)).Returns(entity);

        _mockRepo.Setup(r => r.Update(testId, entity)).Returns(false);

        var result = _controller.Update(testId, dto);

        Assert.IsType<NotFoundResult>(result);
        _mockMapper.Verify(m => m.Map<Partnerzeile>(dto), Times.Once);
        _mockRepo.Verify(r => r.Update(testId, entity), Times.Once);
    }

    [Fact]
    public void Delete_ExistingEntity_ReturnsNoContent()
    {
        int testId = 1;
        _mockRepo.Setup(r => r.Delete(testId)).Returns(true);

        var result = _controller.Delete(testId);

        Assert.IsType<NoContentResult>(result);
        _mockRepo.Verify(r => r.Delete(testId), Times.Once);
    }

    [Fact]
    public void Delete_NonExistingEntity_ReturnsNotFound()
    {
        int testId = 99;
        _mockRepo.Setup(r => r.Delete(testId)).Returns(false);

        var result = _controller.Delete(testId);

        Assert.IsType<NotFoundResult>(result);
        _mockRepo.Verify(r => r.Delete(testId), Times.Once);
    }
}