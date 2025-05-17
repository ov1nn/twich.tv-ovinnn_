using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace twich.tv_ovinnn_.Data
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        [Column("Key")]
        public int Id { get; set; }

        [Required]
        [Column("Название")]
        public string Name { get; set; }
    }
}
