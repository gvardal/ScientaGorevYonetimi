namespace ScientaScheduler.MVC.Library.Dtos
{
    public class UYIsEmriDto
    {
        public long IsEmriID { get; set; }
        public string IsEmriKodu { get; set; } = string.Empty;
        public decimal UretimMiktari { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string IsEmriDurum { get; set; } = string.Empty;
    }


}
