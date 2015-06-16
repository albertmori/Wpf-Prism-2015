using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TplModule.ViewModels;

namespace UnitTestProject
{
    [TestClass]
    public class TplViewModelTests
    {
        [TestMethod]
        public void ShouldReturnStringLength()
        {
            // Arrange
            var mockRepository = new Mock<TplModule.ViewModels.TplViewModel>();

            mockRepository.Setup(x => x.GetStringLength(It.IsAny<string>()));

            // Act

            var sut = mockRepository.Object;

            // Assert
            Assert.AreEqual(sut.GetStringLength("2322"), 4);
        }
    }
}
