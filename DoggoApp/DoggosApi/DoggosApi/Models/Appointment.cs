using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace DoggosApi.Models
{
    [Table("Appointments")]
    [Index(nameof(Uuid), IsUnique = true)]
    public class Appointment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Range(11111111111,99999999999)]
        [DataType("long")]
        public long Uuid { get; set; }
        public string? Name { get; set; }
        public int? BreedID { get; set; }
        public Breed? Breed { get; internal set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public int? Length { get; set; }
        public int? Weight { get; set; }

        public Appointment()
        {

        }
    }
}
