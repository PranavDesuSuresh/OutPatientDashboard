using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OutPatientDashboard.Service.Controllers;
using OutPatientDashboard.Service.Managers;
using OutPatientDashboard.Service.Util;

namespace OutPatientDashboard.Service.Tests.Controllers
{
    internal class PatientControllerTests
    {
        private Mock<IPatientManager> _PatientManager = new();
        private Mock<ICustomLogger> _logger = new Mock<ICustomLogger>();
        private PatientController _systemUderTest;

        [SetUp]
        public void Setup()
        {
            _PatientManager.Setup(x => x.GetInCarePatientCount()).Returns(Task.FromResult(2));
            _PatientManager.Setup(x => x.PatientsDischargedByDate(It.IsAny<DateTime?>())).Returns(Task.FromResult(2));
            _systemUderTest = new PatientController(_PatientManager.Object, _logger.Object);
        }

        [Test]
        public async Task GetInCarePatientCount_WhenCalled_ReturnsCountAsync()
        {
            // Act
            var result = await _systemUderTest.GetInCareCount();
            var okResult = result as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.That(okResult?.Value, Is.EqualTo(2));
        }

        [Test]
        public void GetInCarePatientCount_WhenCalled_ThrowsException()
        {
            // Arrange
            _PatientManager.Setup(x => x.GetInCarePatientCount()).Throws<ArgumentException>();
            _systemUderTest = new PatientController(_PatientManager.Object, _logger.Object);

            // Act // Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _systemUderTest.GetInCareCount());
            Assert.That(ex.Message, Is.EqualTo("Value does not fall within the expected range."));
        }

        [Test]
        public async Task DischargedByDate_WhenCalled_ReturnsCountAsync()
        {
            // Act
            var result = await _systemUderTest.DischargedByDate(DateTime.Now);
            var okResult = result as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.That(okResult?.Value, Is.EqualTo(2));
        }

        [Test]
        public void DischargedByDate_WhenCalled_ThrowsException()
        {
            // Arrange
            _PatientManager.Setup(x => x.PatientsDischargedByDate(It.IsAny<DateTime?>())).Throws<ArgumentException>();
            _systemUderTest = new PatientController(_PatientManager.Object, _logger.Object);

            // Act // Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _systemUderTest.DischargedByDate(DateTime.Now));
            Assert.That(ex.Message, Is.EqualTo("Value does not fall within the expected range."));
        }
    }
}
