using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace twich.tv_ovinnn_.Data
{
    [Table("Groups")]
    public class Group
    {
        [Key]
        [Column("Key")]
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}