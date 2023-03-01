using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class MemberModel
    {
        [Key]
        public Guid? IdMember { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, ErrorMessage = "Campul Name poate sa contina maxim 250 caractere.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(100, ErrorMessage = "Campul Title poate sa contina maxim 100 caractere.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(250, ErrorMessage = "Campul Position poate sa contina maxim 250 caractere.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(1000, ErrorMessage = "Campul Description poate sa contina maxim 1000 caractere.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public string Resume { get; set; }
    }
}
