using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pracitce_Task.Data;
using Pracitce_Task.Models;
namespace Pracitce_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly MyAppDBContext DB;

        public DepartmentController(MyAppDBContext DB)
        {
            this.DB = DB;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var depart = await DB.DEPARTMENT.ToListAsync();
                if (depart.Count == 0)
                {
                    return NotFound("Employee not found");
                }
                return Ok(depart);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
        [HttpGet]
        [Route("api/[controller]/{Dnumber}")]
        public async Task<IActionResult> Get(int Dnumber)
        {
            try
            {
                var depart = await DB.DEPARTMENT.FindAsync(Dnumber);
                if (depart == null)
                {
                    return NotFound($"Department not found with Dnumber {Dnumber}");
                }
                return Ok(depart);
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Department dep)
        {
            try
            {
                await DB.DEPARTMENT.AddAsync(dep);
                await DB.SaveChangesAsync();
                return Ok("Product created successfully");
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(Department dep)
        {
            try
            {
                if (dep == null)
                {
                    return BadRequest("Employees unavailable");
                }
                var depart = await DB.DEPARTMENT.FindAsync(dep.Dnumber);
                if (depart == null)
                {
                    return NotFound($"Department not found with Dnumber {dep.Dnumber}");
                }
                depart.Dname = dep.Dname;
                depart.Dnumber = dep.Dnumber;
                depart.Mgr_ssn  = dep.Mgr_ssn;
                depart.Mgr_start_date = dep.Mgr_start_date;
                await DB.SaveChangesAsync();
                return Ok("Updated Successfully");
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
        [HttpDelete("{Dnumber}")]
        public async Task<IActionResult> Delete(int Dnumber)
        {
            var depart = await DB.DEPARTMENT.FindAsync(Dnumber);
            if (depart == null)
            {
                return NotFound("Not Found");
            }
            DB.DEPARTMENT.Remove(depart);
            await DB.SaveChangesAsync();
            return Ok("Deleted Successfully");
        }
    }
}
