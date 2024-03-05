using System.ComponentModel.DataAnnotations;

namespace UserManageAPI.Models
{
    public class AddUserRequest
    {
        [Required]
        public string Name { get; set; }
        public double Age { get; set; }

        public int Sex { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public string Location { get; set; }
    }
}
