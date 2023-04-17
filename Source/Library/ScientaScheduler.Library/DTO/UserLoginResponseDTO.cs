namespace ScientaScheduler.Library.DTO
{
    public class UserLoginResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public int CalisanID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string GirisAnahtari { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
