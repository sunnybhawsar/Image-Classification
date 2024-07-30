using ImageClassification.Service;
using ImageClassification.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ImageClassification.Host.Controllers
{
    [ApiController]
    [Route("api/v1.0/imageclassification")]
    public class ImageClassificationController : ControllerBase
    {
        private readonly IImageClassificationService _imageClassificationService;

        public ImageClassificationController(IImageClassificationService imageClassificationService)
        {
            _imageClassificationService = imageClassificationService;
        }

        [HttpPost]
        public async Task<IActionResult> ClassifyImagesAsync([FromBody] ImageClassificationRequest request)
        {
            var response = await _imageClassificationService.ClassifyImagesAsync(request);
            return response?.IsSuccessful == true ? Ok(response) : BadRequest(response);
        }
    }
}