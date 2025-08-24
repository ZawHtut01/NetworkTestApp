using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        [HttpPost("long-task")]
        public async Task<IActionResult> LongTask(CancellationToken cancellationToken)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Delay(1000, cancellationToken); // Simulate work (10 seconds total)
                    Console.WriteLine($"Step {i + 1}/10 completed");
                }

                return Ok("✅ Long process completed successfully.");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("⛔ Request was cancelled by the client.");
                return StatusCode(499, "Request was cancelled by the client.");
            }
        }
    }
}
