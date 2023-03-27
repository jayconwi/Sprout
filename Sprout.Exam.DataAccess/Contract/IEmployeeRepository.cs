using Sprout.Exam.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Contract
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);
        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee> GetAsync(int id);
        void Update(Employee employee);
        Task Delete(int id);
        Task DeleteTemp(int id);
    }
}
