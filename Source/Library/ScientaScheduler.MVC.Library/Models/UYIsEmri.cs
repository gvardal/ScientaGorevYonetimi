using System.ComponentModel.DataAnnotations;

namespace ScientaScheduler.MVC.Library.Models
{
    public class UYIsEmri
    {
        [Key]
        public long? IsEmriId { get; set; }
        public byte? FirmaId { get; set; }
        public int? MusteriKodu { get; set; }
        public long? UretimPlaniId { get; set; }
        public long? KesimIsEmriId { get; set; }
        public decimal? KesimSuresi { get; set; }
        public decimal? KesilenMalzemeAgirligi { get; set; }
        public long? UstIsEmriId { get; set; }
        public string? IsEmriKodu { get; set; }
        public int? UrunId { get; set; }
        public byte? IsEmriTuruId { get; set; }
        public string? UretimTuru { get; set; }
        public int? SiparisNo { get; set; }
        public byte? IsEmriDurumId { get; set; }
        public string? Oncelik { get; set; }
        public decimal? UretimMiktari { get; set; }
        public decimal? StokRezervasyonMiktari { get; set; }
        public decimal? RezervasyonMiktari { get; set; }
        public decimal? StokMiktari { get; set; }
        public decimal? FireMiktari { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? GerceklesenBaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public DateTime? GerceklesenBitisTarihi { get; set; }
        public DateTime? TerminTarihi { get; set; }
        public decimal? GerceklesenSure { get; set; }
        public string? Aciklama { get; set; }
        public string? DurumNotu { get; set; }
        public string? UretimHatti { get; set; }
        public bool? IsEmriOnayi { get; set; }
        public int? Onaylayan { get; set; }
        public bool? Secili { get; set; }
        public bool? SenkronizeEdildi { get; set; }
        public DateTime? SenkronizasyonTarihi { get; set; }
        public string? SenkronizasyonAciklamasi { get; set; }
        public string? SenkronizasyonReferansi { get; set; }
        public int? EkleyenCalisanId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public int? DuzenleyenCalisanId { get; set; }
        public DateTime? DuzenlemeTarihi { get; set; }
        public int? SonErisenCalisanId { get; set; }
        public DateTime? SonErisimTarihi { get; set; }
    }
}
