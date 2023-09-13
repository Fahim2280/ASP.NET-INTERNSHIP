using System.ComponentModel.DataAnnotations;


namespace Quad_Theory_Limited.Models
{
    public class Class
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime ModificationDate { get; set; }

        public virtual ICollection<Student>? Students { get; set; }
    }
}

