using BLL.DTO;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using System.Runtime.CompilerServices;

namespace NewsSite.Tests
{
    [TestFixture]
    public class NewsServiceTests
    {

        [Test]
        public async Task NewsService_GetAll_ReturnsAllNews()
        {
            //arrange
            var expected = TestData.NewsDTO;

            var mockUintOfWork = new Mock<IUnitOfWork>();

            mockUintOfWork.Setup(x => x.NewsRepository.GetAllWithDetailsOrderByRubrics())
                .ReturnsAsync(TestData.News.AsEnumerable());

            var newsService = new NewsService(mockUintOfWork.Object, UnitTestHelper.CreateMapperProfile());

            //act
            var actual = await newsService.GetAll();

            //assert
            actual.Should().BeEquivalentTo(expected);
        }


        

    }
}