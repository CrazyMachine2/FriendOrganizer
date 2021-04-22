using System.ComponentModel.DataAnnotations;

namespace FriendOrganizer.Model
{
    public class FriendPhoneNumber
    {

        public int ID { get; set; }

        [Phone]
        [Required]
        public string Number { get; set; }

        public int FriendID { get; set; }

        public Friend Friend { get; set; }
    }
}
