using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Claims.Tests
{
    public class CsvOutputWriterTests
    {
        private readonly IConfiguration _configuration;

        public CsvOutputWriterTests()
        {
            // Load configuration from appsettings.json
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private string GetOutputFilePath(string fileName)
        {
            var folderPath = _configuration["MySettings:FolderPath"] ?? string.Empty;
            return Path.Combine(folderPath, fileName);
        }

        [Theory]
        [InlineData("Comp", 2010, 1000)]
        [InlineData("Non-Comp", 2011, 1200)]
        public void WriteOutput_ValidData_WritesToCsvFile(string product, int originYear, double incrementalValue)
        {
            // Arrange
            var accumulatedData = new List<AccumulatedClaimData>
            {
                new AccumulatedClaimData { Product = product, OriginYear = originYear, IncrementalValue = incrementalValue }
            };

            var outputFilePath = GetOutputFilePath(_configuration["MySettings:OutputFileName"] ?? string.Empty);

            // Act
            var outputWriter = new CsvOutputWriter();
            outputWriter.WriteOutput(accumulatedData, outputFilePath);

            // Assert: Verify the file content or size
        }

        [Fact]
        public void WriteOutput_EmptyData_WritesEmptyCsvFile()
        {
            // Arrange
            var emptyData = new List<AccumulatedClaimData>();
            var outputEmptyFilePath = GetOutputFilePath(_configuration["MySettings:EmptyOutpuFileName"] ?? string.Empty);

            // Act
            var outputWriter = new CsvOutputWriter();
            outputWriter.WriteOutput(emptyData, outputEmptyFilePath);

            // Assert: Verify the file content or size
        }
    }
}
