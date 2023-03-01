using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class CodeSnippetModel
    {
        [Key]
        public Guid? IdCodeSnippet { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [StringLength(100, ErrorMessage = "Campul Title poate sa contina maxim 100 caractere.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public string ContentCode { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public Guid IdMember { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        [Range(0, int.MaxValue, ErrorMessage="Campul Revision trebuie sa fie pozitiv!")]
        public int Revision { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime DateTimeAdded { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public bool IsPublished { get; set; }
    }
}
