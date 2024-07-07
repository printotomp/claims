using System;
using System.Collections.Generic;

namespace Claims.Interfaces
{
    /// <summary>
    /// Represents an interface for calculating accumulated claim data.
    /// </summary>
    public interface IAccumulatedDataCalculator
    {
        /// <summary>
        /// Calculates accumulated claim data based on a list of claims.
        /// </summary>
        /// <param name="claims">The list of claims.</param>
        /// <returns>A list of accumulated claim data.</returns>
        List<AccumulatedClaimData> CalculateAccumulatedData(List<Claim> claims);
    }
}
