using Microsoft.EntityFrameworkCore.Storage;
using Sprout.Exam.DataAccess.Concrete;
using Sprout.Exam.DataAccess.Contract;
using Sprout.Exam.DataAccess.Models;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess
{
    public class UnitOfWork
    {
        private SproutExamDbContext _dbContext;
        private IEmployeeRepository _employeeRepository;

        public UnitOfWork(SproutExamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEmployeeRepository Employees
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_dbContext);

                return _employeeRepository;
            }
        }


        public async Task<bool> SaveAllAsync()
        {
            using (IDbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                bool saveResult = await _dbContext.SaveChangesAsync() > 0;

                //await _dbContext.SaveChangesAsync();
                //if (Debugger.IsAttached)
                //    transaction.Rollback();
                //else

                transaction.Commit();

                return saveResult;
            }
        }
    }
}
