using EvoNaplo.DataAccessLayer;
using EvoNaplo.Models;
using EvoNaplo.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaplo.Services
{
    public class MentorService
    {
        private readonly EvoNaploContext _evoNaploContext;
        private readonly ILogger<MentorService> _logger;

        public MentorService(ILogger<MentorService> logger, EvoNaploContext EvoNaploContext)
        {
            _logger = logger;
            _evoNaploContext = EvoNaploContext;
        }

        //Mentor hozzáadása. Ha van phone number akkor úgy hívja meg a konstruktort, egyébként anélkül
        public async Task<IEnumerable<User>> AddMentor(MentorDto mentorDto)
        {
            _logger.LogInformation($"Mentor hozzáadása következik: {mentorDto}");
            if (mentorDto.PhoneNumber != null)
            {
                await _evoNaploContext.Users.AddAsync(new User(mentorDto.Email, mentorDto.Password, mentorDto.FirstName, mentorDto.LastName, mentorDto.PhoneNumber, mentorDto.UserRole));
            }
            else
            {
                await _evoNaploContext.Users.AddAsync(new User(mentorDto.Email, mentorDto.Password, mentorDto.FirstName, mentorDto.LastName, mentorDto.UserRole));
            }
            _evoNaploContext.SaveChanges();
            _logger.LogInformation($"Mentor hozzáadva");
            var mentors = _evoNaploContext.Users.Where(m => m.Role == Role.Mentor);
            return mentors.ToList();
        }

        public IEnumerable<User> ListMentors()
        {
            var mentors = _evoNaploContext.Users.Where(m => m.Role == Role.Mentor);
            return mentors.ToList();

        }

        //public async Task<IEnumerable<User>> EditMentor(int id, MentorDto mentorDto)
        //{
        //    _logger.LogInformation($"{id} ID-vel rendelkező mentor keresése");
        //    var mentorToEdit = await _evoNaploContext.Users.FindAsync(id);
        //    _logger.LogInformation($"{id} ID-vel rendelkező mentor módosítása indul {mentorDto} adatokra");
        //    mentorToEdit.Email = mentorDto.Email;
        //    mentorToEdit.SetNewPassword(mentorDto.Password);
        //    mentorToEdit.FirstName = mentorDto.FirstName;
        //    mentorToEdit.LastName = mentorDto.LastName;
        //    mentorToEdit.PhoneNumber = mentorDto.PhoneNumber;
        //    _evoNaploContext.SaveChanges();
        //    _logger.LogInformation($"{id} ID-vel rendelkező mentor módosítása kész");
        //    var mentors = _evoNaploContext.Users.Where(m => m.Role == Role.Mentor);
        //    return mentors.ToList();
        //}

        //public async Task<IEnumerable<User>> InactivateMentor(int id)
        //{
        //    _logger.LogInformation($"{id} ID-vel rendelkező mentor keresése");
        //    var mentorToDelete = await _evoNaploContext.Users.FindAsync(id);
        //    _logger.LogInformation($"{id} ID-vel rendelkező mentor inaktiválása indul");
        //    mentorToDelete.IsActive = false;
        //    _evoNaploContext.SaveChanges();
        //    _logger.LogInformation($"{id} ID-vel rendelkező mentor inaktiválása kész");
        //    var mentors = _evoNaploContext.Users.Where(m => m.Role == Role.Mentor);
        //    return mentors.ToList();
        //}

        //public async Task<IEnumerable<User>> DeleteMentor(int id)
        //{
        //    _logger.LogInformation($"{id} ID-vel rendelkező mentor keresése");
        //    var mentorToDelete = await _evoNaploContext.Users.FindAsync(id);
        //    _logger.LogInformation($"{id} ID-vel rendelkező mentor törlése indul");
        //    _evoNaploContext.Users.Remove(mentorToDelete);
        //    _evoNaploContext.SaveChanges();
        //    _logger.LogInformation($"{id} ID-vel rendelkező mentor törlése kész");
        //    var mentors = _evoNaploContext.Users.Where(m => m.Role == Role.Mentor);
        //    return mentors.ToList();
        //}
    }
}
