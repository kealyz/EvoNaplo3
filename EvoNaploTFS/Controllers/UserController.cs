using EvoNaploTFS.Models.DTO;
using EvoNaploTFS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaploTFS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService UserService)
        {
            _userService = UserService;
        }
        
        [HttpGet("Students")]
        public IEnumerable<UserDTO> GetStudent()
        {
            return _userService.ListActiveStudents();
        }

        [HttpGet("Mentors")]
        public IEnumerable<UserDTO> GetMentor()
        {
            return _userService.ListActiveMentors();
        }

        [HttpGet("Admins")]
        public IEnumerable<UserDTO> GetAdmin()
        {
            return _userService.ListActiveAdmins();
        }

        //Delete
        // api/Student/delete jsonben paramból id
        [HttpDelete("DELETE")]
        public async Task<int> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return StatusCodes.Status200OK;
        }
    }
}
