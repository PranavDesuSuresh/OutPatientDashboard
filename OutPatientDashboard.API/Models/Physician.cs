using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutPatientDashboard.API.Models
{
    public class Physician
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int NPI { get; set; }

        public int SpecialityId { get; set; }

        public Speciality? Speciality { get; set; }
    }
}