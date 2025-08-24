namespace NetworkTestApp.Models
{
    public class NetworkTestRequest
    {
        public string Host { get; set; } = "google.com";
        public int Timeout { get; set; } = 1000;
        public int Port { get; set; } = 80;
        public TestType TestType { get; set; } = TestType.Ping;

    }

    public enum TestType
    {
        Ping,
        PortCheck,
        HttpRequest
    }

}

