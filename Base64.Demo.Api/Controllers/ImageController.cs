using Base64.Demo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Base64.Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<ImageController> _logger;

        public ImageController(ILogger<ImageController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ImageUpload image)
        {
            try
            {
                _logger.LogInformation($"Received an image upload with name: {image.Name}");
                var binary = Convert.FromBase64String(image.Data);
                var imagePath = Path.Combine(Path.GetTempPath(), image.Name);
                await System.IO.File.WriteAllBytesAsync(imagePath, binary);
                _logger.LogInformation($"Saved image to temp folder: {imagePath}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception thrown trying to convert base64 string to binary.");
                return BadRequest();
            }
        }
    }
}
