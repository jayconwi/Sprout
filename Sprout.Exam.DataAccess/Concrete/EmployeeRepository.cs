using Microsoft.EntityFrameworkCore;
using Sprout.Exam.DataAccess.Contract;
using Sprout.Exam.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Concrete
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(SproutExamDbContext dbContext) : base(dbContext)
        {
 
        }
 
        public void Create(Employee employee)
        {
            base.Create(employee);
        }
       
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await FindByCondition(e => e.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            return await FindByCondition(e => e.Id == id && e.IsDeleted == false)
                .FirstOrDefaultAsync();
        }


        public void Update(Employee employee)
        {
            base.Update(employee);
        }

        public async Task Delete(int id)
        {
            var employee = await FindByCondition(e => e.Id == id)
                .FirstOrDefaultAsync();

            base.Delete(employee);
        }

        public async Task DeleteTemp(int id)
        {
            var employee = await FindByCondition(e => e.Id == id)
                .FirstOrDefaultAsync();

            employee.IsDeleted = true;

            base.Update(employee);
        }
    }
}
