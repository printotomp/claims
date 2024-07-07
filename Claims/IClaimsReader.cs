using System;
using System.Collections.Generic;

namespace Claims
{
    /// <summary>
    /// Represents an interface for reading claims data from a file.
    /// </summary>
    public interface IClaimsReader
    {
        /// <summary>
        /// Reads claims data from the specified file path.
        /// </summary>
        /// <param name="filePath">The path to the claims data file.</param>
        /// <returns>A list of claims read from the file.</returns>
        List<Claim> ReadClaims(string filePath);
    }
}
