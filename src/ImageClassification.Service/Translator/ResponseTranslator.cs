using ImageClassification.Core.Model;
using ImageClassification.Service.Contract;

namespace ImageClassification.Service.Translator
{
    internal static class ResponseTranslator 
    {
        internal static ImageClassificationResponse? ToContract(this Response response)
        {
            ImageClassificationResponse imageClassificationResponse = null;
            if(response != null)
            {
                imageClassificationResponse = new ImageClassificationResponse
                {
                    IsSuccessful = response.IsSuccessful,
                    ImageClassificationDetails = response.ImageClassificationDetails.ToContract()
                };
            }
            return imageClassificationResponse;
        }

        internal static List<Contract.ImageClassificationDetails>? ToContract(this List<Core.Model.ImageClassificationDetails> details)
        {
            List<Contract.ImageClassificationDetails> imageClassificationDetails = null;
            if(details != null && details.Any())
            {
                imageClassificationDetails = new List<Contract.ImageClassificationDetails>();
                foreach (var item in details)
                    imageClassificationDetails.Add(item.ToContract());
            }
            return imageClassificationDetails;
        }

        internal static Contract.ImageClassificationDetails? ToContract(this Core.Model.ImageClassificationDetails details)
        {
            Contract.ImageClassificationDetails imageClassificationDetails = null;
            if(details != null)
            {
                imageClassificationDetails = new Contract.ImageClassificationDetails
                {
                    ImageUrl = details.ImageUrl,
                    Category = details.Category,
                    ConfidenceScore = details.ConfidenceScore,
                    Status = details.Status,
                    Error = details.Error.ToContract()
                };
            }
            return imageClassificationDetails;
        }

        internal static Contract.Error? ToContract(this Core.Model.Error error)
        {
            Contract.Error errorDetails = null;
            if(error != null)
            {
                errorDetails = new Contract.Error
                {
                    Code = error.Code,
                    Message = error.Message,
                    AdditionalInfo = error.AdditionalInfo.ToContract()
                };
            }
            return errorDetails;
        }

        internal static List<Contract.Info>? ToContract(this List<Core.Model.Info> infos)
        {
            List<Contract.Info> additionalInfo = null;
            if(infos != null && infos.Any())
            {
                additionalInfo = new List<Contract.Info>();
                foreach (var info in infos)
                    additionalInfo.Add(info.ToContract());
            }
            return additionalInfo;
        }

        internal static Contract.Info? ToContract(this Core.Model.Info info)
        {
            Contract.Info infoDetails = null;
            if (info != null)
            {
                infoDetails = new Contract.Info
                {
                    Code = info.Code,
                    Message = info.Message
                };
            }
            return infoDetails;
        }
    }
}
