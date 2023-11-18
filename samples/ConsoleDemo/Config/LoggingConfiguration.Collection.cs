using System.Collections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsoleDemo.Config;

/// <summary>
/// Reconfigures <see cref="ILogger"/> and <see cref="ILogger{TCategoryName}"/> at runtime.
/// </summary>
public partial class LoggingConfiguration : ILoggingConfigurationProviderCollection
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1010:Opening square brackets should be spaced correctly", Justification = "Style cop isn't caught up yet.")]
    private readonly List<IConfigurationProvider> providers = [];

    /// <inheritdoc/>
    int ICollection<IConfigurationProvider>.Count => providers.Count;

    /// <inheritdoc/>
    bool ICollection<IConfigurationProvider>.IsReadOnly => ((ICollection<IConfigurationProvider>)providers).IsReadOnly;

    /// <inheritdoc/>
    void ICollection<IConfigurationProvider>.Add(IConfigurationProvider item) => providers.Add(item);

    /// <inheritdoc/>
    void ICollection<IConfigurationProvider>.Clear() => providers.Clear();

    /// <inheritdoc/>
    bool ICollection<IConfigurationProvider>.Contains(IConfigurationProvider item) => providers.Contains(item);

    /// <inheritdoc/>
    void ICollection<IConfigurationProvider>.CopyTo(IConfigurationProvider[] array, int arrayIndex) => providers.CopyTo(array, arrayIndex);

    /// <inheritdoc/>
    IEnumerator<IConfigurationProvider> IEnumerable<IConfigurationProvider>.GetEnumerator() => providers.GetEnumerator();

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)providers).GetEnumerator();

    /// <inheritdoc/>
    bool ICollection<IConfigurationProvider>.Remove(IConfigurationProvider item) => providers.Remove(item);
}
