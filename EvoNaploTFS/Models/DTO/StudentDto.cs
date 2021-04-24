﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoNaplo.Models.DTO
{
    public class StudentDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Role UserRole = Role.Student;

        public StudentDto()
        {

        }

        //Constructor with phone number
        public StudentDto(string email, string password, string firstName, string lastName, string phoneNumber)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        //Constructor without phone number
        public StudentDto(string email, string password, string firstName, string lastName)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return ($"{Email}-{Password}-{FirstName}-{LastName}-{PhoneNumber}-{UserRole}");
        }

    }
}
