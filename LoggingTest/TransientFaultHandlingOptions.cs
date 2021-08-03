using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingTest
{
    // https://docs.microsoft.com/en-us/dotnet/core/extensions/options#bind-hierarchical-configuration
    /// <summary>
    /// When using the options pattern, an options class:
    /// Must be non-abstract with a public parameterless constructor
    /// Contain public read-write properties to bind(fields are not bound)
    /// </summary>
    internal class TransientFaultHandlingOptions
    {
        public bool Enabled { get; set; }
        public TimeSpan AutoRetryDelay { get; set; }
    }
}