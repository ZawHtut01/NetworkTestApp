using NetworkTestApp.Models;

namespace NetworkTestApp.Services
{
    public interface INetworkTestService
    {
        Task<NetworkTestResult> TestConnectionAsync(NetworkTestRequest request);
        Task<NetworkTestResult> PingAsync(string host, int timeout);
        Task<NetworkTestResult> CheckPortAsync(string host, int port, int timeout);
        Task<NetworkTestResult> TestHttpRequestAsync(string url, int timeout);
    }
}
