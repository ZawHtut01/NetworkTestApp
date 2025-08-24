using Microsoft.AspNetCore.Mvc;
using NetworkTestApp.Models;
using NetworkTestApp.Services;

namespace NetworkTestApp.Controllers
{
    public class NetworkTestController : Controller
    {
        private readonly INetworkTestService _networkTestService;

        public NetworkTestController(INetworkTestService networkTestService)
        {
            _networkTestService = networkTestService;
        }

        public IActionResult Index()
        {
            return View(new NetworkTestRequest());
        }

        [HttpPost]
        public async Task<IActionResult> TestConnection(NetworkTestRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", request);
            }

            var result = await _networkTestService.TestConnectionAsync(request);
            ViewBag.Result = result;

            return View("Index", request);
        }

        [HttpGet]
        public async Task<IActionResult> QuickTest(string host = "google.com")
        {
            var request = new NetworkTestRequest { Host = host };
            var result = await _networkTestService.TestConnectionAsync(request);

            return Json(result);
        }
    }
}
