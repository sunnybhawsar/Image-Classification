using ImageClassification.Core.Model;

namespace ImageClassification.Core
{
    public interface IImageClassificationComponent
    {
        Task<Response> ClassifyImagesAsync(Request request);
    }
}
