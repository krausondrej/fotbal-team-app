using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using fotbalTeam.Areas.Admin.Controllers;
using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using System.Linq;

namespace fotbalTeam.Tests.Controllers
{
    public class TrainingControllerTests
    {
        private readonly Mock<ITrainingAppService> _mockTrainingAppService;
        private readonly TrainingController _controller;

        public TrainingControllerTests()
        {
            _mockTrainingAppService = new Mock<ITrainingAppService>();
            _controller = new TrainingController(_mockTrainingAppService.Object);
        }

        [Fact]
        public void Select_ReturnsViewWithTrainings()
        {
            // Arrange
            var trainings = new List<Training>
            {
                new Training { Id = 1, Date = DateTime.Now, Description = "Training 1" },
                new Training { Id = 2, Date = DateTime.Now.AddDays(1), Description = "Training 2" }
            };
            _mockTrainingAppService.Setup(s => s.Select()).Returns(trainings);

            // Act
            var result = _controller.Select();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IList<Training>>(viewResult.Model);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void Create_Get_ReturnsViewWithDefaultTraining()
        {
            // Act
            var result = _controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Training>(viewResult.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public void Create_Post_ValidModel_RedirectsToSelect()
        {
            // Arrange
            var training = new Training { Id = 1, Date = DateTime.Now, Description = "Training 1" };

            // Act
            var result = _controller.Create(training);

            // Assert
            _mockTrainingAppService.Verify(s => s.Create(training), Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(TrainingController.Select), redirectResult.ActionName);
        }

        [Fact]
        public void Create_Post_InvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            _controller.ModelState.AddModelError("Description", "Required");
            var training = new Training { Id = 1, Date = DateTime.Now };

            // Act
            var result = _controller.Create(training);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(training, viewResult.Model);
        }

        [Fact]
        public void Delete_ExistingId_RedirectsToSelect()
        {
            // Arrange
            _mockTrainingAppService.Setup(s => s.Delete(It.IsAny<int>())).Returns(true);

            // Act
            var result = _controller.Delete(1);

            // Assert
            _mockTrainingAppService.Verify(s => s.Delete(1), Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(TrainingController.Select), redirectResult.ActionName);
        }

        [Fact]
        public void Delete_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            _mockTrainingAppService.Setup(s => s.Delete(It.IsAny<int>())).Returns(false);

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Edit_Get_ExistingId_ReturnsViewWithTraining()
        {
            // Arrange
            var training = new Training { Id = 1, Date = DateTime.Now, Description = "Training 1" };
            _mockTrainingAppService.Setup(s => s.Select()).Returns(new List<Training> { training });

            // Act
            var result = _controller.Edit(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(training, viewResult.Model);
        }

        [Fact]
        public void Edit_Get_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            _mockTrainingAppService.Setup(s => s.Select()).Returns(new List<Training>());

            // Act
            var result = _controller.Edit(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Edit_Post_ValidModel_RedirectsToSelect()
        {
            // Arrange
            var training = new Training { Id = 1, Date = DateTime.Now, Description = "Training 1" };
            _mockTrainingAppService.Setup(s => s.Update(It.IsAny<Training>())).Returns(true);

            // Act
            var result = _controller.Edit(training);

            // Assert
            _mockTrainingAppService.Verify(s => s.Update(training), Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(TrainingController.Select), redirectResult.ActionName);
        }

        [Fact]
        public void Edit_Post_InvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            _controller.ModelState.AddModelError("Description", "Required");
            var training = new Training { Id = 1, Date = DateTime.Now };

            // Act
            var result = _controller.Edit(training);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(training, viewResult.Model);
        }

        [Fact]
        public void Edit_Post_UpdateFails_ReturnsViewWithModel()
        {
            // Arrange
            var training = new Training { Id = 1, Date = DateTime.Now, Description = "Training 1" };
            _mockTrainingAppService.Setup(s => s.Update(It.IsAny<Training>())).Returns(false);

            // Act
            var result = _controller.Edit(training);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(training, viewResult.Model);
        }
    }
}
