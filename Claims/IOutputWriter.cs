using System;
using System.Collections.Generic;

namespace Claims
{
    /// <summary>
    /// Represents an interface for writing accumulated claim data to an output file.
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Writes accumulated claim data to the specified file path.
        /// </summary>
        /// <param name="accumulatedData">The list of accumulated claim data.</param>
        /// <param name="filePath">The path to the output file.</param>
        void WriteOutput(List<AccumulatedClaimData> accumulatedData, string filePath);
    }
}
