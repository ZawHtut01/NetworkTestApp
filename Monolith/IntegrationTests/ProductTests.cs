namespace IntegrationTests
{
    public class ProductTests
    {
        [Fact]
        public async Task GetProducts_ShouldReturnData()
        {
            var client = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };
            var response = await client.GetAsync("/api/products");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Name", content);
        }
    }
}
