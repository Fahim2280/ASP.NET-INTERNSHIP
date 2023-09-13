using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quad_Theory_Limited.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime ModificationDate { get; set; }

        public virtual Class? Classes { get; set; }
       
       
    }
}