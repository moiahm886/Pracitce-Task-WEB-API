using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pracitce_Task.Data;
using Pracitce_Task.Models;

namespace Pracitce_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly MyAppDBContext myAppDBContext;

        public EmployeesController(MyAppDBContext myAppDBContext)
        {
            this.myAppDBContext = myAppDBContext;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var emp = await myAppDBContext.EMPLOYEE.ToListAsync();
                if (emp.Count == 0)
                {
                    return NotFound("Employee not found");
                }
                return Ok(emp);
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }
        }
        [HttpGet("{Ssn}")]
        public async Task<IActionResult> Get(string Ssn) 
        {
            try
            {
                var emp = await myAppDBContext.EMPLOYEE.FindAsync(Ssn);
                if (emp == null)
                {
                    return NotFound($"Employee not found with Ssm {Ssn}");
                }
                return Ok(emp);
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Employees Emp)
        {
            try
            {
                await myAppDBContext.AddAsync(Emp);
                await myAppDBContext.SaveChangesAsync();
                return Ok("Product created successfully");
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(Employees emp)
        {
            try
            {
                if (emp == null)
                {
                    if (emp == null)
                    {
                        return BadRequest("Employees unavailable");
                    }
       
                }
                var employee = await myAppDBContext.EMPLOYEE.FindAsync(emp.Ssn);
                if (employee == null)
                {
                    return NotFound($"Employee not found with Ssn {emp.Ssn}");
                }
                employee.Fname = emp.Fname;
                employee.Minit = emp.Minit;
                employee.Lname = emp.Lname;
                employee.Ssn = emp.Ssn;
                employee.Bdate = emp.Bdate;
                employee.Sex = emp.Sex;
                employee.Salary = emp.Salary;
                employee.Super_ssn = emp.Super_ssn;
                employee.Dno = emp.Dno;
                await myAppDBContext.SaveChangesAsync();
                return Ok("Updated Successfully");
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
        [HttpDelete("{Ssn}")]
        public async Task<IActionResult> Delete(string Ssn)
        {
            var employee = await myAppDBContext.EMPLOYEE.FindAsync(Ssn);
            if(employee == null)
            {
                return NotFound("Not Found");
            }
            myAppDBContext.EMPLOYEE.Remove(employee);
            await myAppDBContext.SaveChangesAsync();
            return Ok("Deleted Successfully");
        }
    }
    
}
