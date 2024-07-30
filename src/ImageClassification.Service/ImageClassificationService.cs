using ImageClassification.Core;
using ImageClassification.Service.Contract;
using ImageClassification.Service.Translator;

namespace ImageClassification.Service
{
    public class ImageClassificationService : IImageClassificationService
    {
        private readonly IImageClassificationComponent _imageClassificationComponent;
        public ImageClassificationService(IImageClassificationComponent imageClassificationComponent)
        {
            _imageClassificationComponent = imageClassificationComponent;
        }

        public async Task<ImageClassificationResponse> ClassifyImagesAsync(ImageClassificationRequest imageClassificationRequest)
        {
            var response = await _imageClassificationComponent.ClassifyImagesAsync(imageClassificationRequest.ToModel());
            return response.ToContract();
        }
    }
}