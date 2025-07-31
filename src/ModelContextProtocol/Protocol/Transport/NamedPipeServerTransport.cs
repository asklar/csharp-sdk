using Microsoft.Extensions.Logging;
using System.IO.Pipes;

namespace ModelContextProtocol.Protocol.Transport;

/// <summary>
/// Provides an <see cref="ITransport"/> implemented via named pipes.
/// </summary>
public class NamedPipeServerTransport : StreamServerTransport
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NamedPipeServerTransport"/> class with explicit input/output streams.
    /// </summary>
    /// <param name="pipeName"></param>
    /// <param name="serverName"></param>
    /// <param name="loggerFactory"></param>
    public NamedPipeServerTransport(string pipeName, string? serverName = null, ILoggerFactory? loggerFactory = null)
        : base(new NamedPipeServerStream(pipeName), new NamedPipeClientStream(pipeName), serverName, loggerFactory)
    {
        PipeName = pipeName ?? throw new ArgumentNullException(nameof(pipeName));
    }

    /// <summary>
    /// The name of the named pipe used for communication.
    /// </summary>
    public string PipeName { get; }
}
