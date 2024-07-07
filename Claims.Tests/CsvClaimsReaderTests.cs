using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Claims.Tests
{
    public class CsvClaimsReaderTests
    {
        private readonly IConfiguration _configuration;

        public CsvClaimsReaderTests()
        {
            // Load configuration from appsettings.json
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private string GetInputFilePath(string fileName)
        {
            var folderPath = _configuration["MySettings:FolderPath"] ?? string.Empty;
            return Path.Combine(folderPath, fileName);
        }

        [Theory]
        [InlineData("Input.csv")]
        public void ReadClaims_ValidFile_ReturnsClaimsList(string inputFileName)
        {
            // Arrange
            var inputFilePath = GetInputFilePath(inputFileName);
            var claimsReader = new CsvClaimsReader();

            // Act
            var claims = claimsReader.ReadClaims(inputFilePath);

            // Assert
            Assert.NotNull(claims);
            Assert.NotEmpty(claims);
        }

        [Theory]
        [InlineData("Invalid.csv")]
        public void ReadClaims_InvalidFile_ReturnsEmptyList(string inputFileName)
        {
            // Arrange
            var invalidFilePath = GetInputFilePath(inputFileName);
            var claimsReader = new CsvClaimsReader();

            // Act
            var claims = claimsReader.ReadClaims(invalidFilePath);

            // Assert
            Assert.NotNull(claims);
            Assert.Empty(claims);
        }
    }
}
