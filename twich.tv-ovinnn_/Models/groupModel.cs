using System.ComponentModel.DataAnnotations;

namespace twich.tv_ovinnn_.Models
{
    public class GroupModel
    {
        [Required(ErrorMessage = "Группа не введена")]
        public string Name { get; set; }

        
    }
}
