
using System.Threading.Tasks;
using dotnetcore_ef_mysql_docker.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore_ef_mysql_docker.Controllers
{
    // Helper class to take care of db context injection.
    public class InjectedController: ControllerBase
    {
        protected readonly StudentContext _db;

        public InjectedController(StudentContext context)
        {
            _db = context;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController: InjectedController  
    {
        public DepartmentController(StudentContext context) : base(context) { }

        //Get department with given id.
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _db.Departments.FindAsync(id);
            if (department == default(Department))
            {
                return NotFound();
            }
            return Ok(department);
        }

        // Add a department to db.
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] Department department)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(department);
            await _db.SaveChangesAsync();
            return Ok(department.ID);
        }
    }
}

