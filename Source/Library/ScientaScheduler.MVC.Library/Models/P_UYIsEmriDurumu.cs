using System.ComponentModel.DataAnnotations;

namespace ScientaScheduler.MVC.Library.Models
{
    public class P_UYIsEmriDurumu
    {
        [Key]
        public byte IsEmriDurumID { get; set; }
        public string Durum { get; set; } = string.Empty;
    }
}
