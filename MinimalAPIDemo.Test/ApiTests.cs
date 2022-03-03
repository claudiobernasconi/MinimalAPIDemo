using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace MinimalAPIDemo.Test
{
  [TestClass]
  public class ApiTests
  {
    private HttpClient _httpClient;

    public ApiTests()
    {
      var webAppFactory = new WebApplicationFactory<Program>();
      _httpClient = webAppFactory.CreateDefaultClient();
    }

    [TestMethod]
    public async Task DefaultRoute_ReturnsHelloWorld()
    {
      var response = await _httpClient.GetAsync("");
      var stringResult = await response.Content.ReadAsStringAsync();

      Assert.AreEqual("Hello World!", stringResult);
    }

    [TestMethod]
    public async Task Sum_Returns16For10And6()
    {
      var response = await _httpClient.GetAsync("/sum?n1=10&n2=6");
      var stringResult = await response.Content.ReadAsStringAsync();
      var intResult = int.Parse(stringResult);

      Assert.AreEqual(16, intResult);
    }
  }
}