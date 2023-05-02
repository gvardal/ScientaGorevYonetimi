namespace ScientaScheduler.Library.DTO
{
    public class ScieantaRestDTO
    {
        public string? CariHesapID { get; set; } = string.Empty;
        public string? AramaMetni { get; set; } = string.Empty;
        public int? PageIndex { get; set; } = 0;
        public int? PageSize { get; set; } = 100;
        public string? CalisanID { get; set; } = string.Empty;
        public string? GirisAnahtari { get; set; } = string.Empty;
    }
}
