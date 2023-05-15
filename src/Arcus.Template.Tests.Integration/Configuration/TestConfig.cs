using System;
using System.Collections.Generic;
using GuardNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Arcus.Template.Tests.Integration.Configuration
{
    /// <summary>
    /// Represents an <see cref="IConfiguration"/> implementation that encapsulates all necessary secrets and values required for this test suite.
    /// </summary>
    public class TestConfig : IConfiguration
    {
        private readonly IConfiguration _implementation;

        private TestConfig(IConfiguration implementation)
        {
            Guard.NotNull(implementation, nameof(implementation));
            _implementation = implementation;
        }

        /// <summary>
        /// Creates a new <see cref="TestConfig"/> implementation that encapsulates all necessary secrets and values required for this test suite.
        /// </summary>
        public static TestConfig Create()
        {
            // The appsettings.local.json allows users to override (gitignored) settings locally for testing purposes
            var config = new ConfigurationBuilder()
                .AddJsonFile(path: "appsettings.json")
                .AddJsonFile(path: "appsettings.local.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            return new TestConfig(config);
        }

        /// <summary>
        /// Gets a configuration sub-section with the specified key.
        /// </summary>
        /// <param name="key">The key of the configuration section.</param>
        /// <returns>The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationSection" />.</returns>
        /// <remarks>
        ///     This method will never return <c>null</c>. If no matching sub-section is found with the specified key,
        ///     an empty <see cref="T:Microsoft.Extensions.Configuration.IConfigurationSection" /> will be returned.
        /// </remarks>
        public IConfigurationSection GetSection(string key)
        {
            return _implementation.GetSection(key);
        }

        /// <summary>
        /// Gets the immediate descendant configuration sub-sections.
        /// </summary>
        /// <returns>The configuration sub-sections.</returns>
        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return _implementation.GetChildren();
        }

        /// <summary>
        /// Returns a <see cref="T:Microsoft.Extensions.Primitives.IChangeToken" /> that can be used to observe when this configuration is reloaded.
        /// </summary>
        /// <returns>A <see cref="T:Microsoft.Extensions.Primitives.IChangeToken" />.</returns>
        public IChangeToken GetReloadToken()
        {
            return _implementation.GetReloadToken();
        }

        /// <summary>
        /// Gets or sets a configuration value.
        /// </summary>
        /// <param name="key">The configuration key.</param>
        /// <returns>The configuration value.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when no value is found for the given <paramref name="key"/>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the test configuration token value is not yet replaced by a real value.</exception>
        public string this[string key]
        {
            get
            {
                string value = _implementation[key];
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new KeyNotFoundException(
                        $"Cannot find any test configuration value for the key: '{key}', please make sure that this key is specified in your (local and remote) 'appsettings.json' file");
                }

                if (value.StartsWith("#{") && value.EndsWith("}#"))
                {
                    throw new InvalidOperationException(
                        $"Cannot find configuration value for the key '{key}', as it is still having the token '{value}' and is not being replaced by the real value, " +
                        "please make sure to add a local alternative in the 'appsettings.local.json' file for the token with the real value required for this key");
                }

                return value;
            }
            set => _implementation[key] = value;
        }
    }
}
