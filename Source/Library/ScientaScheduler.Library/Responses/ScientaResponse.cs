namespace ScientaScheduler.Library.Responses
{
    public class ScientaResponse<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public int? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public List<T>? Data { get; set; }
    }
}
