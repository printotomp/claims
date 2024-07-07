using System;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json; // Add this line

namespace Claims
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load configuration from appsettings.json
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path
                    .AddJsonFile("appsettings.json")
                    .Build();

                var folderPath = configuration["MySettings:FolderPath"];
                var InputfileName = configuration["MySettings:InputFileName"];
                var OutputfileName = configuration["MySettings:OutputFileName"];

                string inputFilePath = "";
                string outputFilePath = "";

                if (folderPath != null && InputfileName != null)
                {
                    inputFilePath = Path.Combine(folderPath, InputfileName);
                }

                if (folderPath != null && OutputfileName != null)
                {
                    outputFilePath = Path.Combine(folderPath, OutputfileName);
                }

                // Read claims data from CSV
                var reader = new CsvClaimsReader(); 
                var claims = reader.ReadClaims(inputFilePath);

                if (claims != null)
                {
                    // Calculate accumulated data
                    var calculator = new AccumulatedDataCalculator();
                    var accumulatedData = calculator.CalculateAccumulatedData(claims);

                    // Write accumulated data to output CSV
                    var writer = new CsvOutputWriter();
                    writer.WriteOutput(accumulatedData, outputFilePath);

                    Console.WriteLine("Process completed successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
