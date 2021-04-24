using EvoNaplo.DataAccessLayer;
using EvoNaplo.Models;
using EvoNaplo.Models.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaplo.Services
{
    public class StudentService
    {
        private readonly EvoNaploContext _evoNaploContext;
        private readonly ILogger<StudentService> _logger;

        public StudentService(ILogger<StudentService> logger, EvoNaploContext EvoNaploContext)
        {
            _logger = logger;
            _evoNaploContext = EvoNaploContext;
        }

        //Student hozzáadása. Ha van phone number akkor úgy hívja meg a konstruktort, egyébként anélkül
        public async Task<IEnumerable<User>> AddStudent(StudentDto studentDto)
        {
            _logger.LogInformation($"Diák hozzáadása következik: {studentDto}");
            if (studentDto.PhoneNumber != null)
            {
                await _evoNaploContext.Users.AddAsync(new User(studentDto.Email, studentDto.Password, studentDto.FirstName, studentDto.LastName, studentDto.PhoneNumber, studentDto.UserRole));
            }
            else
            {
                await _evoNaploContext.Users.AddAsync(new User(studentDto.Email, studentDto.Password, studentDto.FirstName, studentDto.LastName, studentDto.UserRole));
            }
            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"Diák hozzáadva");
            var students = _evoNaploContext.Users.Where(m => m.Role == Role.Student);
            return students.ToList();
        }

        public IEnumerable<User> ListStudents()
        {
            var students = _evoNaploContext.Users.Where(m => m.Role == Role.Student);
            //var students = _evoNaploContext.Users;
            return students.ToList();

        }

        //public async Task<IEnumerable<User>> EditStudent(int id, StudentDto studentDto)
        //{
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák keresése");
        //    var studentToEdit = await _evoNaploContext.Users.FindAsync(id);
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák módosítása indul {studentDto} adatokra");
        //    studentToEdit.Email = studentDto.Email;
        //    studentToEdit.SetNewPassword(studentDto.Password);
        //    studentToEdit.FirstName = studentDto.FirstName;
        //    studentToEdit.LastName = studentDto.LastName;
        //    studentToEdit.PhoneNumber = studentDto.PhoneNumber;
        //    _evoNaploContext.SaveChanges();
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák módosítása kész");
        //    var students = _evoNaploContext.Users.Where(m => m.Role == Role.Student);
        //    return students.ToList();
        //}

        //public async Task<IEnumerable<User>> InactivateStudent(int id)
        //{
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák keresése");
        //    var studentToDelete = await _evoNaploContext.Users.FindAsync(id);
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák inaktiválása indul");
        //    studentToDelete.IsActive = false;
        //    _evoNaploContext.SaveChanges();
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák inaktiválása kész");
        //    var students = _evoNaploContext.Users.Where(m => m.Role == Role.Student);
        //    return students.ToList();
        //}

        //public async Task<IEnumerable<User>> DeleteStudent(int id)
        //{
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák keresése");
        //    var studentToDelete = await _evoNaploContext.Users.FindAsync(id);
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák törlése indul");
        //    _evoNaploContext.Users.Remove(studentToDelete);
        //    _evoNaploContext.SaveChanges();
        //    _logger.LogInformation($"{id} ID-vel rendelkező diák törlése kész");
        //    var students = _evoNaploContext.Users.Where(m => m.Role == Role.Student);
        //    return students.ToList();
        //}
    }
}
