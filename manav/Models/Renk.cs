using System.ComponentModel.DataAnnotations;

namespace manav.Models
{
    public class Renk
    {
        [Key]
        public int RenkID { get; set; }

        [Required(ErrorMessage = "Meyve Adı Boş Olamaz."), Display(Name = "Renk Adı"), StringLength(20, MinimumLength = 2, ErrorMessage = "Meyve Adı 2 - 20 Karakter olmalı")]
        public string RenkAdı { get; set; }



    }
}