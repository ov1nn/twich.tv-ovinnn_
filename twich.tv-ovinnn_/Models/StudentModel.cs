using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using twich.tv_ovinnn_.Data;

namespace twich.tv_ovinnn_.Models
{
    public class StudentModel
    {
        [Required(ErrorMessage = "Имя не введено")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Фамилия")]
        public string Surname { get; set; }

        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Дата не введена")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "Группа не выставлена")]
        public int Group { get; set; }
    }
}
