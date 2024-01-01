using Data.Entities;
using Humanizer.Localisation;
using Laboratorium3___App.Controllers;
using Laboratorium3___App.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Laboratorium_Test
{
    public class AlbumControllerTest
    {
        private readonly AlbumController _controller;
        private readonly Mock<IAlbumService> _mockService = new Mock<IAlbumService>();

        public AlbumControllerTest()
        {
            _controller = new AlbumController(_mockService.Object);
        }

     

        [Fact]
        public void Create_ReturnsViewResult_WithAlbumModel()
        {
            // Arrange
            _mockService.Setup(s => s.FindAllGenres()).Returns(new List<GenreEntity>());

            // Act
            var result = _controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<Album>(viewResult.Model);
        }

        [Fact]
        public void Create_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var album = new Album();

            // Act
            var result = _controller.Create(album);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Update_ReturnsNotFound_ForInvalidId()
        {
            // Arrange
            _mockService.Setup(s => s.FindById(It.IsAny<int>())).Returns<Album>(null);

            // Act
            var result = _controller.Update(0);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Update_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var album = new Album();
            _mockService.Setup(s => s.FindById(It.IsAny<int>())).Returns(album);
            _mockService.Setup(s => s.FindAllGenres()).Returns(new List<GenreEntity> { });

            // Act
            var result = _controller.Update(album);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Delete_ReturnsNotFound_ForInvalidId()
        {
            // Arrange
            _mockService.Setup(s => s.FindById(It.IsAny<int>())).Returns<Album>(null);

            // Act
            var result = _controller.Delete(0);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Details_ReturnsViewResult_WithAlbum()
        {
            // Arrange
            var album = new Album();
            _mockService.Setup(s => s.FindById(It.IsAny<int>())).Returns(album);
            _mockService.Setup(s => s.FindAllGenres()).Returns(new List<GenreEntity> {});

            // Act
            var result = _controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(album, viewResult.Model);
        }

        // Dodatkowe testy, które można zaimplementować:
        // - Create z niepoprawnym modelem (powinien zwrócić View).
        // - Delete z poprawnym modelem (powinien przekierować do Index).
        // - Details dla nieistniejącego albumu (powinien zwrócić NotFound).
    }
}
