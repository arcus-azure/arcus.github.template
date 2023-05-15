using System;
using Arcus.Template.Tests.Integration.Configuration;
using Arcus.Testing.Logging;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Arcus.Template.Tests.Integration
{
    /// <summary>
    /// Represents a common integration test in the test suite with easy access to common much-used types.
    /// </summary>
    public abstract class IntegrationTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTest"/> class.
        /// </summary>
        /// <param name="testOutput">The xUnit test output writer to log diagnostic messages to the test output.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected IntegrationTest(ITestOutputHelper testOutput)
        {
            Configuration = TestConfig.Create();
            Logger = new XunitTestLogger(testOutput);
        }

        /// <summary>
        /// Gets the test configuration instance to retrieve values and secrets required to interact with any external resources.
        /// </summary>
        protected TestConfig Configuration { get; }
        
        /// <summary>
        /// Gets the logger instance to write diagnostic information messages during the test run.
        /// </summary>
        protected ILogger Logger { get; }
    }
}