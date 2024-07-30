using ImageClassification.Service.Contract;

namespace ImageClassification.Service
{
    public interface IImageClassificationService
    {
        Task<ImageClassificationResponse> ClassifyImagesAsync(ImageClassificationRequest request);
    }
}
