using System.Collections.Generic;
using System.Threading.Tasks;
using HomeTask4.Core.Controllers;
using HomeTask4.Core.Entities;
using HomeTask4.SharedKernel.Interfaces;
using Moq;
using Xunit;

namespace HomeTask5.Core.Tests
{
    public class TempEntityControllerTests
    {
        [Fact]
        public async Task AddNewTempEntity_Should_Return_New_Entity()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>(); // Create mock object for IRepository

            // Simulate "ListAsync" method from "IRepository" to return test list of entities
            repositoryMock.Setup(o => o.ListAsync<TempEntity>())
                .ReturnsAsync(new List<TempEntity>
                {
                    new TempEntity { Id = 1 },
                    new TempEntity { Id = 3 }
                });
            // Simulate "AddAsync" method from "IRepository" to return new test entity
            repositoryMock.Setup(o => o.AddAsync(It.IsAny<TempEntity>()))
                .ReturnsAsync((TempEntity x) => x);

            var unitOfWorkMock = new Mock<IUnitOfWork>(); // Create mock object for IUnitOfWork

            // Simulate "Repository" property to return prevously created mock object for IRepository
            unitOfWorkMock.Setup(o => o.Repository)
                .Returns(repositoryMock.Object);

            // Create controller which should be tested
            var controller = new TempEntityController(unitOfWorkMock.Object);

            // Act
            // Run method which should be tested
            var newEntity = await controller.AddNewTempEntity();

            // Assert
            // Check if the new entity has the max Id + 1
            Assert.Equal(4, newEntity.Id);
        }
    }
}
