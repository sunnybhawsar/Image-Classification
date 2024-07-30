using ImageClassification.Adapter;
using ImageClassification.Core.Model;

namespace ImageClassification.Core
{
    public class ImageClassificationComponent : IImageClassificationComponent
    {
        private readonly IImageClassificationAdapter _imageClassificationAdapter;
        public ImageClassificationComponent(IImageClassificationAdapter imageClassificationAdapter)
        {
            _imageClassificationAdapter = imageClassificationAdapter;
        }

        public async Task<Response> ClassifyImagesAsync(Request request)
        {
            Response response = new Response();

            try
            {
                if (request?.ImageUrls?.Any() == true)
                {
                    response.ImageClassificationDetails = await ClassifyAsync(request.ImageUrls);
                    response.IsSuccessful = true;
                }
                else
                {
                    response.IsSuccessful = false;
                }
            }
            catch
            {
                response.IsSuccessful |= false;
            }

            return response;
        }

        private async Task<List<ImageClassificationDetails>> ClassifyAsync(List<string> imageUrls)
        {
            List<ImageClassificationDetails> details = new List<ImageClassificationDetails>();

            Parallel.ForEach(imageUrls,
            new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
            async (imageUrl) =>
            {
                details.Add(await CategorizeAsync(imageUrl));
            });

            return details;
        }

        private Task<ImageClassificationDetails> CategorizeAsync(string imageUrl)
        {
            var details = new ImageClassificationDetails();
            details.ImageUrl = imageUrl;

            return Task.FromResult(details);
        }
    }
}