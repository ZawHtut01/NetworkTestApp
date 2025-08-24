namespace NetworkTestApp.Models
{
    public class NetworkTestResult
    {
        public bool Success { get; set; }   
        public string Message {  get; set; }
        public long ResponseTime {  get; set; }
        public DateTime TestTime {  get; set; }
        public string Host {  get; set; }
        public TestType TestType { get; set; }
    }
}
