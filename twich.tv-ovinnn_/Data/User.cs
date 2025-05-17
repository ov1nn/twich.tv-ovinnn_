using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace twich.tv_ovinnn_.Data
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("Key")]
        public int Id { get; set; }

        [Required]
        [Column("Username")]
        public string Username { get; set; }

        [Required]
        [Column("Password")]
        public string Password { get; set; }

        [Column("idAdmin")]
        public bool IsAdmin { get; set; }
    }
}
