using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1API.Data;
using WebApplication1API.Models;

namespace WebApplication1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MyDBContext _dbcon;
        public StudentController(MyDBContext db) {
            _dbcon = db;
        }
        [HttpGet]
        public IActionResult StudentList()
        {
            var students = _dbcon.Students.ToList();

            return Ok(students);
        }
        [HttpGet("id")]
        public IActionResult StudentById(int id)
        {

            var students = _dbcon.Students.FirstOrDefault(st => st.Id == id);
            return Ok(students);
        }
        [HttpPost]
        public IActionResult StudentInsert(StudentInfo model)
        {
            var students = new StudentInfo
            {
                Name = model.Name,
                Gender = model.Gender,
                Address = model.Address
            };
            _dbcon.Add(students);
            _dbcon.SaveChanges();
            return Ok(students);
        }
        [HttpPut("id")]
        public IActionResult EditStudent(int id, [FromBody] StudentInfo model)
        {
            var studentToUpdate = _dbcon.Students.SingleOrDefault(s => s.Id == id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }
            studentToUpdate.Name = model.Name;
            studentToUpdate.Gender = model.Gender;
            studentToUpdate.Address = model.Address;

            _dbcon.SaveChanges();
            return Ok(studentToUpdate);
        }
        [HttpDelete("id")]
        public IActionResult DeleteStudent(int id)
        {
            var studentToDelete = _dbcon.Students.SingleOrDefault(s => s.Id == id);
            if (studentToDelete == null)
            {
                return NotFound();
            }
            _dbcon.Remove(studentToDelete);
            _dbcon.SaveChanges();
            return Ok(studentToDelete);
        }

    }
}
