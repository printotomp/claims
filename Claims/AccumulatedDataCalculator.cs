using System;
using System.Collections.Generic;
using System.Linq;
using Claims.Interfaces;

namespace Claims
{
    public class AccumulatedDataCalculator : IAccumulatedDataCalculator
    {
        public List<AccumulatedClaimData> CalculateAccumulatedData(List<Claim> claims)
        {
            var accumulatedData = new List<AccumulatedClaimData>();
            double incValue = 0;

            try
            {
                foreach (var claim in claims)
                {
                    var existingData = accumulatedData
                        .FirstOrDefault(d => d.Product == claim.Product && d.OriginYear == claim.OriginYear);

                    if (existingData == null)
                    {
                        incValue = claim.IncrementalValue;

                        accumulatedData.Add(new AccumulatedClaimData
                        {
                            Product = claim.Product,
                            OriginYear = claim.OriginYear,
                            DevelopmentYear = claim.DevelopmentYear,
                            IncrementalValue = claim.IncrementalValue
                        });
                    }
                    else
                    {
                        incValue += claim.IncrementalValue;

                        accumulatedData.Add(new AccumulatedClaimData
                        {
                            Product = claim.Product,
                            OriginYear = claim.OriginYear,
                            DevelopmentYear = claim.DevelopmentYear,
                            IncrementalValue = incValue
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it or throw a custom exception)
                Console.WriteLine($"Error calculating accumulated data: {ex.Message}");
            }

            return accumulatedData;
        }
    }
}
