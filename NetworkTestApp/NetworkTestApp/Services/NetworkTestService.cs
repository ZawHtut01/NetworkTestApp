using NetworkTestApp.Models;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace NetworkTestApp.Services
{
    public class NetworkTestService : INetworkTestService
    {
        public async Task<NetworkTestResult> TestConnectionAsync(NetworkTestRequest request)
        {
            return request.TestType switch
            {
                TestType.Ping => await PingAsync(request.Host, request.Timeout),
                TestType.PortCheck => await CheckPortAsync(request.Host, request.Port, request.Timeout),
                TestType.HttpRequest => await TestHttpRequestAsync(request.Host, request.Timeout),
                _ => new NetworkTestResult { Success = false, Message = "Invalid test type" }
            };
        }

        public async Task<NetworkTestResult> PingAsync(string host, int timeout)
        {
            try
            {
                using var ping = new Ping();
                var reply = await ping.SendPingAsync(host, timeout);

                return new NetworkTestResult
                {
                    Success = reply.Status == IPStatus.Success,
                    Message = reply.Status.ToString(),
                    ResponseTime = reply.RoundtripTime,
                    TestTime = DateTime.Now,
                    Host = host,
                    TestType = TestType.Ping
                };
            }
            catch (Exception ex)
            {
                return new NetworkTestResult
                {
                    Success = false,
                    Message = ex.Message,
                    TestTime = DateTime.Now,
                    Host = host,
                    TestType = TestType.Ping
                };
            }
        }

        public async Task<NetworkTestResult> CheckPortAsync(string host, int port, int timeout)
        {
            try
            {
                using var client = new TcpClient();
                var task = client.ConnectAsync(host, port);
                var timeoutTask = Task.Delay(timeout);

                var completedTask = await Task.WhenAny(task, timeoutTask);

                if (completedTask == timeoutTask)
                {
                    return new NetworkTestResult
                    {
                        Success = false,
                        Message = "Connection timeout",
                        TestTime = DateTime.Now,
                        Host = $"{host}:{port}",
                        TestType = TestType.PortCheck
                    };
                }

                return new NetworkTestResult
                {
                    Success = client.Connected,
                    Message = client.Connected ? "Port is open" : "Port is closed",
                    ResponseTime = 0,
                    TestTime = DateTime.Now,
                    Host = $"{host}:{port}",
                    TestType = TestType.PortCheck
                };
            }
            catch (Exception ex)
            {
                return new NetworkTestResult
                {
                    Success = false,
                    Message = ex.Message,
                    TestTime = DateTime.Now,
                    Host = $"{host}:{port}",
                    TestType = TestType.PortCheck
                };
            }
        }

        public async Task<NetworkTestResult> TestHttpRequestAsync(string url, int timeout)
        {
            try
            {
                using var httpClient = new HttpClient { Timeout = TimeSpan.FromMilliseconds(timeout) };
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                var response = await httpClient.GetAsync(url);
                stopwatch.Stop();

                return new NetworkTestResult
                {
                    Success = response.IsSuccessStatusCode,
                    Message = $"HTTP {response.StatusCode}",
                    ResponseTime = stopwatch.ElapsedMilliseconds,
                    TestTime = DateTime.Now,
                    Host = url,
                    TestType = TestType.HttpRequest
                };
            }
            catch (Exception ex)
            {
                return new NetworkTestResult
                {
                    Success = false,
                    Message = ex.Message,
                    TestTime = DateTime.Now,
                    Host = url,
                    TestType = TestType.HttpRequest
                };
            }
        }
    }
}