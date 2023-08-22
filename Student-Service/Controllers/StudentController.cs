using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Service.Models;

namespace Student_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        IStudentRepo _repo;
        public StudentController(IStudentRepo repo)
        {

            _repo = repo;

        }

        [HttpGet]
        public IActionResult Get()
        {
            if (_repo.GetStudents() == null)
                return NotFound();
            else
                return Ok(_repo.GetStudents());
        }


        
        [HttpPost]
        public IActionResult Create(Student student)
        {

            Student temp = _repo.AddStudent(student);
            return Created("Ok", temp);
        }

        [HttpPut("{id}")]
        public IActionResult EditStudent(int id, Student student)
        {
            return Ok(_repo.UpdateStudent(id, student));
        }

        [HttpDelete("{id}")]
        public IActionResult DelStudent(int id)
        {
            return Ok(_repo.DeleteStudent(id));
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            Student obj = _repo.StudentGetStudentById(id);
            if (obj == null)
                return NotFound();
            else
                return Ok(obj);
        }


    }
}
