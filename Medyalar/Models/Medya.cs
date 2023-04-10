using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medyalar.Models
{
    public class Medya
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Tur { get; set; }
        [Required]
        public string Kategori { get; set; }
        [Required]
        public string Baslik { get; set; }
        [Required]
        public string DosyaAdi { get; set; }

        public double DosyaBoyutu { get; set; }
        [Required]
        public int Sure { get; set; }
        
        public string Aciklama { get; set; }
        [Required]
        public bool isArchived { get; set; }
    }
}
