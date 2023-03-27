using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Services;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.WebApp.Filters;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionFilter))]
    public class EmployeesController : ControllerBase
    {
        private EmployeeService _employeeService;


        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employeeList = await _employeeService.GetAllAsync();
            return Ok(employeeList);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetAsync(id);
            return Ok(employee);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto input)
        {
            var employee = await _employeeService.Update(input);
            return Ok(employee);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto input)
        {
            var id = await _employeeService.Create(input);

            return Created($"/api/employees/{id}", id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteAsync(id);
            return Ok(result);
        }


        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> Calculate(CalculateDto calculate)
        {
            var employee = await _employeeService.GetAsync(calculate.Id);

            if (employee == null) 
                return NotFound();

            var type = (EmployeeType)employee.TypeId;

            return type switch
            {
                EmployeeType.Regular => 
                    Ok(_employeeService.CalculateRegular(calculate.AbsentDays)),
                EmployeeType.Contractual => 
                    Ok(_employeeService.CalculateContractual(calculate.WorkedDays)),
                _ => NotFound("Employee Type not found")
            };

        }

    }
}
