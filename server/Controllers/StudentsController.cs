using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static List<Student> STUDENTS = new List<Student>
        {
            new Student { id = 1, fname = "Zipi", lname = "Lindenfeld", address = "כהנמן 83 א בני ברק", phone = "0556776310", isActive = false, avgMarks = 98},
            new Student{ id = 2, fname = "Ruth", lname = "Hershler", address = "פתח תקווה", phone = "0533137873", isActive = true, avgMarks = 99 },
            new Student { id = 3, fname = "aaa", lname = "Lindenfeld", address = "בני ברק", phone = "0556776310", isActive = false, avgMarks = 98 },
            new Student{ id = 4, fname = "bbb", lname = "Hershler", address = "פתח תקווה", phone = "0533137873", isActive = true, avgMarks = 99 },
            new Student { id = 5, fname = "ccc", lname = "Lindenfeld", address = "כהנמן 83", phone = "0556776310", isActive = false, avgMarks = 88 },
            new Student{ id = 6, fname = "ddd", lname = "Hershler", address = "פתח תקווה", phone = "0533137873", isActive = true, avgMarks = 9 }
        };

        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return STUDENTS;
        }

        // GET api/<TasksController>/5
        [HttpGet("active={active}")]
        public IEnumerable<Student> Get(bool active)
        {
            if (active)
                return STUDENTS.Where(s => s.isActive);
            return STUDENTS;
        }
        [HttpGet("name={name}")]
        public IEnumerable<Student> Get(string name)
        {
            return STUDENTS.Where(s => s.fname.Equals(name) || s.lname.Equals(name));
        }

        // POST api/<TasksController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            STUDENTS.Add(student);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student value)
        {
            Student student = STUDENTS.Find(s => s.id == id);
            if (student != null)
            {
                student.phone = value.phone;
                student.isActive = value.isActive;
                student.address = value.address;
                student.lname = value.lname;
                student.fname = value.fname;
                return Ok();
            }
            return BadRequest("student is null!");
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var student = STUDENTS.Find(s => s.id == id);
            STUDENTS.Remove(student);
            if (!STUDENTS.Contains(student))
                return true;
            return false;
        }
    }
}
