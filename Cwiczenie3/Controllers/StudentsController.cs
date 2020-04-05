using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenie3.Models;
using Cwiczenie3.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenie3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy = "Nazwisko")
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            Student student = _dbService.GetStudent(id);
            if (student is null)
            {
                return NotFound("Brak studenta o podanym id.");
            } else
            {
                return Ok(student);
            }

        }

        //[Route("api/students{id}")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            Student foundStudent = _dbService.GetStudent(id);

            if(foundStudent is null)
            {
                return NotFound("Brak studenta o podanym id.");
            } else
            {
                _dbService.Put(id, student);
                return Ok("Student zaktualizowant.");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student foundStudent = _dbService.GetStudent(id);

            if(foundStudent is null)
            {
                return NotFound("Brak studenta o podanym id.");
            } else
            {
                _dbService.Delete(id);
                return Ok("Usuwanie ukończone.");
            }
        }
    }
}