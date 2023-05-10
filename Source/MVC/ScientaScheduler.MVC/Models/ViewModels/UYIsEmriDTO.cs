namespace ScientaScheduler.MVC.Models.ViewModels
{
    public class UYIsEmriDTO
    {
        public long IsEmriID { get; set; }
        public string IsEmriKodu { get; set; } = string.Empty;
        public decimal UretimMiktari { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
    }
}
