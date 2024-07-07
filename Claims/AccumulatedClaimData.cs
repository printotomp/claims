using System;

namespace Claims
{
    /// <summary>
    /// Represents accumulated claim data for a specific product and origin year.
    /// </summary>
    public class AccumulatedClaimData
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string? Product { get; set; }

        /// <summary>
        /// Gets or sets the origin year.
        /// </summary>
        public int OriginYear { get; set; }

        /// <summary>
        /// Gets or sets the DevelopmentYear year.
        /// </summary>
        public int DevelopmentYear { get; set; }

        /// <summary>
        /// Gets or sets the incremental value associated with the claim data.
        /// </summary>
        public double IncrementalValue { get; set; }
    }
}
