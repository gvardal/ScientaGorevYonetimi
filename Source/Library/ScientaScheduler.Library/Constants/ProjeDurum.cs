namespace ScientaScheduler.Library.Constants
{
    public class ProjeDurum
    {
        public Dictionary<int, string> Durum = new();

        public ProjeDurum()
        {
            Durum.Clear();
            Durum.Add(0, "Onayda");
            Durum.Add(1, "Red Edildi");
            Durum.Add(2, "Kontrol");
            Durum.Add(3, "Okunacak");
            Durum.Add(4, "Başladı");
            Durum.Add(5, "Durduruldu");
            Durum.Add(7, "Ertelendi");
            Durum.Add(6, "Bekliyor");
            Durum.Add(8, "Tamamlandı");
            Durum.Add(9, "İptal Edildi");
        }
    }
}
