namespace ScientaScheduler.Library.Constants
{
    public class OlayTuru
    {
        public Dictionary<int, string>  OlayTur = new();

        public OlayTuru()
        {
            OlayTur.Clear();
            OlayTur.Add(1, "Görev");
            OlayTur.Add(2, "Randevu");
            OlayTur.Add(3, "Araç Talebi");
            OlayTur.Add(4, "DÖF");
            OlayTur.Add(5, "Toplantı Faaliyeti");
            OlayTur.Add(6, "Proje Faaliyeti");
            OlayTur.Add(7, "İstek");
            OlayTur.Add(8, "Şikayet");
            OlayTur.Add(9, "Taşeron");
            OlayTur.Add(10, "Kilometretaşı");
            OlayTur.Add(11, "Çoklu Görev");
        }


    }
}
