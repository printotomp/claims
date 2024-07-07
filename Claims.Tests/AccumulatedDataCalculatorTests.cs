using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Claims.Tests
{
    public class AccumulatedDataCalculatorTests
    {
        [Fact]
        public void CalculateAccumulatedData_Should_Return_Empty_List_When_No_Claims()
        {
            // Arrange
            var calculator = new AccumulatedDataCalculator();
            var emptyClaimsList = new List<Claim>();

            // Act
            var result = calculator.CalculateAccumulatedData(emptyClaimsList);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void CalculateAccumulatedData_Should_Accumulate_IncrementalValues_Correctly()
        {
            // Arrange
            var calculator = new AccumulatedDataCalculator();
            var claims = new List<Claim>
            {
                new Claim { Product = "Comp", OriginYear = 2020, DevelopmentYear = 1, IncrementalValue = 100 },
                new Claim { Product = "Comp", OriginYear = 2020, DevelopmentYear = 2, IncrementalValue = 150 },
                new Claim { Product = "Non-Comp", OriginYear = 2021, DevelopmentYear = 1, IncrementalValue = 200 }
            };

            // Act
            var result = calculator.CalculateAccumulatedData(claims);

            // Assert
            Assert.Equal(100, result[0].IncrementalValue);
            Assert.Equal(250, result[1].IncrementalValue);
            Assert.Equal(200, result[2].IncrementalValue);
        }
    }
}
