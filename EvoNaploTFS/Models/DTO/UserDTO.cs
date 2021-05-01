using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Models.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string IsActive { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public UserDTO(User user)
        {
            IsActive = user.IsActive ? "Aktív" : "Inaktív";
            Name = $"{user.FirstName} {user.LastName}";
            Email = user.Email;
            if (!user.PhoneNumber.Equals(String.Empty))
            {
                PhoneNumber = user.PhoneNumber;
            }
            else
            {
                PhoneNumber = "-";
            }
        }
    }
}
