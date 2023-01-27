using System.ComponentModel.DataAnnotations;

namespace manav.Models
{
    public class Meyve
    {
        [Key]
        public int MeyveID { get; set; }

        [Required(ErrorMessage ="Meyve Adı Boş Olamaz."),Display(Name = "Meyve Adı"),StringLength(20,MinimumLength =2,ErrorMessage ="Meyve Adı 2 - 20 Karakter olmalı")]
        public string MeyveAdı { get; set; }


        [Required(ErrorMessage = "Kategori Boş Olamaz."), Display(Name = "Kategori"), Range(1,1000,ErrorMessage ="{0} seçilmedi.")]
        public int KategoriID { get; set; }

        [Required(ErrorMessage = "Renk Boş Olamaz."), Display(Name = "Renk"), Range(1, 1000, ErrorMessage = "{0} seçilmedi.")]
        public int RenkID { get; set; }







        public Kategori Kategori { get; set; }

        public Renk Renk { get; set; } 
    }
}
