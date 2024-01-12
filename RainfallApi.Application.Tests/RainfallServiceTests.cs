// RainfallApi.Application.Tests/RainfallServiceTests.cs

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json;
using RainfallApi.Application.Interfaces;
using RainfallApi.Application.Services;
using RainfallApi.Application.Exceptions;
using RainfallApi.Core.Entities;
using RainfallApi.Core.Interfaces;
using Xunit;

namespace RainfallApi.Application.Tests
{
    public class RainfallServiceTests
    {
        [Fact]
        public async Task GetRainfallReadingsAsync_ShouldReturnCorrectResponse()
        {
            // Arrange
            var mockRepository = new Mock<IRainfallRepository>();
            var mockExternalApiService = new Mock<IExternalApiService>();

            var expectedStationId = "026090";
            var expectedCount = 10;

            var responseData = new FloodMonitoringResponse
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        LatestReading = new LatestReading
                        {
                            dateTime = "2024-01-10",
                            value = 15.2
                        }
                    }
                }
            };

            var responseJson = JsonConvert.SerializeObject(responseData);

            mockExternalApiService
                .Setup(service => service.GetData(It.IsAny<string>()))
                .ReturnsAsync(responseJson);

            var rainfallService = new RainfallService(mockRepository.Object, mockExternalApiService.Object);

            // Act
            var result = await rainfallService.GetRainfallReadingsAsync(expectedStationId, expectedCount);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Readings);

            // Assuming you have a proper implementation of mapping logic, check the mapped values
            var firstReading = Assert.Single(result.Readings);
            Assert.Equal("2024-01-10", firstReading.dateMeasured);
            Assert.Equal(15.2, firstReading.amountMeasured);

            // Verify that GetData method on IExternalApiService is called with the correct URL
            mockExternalApiService.Verify(service =>
                service.GetData($"http://environment.data.gov.uk/flood-monitoring/id/stations/{expectedStationId}/measures"),
                Times.Once);
        }

        [Fact]
        public async Task GetRainfallReadingsAsync_ShouldHandleExternalApiException()
        {
            // Arrange
            var mockRepository = new Mock<IRainfallRepository>();
            var mockExternalApiService = new Mock<IExternalApiService>();

            var expectedStationId = "testStationId";
            var expectedCount = 10;

            // Simulate ExternalApiException
            mockExternalApiService
                .Setup(service => service.GetData(It.IsAny<string>()))
                .ThrowsAsync(new ExternalApiException("Simulated external API exception"));

            var rainfallService = new RainfallService(mockRepository.Object, mockExternalApiService.Object);

            // Act and Assert
            await Assert.ThrowsAsync<ExternalApiException>(() =>
                rainfallService.GetRainfallReadingsAsync(expectedStationId, expectedCount));

            // Verify that GetData method on IExternalApiService is called with the correct URL
            mockExternalApiService.Verify(service =>
                service.GetData($"http://environment.data.gov.uk/flood-monitoring/id/stations/{expectedStationId}/measures"),
                Times.Once);
        }

        // Add more test cases as needed
    }
}
