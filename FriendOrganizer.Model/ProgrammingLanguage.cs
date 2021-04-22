using System.ComponentModel.DataAnnotations;

namespace FriendOrganizer.Model
{
    public class ProgrammingLanguage
    {

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
