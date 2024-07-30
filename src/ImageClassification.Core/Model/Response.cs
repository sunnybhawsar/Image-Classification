namespace ImageClassification.Core.Model
{
    public class Response
    {
        public List<ImageClassificationDetails> ImageClassificationDetails { get; set; }
        public bool IsSuccessful { get; set; }
    }

    public class ImageClassificationDetails
    {
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public double ConfidenceScore { get; set; }
        public string Status { get; set; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<Info> AdditionalInfo { get; set; }
    }

    public class Info
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
