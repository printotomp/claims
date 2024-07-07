using Claims;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class CsvOutputWriter : IOutputWriter
{
    public void WriteOutput(List<AccumulatedClaimData> accumulatedData, string filePath)
    {
        try
        {
            // Initialize a StreamWriter to write to the specified file path
            using (var writer = new StreamWriter(filePath))
            {
                // Write the earliest origin year and the number of development years
                var earliestYear = int.MaxValue;
                var numDevelopmentYears = 0;

                foreach (var productData in accumulatedData)
                {
                    earliestYear = Math.Min(earliestYear, productData.OriginYear);
                    numDevelopmentYears = Math.Max(numDevelopmentYears, productData.DevelopmentYear - earliestYear + 1);
                }

                // Write the header line with earliest year and number of development years
                writer.WriteLine($"{earliestYear}, {numDevelopmentYears}");

                // Process data for each product
                foreach (var productData in accumulatedData.GroupBy(c => c.Product).Select(group => group.Key))
                {
                    // Write the product name
                    writer.Write(productData);

                    int earliestYearCount = 0;
                    int numDevelopmentYearsCount = numDevelopmentYears;
                    int maxYearCount = numDevelopmentYears;

                    // Iterate through development years
                    for (int i = 0; i < numDevelopmentYearsCount; i++)
                    {
                        var currentYear = earliestYear + earliestYearCount;
                        var maxYear = currentYear + maxYearCount - 1;

                        // Write incremental values for each year
                        for (int year = currentYear; year <= maxYear; year++)
                        {
                            var yearData = accumulatedData.Find(d => d.Product == productData && d.OriginYear == currentYear && d.DevelopmentYear == year);
                            writer.Write($",{yearData?.IncrementalValue ?? 0.0}");
                        }

                        earliestYearCount++;
                        maxYearCount--;
                    }
                    writer.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing output to CSV: {ex.Message}");
        }
    }
}
