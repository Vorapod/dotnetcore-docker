using System.Threading.Tasks;
using dotnetcore_ef_mysql_docker.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore_ef_mysql_docker.Controllers
{
    [Route("/api/[controller]")]
    public class StudentController: InjectedController
    {
        public StudentController(StudentContext context): base(context) {}

        //Get student with id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if(student == default(Student))
            {
                return NotFound();
            }
            
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dept = await _db.Departments.FindAsync(student.DepartmentID);
            if (dept == null)
            {
                ModelState.AddModelError("Department ID", $"Department {student.DepartmentID} does not exist");
                return BadRequest(ModelState);
            }

            await _db.AddAsync(student);
            await _db.SaveChangesAsync();
            return Ok(new { StudentID = student.ID });
        }

    }
}