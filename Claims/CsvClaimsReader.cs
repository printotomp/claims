using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Claims
{
    public class CsvClaimsReader : IClaimsReader
    {
        public List<Claim> ReadClaims(string filePath)
        {
            try
            {
                // Create a CsvConfiguration with the invariant culture
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null // Disable header validation (useful for custom headers)
                };

                if (File.Exists(filePath))
                {
                    // File exists, proceed with reading and processing
                    using (var reader = new StreamReader(filePath))
                    using (var csv = new CsvReader(reader, config))
                    {
                        return csv.GetRecords<Claim>().ToList();
                    }
                }
                else
                {
                    Console.WriteLine("File not found at " + filePath);
                    return new List<Claim>();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it or throw a custom exception)
                Console.WriteLine($"Error reading claims from CSV: {ex.Message}");
                return new List<Claim>(); // Return an empty list or handle the error appropriately
            }
        }
    }
}
