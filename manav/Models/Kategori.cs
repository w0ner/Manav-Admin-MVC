using System.ComponentModel.DataAnnotations;

namespace manav.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }


        [Required(ErrorMessage = "Meyve Adı Boş Olamaz."), Display(Name = "Kategori"), StringLength(20, MinimumLength = 2, ErrorMessage = "Meyve Adı 2 - 20 Karakter olmalı")]
        public string KategoriAdı { get; set; }
    }
}