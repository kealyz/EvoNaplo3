﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvoNaplo.Models;
using EvoNaplo.Models.DTO;
using EvoNaplo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService StudentService)
        {
            _studentService = StudentService;
        }

        // Add
        // api/Student + studentDto megadása Postman body-ban
        [HttpPost]
        public async Task<int> PostAddStudent(StudentDto studentDto)
        {
            await _studentService.AddStudent(studentDto);
            return StatusCodes.Status200OK;
        }

        // Get
        // api/Student
        [HttpGet]
        public IEnumerable<User> GetStudent()
        {
            return _studentService.ListStudents();
        }

        //PUT
        // api/Student/edit jsonben paramból id és bodyból studentDto
        [HttpPut("edit")]
        public async Task<int> PutEditStudent(int id, StudentDto studentDto)
        {
            await _studentService.EditStudent(id, studentDto);
            return StatusCodes.Status200OK;
        }

        //PUT
        // api/Student/inactivate jsonben paramból id
        [HttpPut("inactivate")]
        public async Task<int> PutInactivateStudent(int id)
        {
            await _studentService.InactivateStudent(id);
            return StatusCodes.Status200OK;
        }

        //Delete
        // api/Student/delete jsonben paramból id
        [HttpDelete("delete")]
        public async Task<int> DeleteStudent(int id)
        {
            await _studentService.DeleteStudent(id);
            return StatusCodes.Status200OK;
        }
    }
}