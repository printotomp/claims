using System;

namespace Claims
{
    /// <summary>
    /// Represents a claim data entry.
    /// </summary>
    public class Claim
    {
        /// <summary>
        /// Gets or sets the product associated with the claim.
        /// </summary>
        public string? Product { get; set; }

        /// <summary>
        /// Gets or sets the origin year of the claim.
        /// </summary>
        public int OriginYear { get; set; }

        /// <summary>
        /// Gets or sets the development year of the claim.
        /// </summary>
        public int DevelopmentYear { get; set; }

        /// <summary>
        /// Gets or sets the incremental value associated with the claim.
        /// </summary>
        public double IncrementalValue { get; set; }
    }
}
