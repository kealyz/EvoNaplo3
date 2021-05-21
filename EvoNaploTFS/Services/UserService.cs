using EvoNaplo.DataAccessLayer;
using EvoNaploTFS.Models;
using EvoNaploTFS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Services
{
    public class UserService
    {
        private readonly EvoNaploContext _evoNaploContext;
        public UserService(EvoNaploContext EvoNaploContext)
        {
            _evoNaploContext = EvoNaploContext;
        }
        public IEnumerable<UserDTO> ListActiveStudents()
        {
            var students = _evoNaploContext.Users.Where(m => m.Role == User.RoleTypes.Student && m.IsActive == true);
            List<UserDTO> result = new List<UserDTO>();
            foreach (var student in students)
            {
                result.Add(new UserDTO(student));
            }
            return result;
        }
        public IEnumerable<UserDTO> ListActiveMentors()
        {
            var mentors = _evoNaploContext.Users.Where(m => m.Role == User.RoleTypes.Mentor && m.IsActive == true);
            List<UserDTO> result = new List<UserDTO>();
            foreach (var mentor in mentors)
            {
                result.Add(new UserDTO(mentor));
            }
            return result;
        }

        public IEnumerable<UserDTO> ListActiveAdmins()
        {
            var admins = _evoNaploContext.Users.Where(m => m.Role == User.RoleTypes.Admin && m.IsActive == true);
            List<UserDTO> result = new List<UserDTO>();
            foreach (var admin in admins)
            {
                result.Add(new UserDTO(admin));
            }
            return result;
        }


        public async Task<IEnumerable<User>> DeleteUser(int id)
        {
            var studentToDelete = await _evoNaploContext.Users.FindAsync(id);
            var role = studentToDelete.Role;
            _evoNaploContext.Users.Remove(studentToDelete);
            _evoNaploContext.SaveChanges();
            var students = _evoNaploContext.Users.Where(m => m.Role == role);
            return students.ToList();
        }
    }
}
