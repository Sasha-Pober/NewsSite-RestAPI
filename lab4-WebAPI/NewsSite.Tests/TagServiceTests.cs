using BLL.DTO;
using BLL.Services;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using FluentAssertions;
using Moq;

namespace NewsSite.Tests;

[TestFixture]
public class TagServiceTests
{
    [Test]
    public async Task GetAllTags_ReturnsAllTags()
    {
        //arrange
        var expected = TestData.TagsDTO;

        var mockUintOfWork = new Mock<IUnitOfWork>();

        mockUintOfWork.Setup(x => x.TagRepository.GetAll())
            .ReturnsAsync(TestData.Tags.AsEnumerable());

        var tagService = new TagService(mockUintOfWork.Object, UnitTestHelper.CreateMapperProfile());

        //act
        var actual = await tagService.GetAll();

        //assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    [TestCase(1)]
    public async Task GetById_ValidId_ReturnsTag(int id)
    {
        //arrange
        var expected = TestData.TagsDTO[id];

        var mockUintOfWork = new Mock<IUnitOfWork>();

        mockUintOfWork.Setup(x => x.TagRepository.GetById(It.IsAny<int>()))
            .ReturnsAsync(TestData.Tags[id]);

        var tagService = new TagService(mockUintOfWork.Object, UnitTestHelper.CreateMapperProfile());

        //act
        var actual = await tagService.GetById(id);

        //assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    [TestCase(100)]
    public async Task GetById_InvalidId_ThrowsException(int id)
    {
        //arrange
        var mockUintOfWork = new Mock<IUnitOfWork>();

        mockUintOfWork.Setup(x => x.TagRepository.GetById(It.IsAny<int>()))
            .ThrowsAsync(new Exception());

        var tagService = new TagService(mockUintOfWork.Object, UnitTestHelper.CreateMapperProfile());

        //act
        Func<Task> act = async() => await tagService.GetById(id);

        //assert
        await act.Should().ThrowAsync<Exception>();
    }

    [Test]
    public async Task Create_ValidData_ReturnsListWithNewTag()
    {
        //arrange
        var tag = new TagDTO { Id = 6, Name = "test" };

        var mockUnit = new Mock<IUnitOfWork>();
        mockUnit.Setup(x => x.TagRepository.Create(It.IsAny<Tag>()));

        var tagService = new TagService(mockUnit.Object, UnitTestHelper.CreateMapperProfile());

        //act
        await tagService.Create(tag);

        //assert
        mockUnit.Verify(x => x.TagRepository.Create(It.Is<Tag>(
            x => x.Id == tag.Id && x.Name.Equals(tag.Name))), Times.Once);
        mockUnit.Verify(x => x.SaveAsync(), Times.Once);
    }

    [Test]
    public async Task Create_ExistingData_ThrowsException()
    {
        //arrange
        var tag = TestData.TagsDTO[1];

        var mockUnit = new Mock<IUnitOfWork>();
        mockUnit.Setup(x => x.TagRepository.Create(It.IsAny<Tag>()))
            .ThrowsAsync(new Exception());

        var tagService = new TagService(mockUnit.Object, UnitTestHelper.CreateMapperProfile());

        //act
        Func<Task> act = async() => await tagService.Create(tag);

        //assert
        await act.Should().ThrowAsync<Exception>();
    }

    [Test]
    public async Task Create_InvalidData_ThrowsException()
    {
        //arrange
        var tag = new TagDTO { Id = 0, Name = string.Empty };

        var mockUnit = new Mock<IUnitOfWork>();
        mockUnit.Setup(x => x.TagRepository.Create(It.IsAny<Tag>()))
            .ThrowsAsync(new Exception());

        var tagService = new TagService(mockUnit.Object, UnitTestHelper.CreateMapperProfile());

        //act
        Func<Task> act = async () => await tagService.Create(tag);

        //assert
        await act.Should().ThrowAsync<Exception>();

    }

    [Test]
    [TestCase(200)]
    public async Task Delete_InValidData_ThrowsException(int id)
    {
        //arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        mockUnitOfWork.Setup(m => m.TagRepository.Delete(It.IsAny<Tag>()));

        var tagService = new TagService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

        //act
        Func<Task> act = async() => await tagService.Delete(id);

        //assert
        await act.Should().ThrowAsync<Exception>();
    }

}
