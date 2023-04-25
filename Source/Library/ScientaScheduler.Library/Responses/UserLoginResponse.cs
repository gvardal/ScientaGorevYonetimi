namespace ScientaScheduler.Library.Responses
{
    public class UserLoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
