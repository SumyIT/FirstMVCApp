using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class MembershipModel
    {
        [Key]
        public Guid? IdMembership { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public Guid? IdMember { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public Guid? IdMembershipType { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Acest camp este obligatoriu!!!")]
        public int Level { get; set; }
    }
}
