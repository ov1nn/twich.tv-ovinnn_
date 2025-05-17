using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace twich.tv_ovinnn_.Data
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [Column("Key")]
        [Display(Name = "ID", Prompt = "Enter ID")]
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        public string Username { get; set; }

        [Required]
        [Column("Surname")]
        public string Surname { get; set; }

        [Column("MiddleName")]
        public string? MiddleName { get; set; }

        [Column("Birthday")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [ForeignKey("Group")]
        [Column("Group_key")]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
