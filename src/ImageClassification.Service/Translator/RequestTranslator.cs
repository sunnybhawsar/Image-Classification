using ImageClassification.Core.Model;
using ImageClassification.Service.Contract;

namespace ImageClassification.Service.Translator
{
    internal static class RequestTranslator
    {
        internal static Request ToModel(this ImageClassificationRequest imageClassificationRequest)
        {
            Request request = null;
            if (imageClassificationRequest != null)
            {
                request = new Request
                {
                    ImageUrls = imageClassificationRequest.ImageUrls
                };
            }
            return request;
        }
    }
}
