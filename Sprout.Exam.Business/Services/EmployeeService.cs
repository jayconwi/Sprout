using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess;
using Sprout.Exam.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services
{
    public class EmployeeService
    {
        private UnitOfWork _unitOfWork;
        public EmployeeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employeeList = await _unitOfWork.Employees.GetAllAsync();

            return employeeList.Select(e => new EmployeeDto() // I'd normally use AutoMapper on this kind of scenario
            {
                Id = e.Id,
                FullName = e.FullName,
                Birthdate = e.Birthdate.ToShortDateString(),   
                Tin = e.Tin,
                TypeId = e.EmployeeTypeId
            });

        }

        public async Task<EmployeeDto> GetAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetAsync(id);

            return new EmployeeDto() 
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Birthdate = employee.Birthdate.ToString("yyyy-MM-dd"),
                Tin = employee.Tin,
                TypeId = employee.EmployeeTypeId
            };
        }

        public async Task<int> Create(CreateEmployeeDto employee)
        {
            var nextEmployee = new Employee()
            {
                FullName = employee.FullName,
                Birthdate = employee.Birthdate,
                Tin = employee.Tin,
                EmployeeTypeId = employee.TypeId
            };


            _unitOfWork.Employees.Create(nextEmployee);


            if (await _unitOfWork.SaveAllAsync())
                return nextEmployee.Id;

            return -1;
        }

        public async Task<EmployeeDto> Update(EditEmployeeDto employee)
        {
            var modEmployee = await _unitOfWork.Employees.GetAsync(employee.Id);
            modEmployee.FullName = employee.FullName;
            modEmployee.Birthdate = employee.Birthdate;
            modEmployee.Tin = employee.Tin;
            modEmployee.EmployeeTypeId = employee.TypeId;

            _unitOfWork.Employees.Update(modEmployee);

            if (await _unitOfWork.SaveAllAsync())
                return new EmployeeDto()
                {
                    Id = modEmployee.Id,
                    FullName = modEmployee.FullName,
                    Birthdate = modEmployee.Birthdate.ToString("yyyy-MM-dd"),
                    Tin = modEmployee.Tin,
                    TypeId = modEmployee.EmployeeTypeId
                };

            return null;
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _unitOfWork.Employees.DeleteTemp(id);

            if (await _unitOfWork.SaveAllAsync())
                return id;

            return -1;
        }

        public decimal CalculateRegular(int absentDays)
        {
            decimal monthlyBasicSalary = 20000M;
            decimal net = monthlyBasicSalary - ((monthlyBasicSalary / 22) * absentDays) - (monthlyBasicSalary * 0.12M);

            return decimal.Round(net, 2, MidpointRounding.AwayFromZero);
        }

        public decimal CalculateContractual(decimal workedDays)
        {
            decimal dayRate = 500M;
            decimal net = dayRate * workedDays;

            return decimal.Round(net, 2, MidpointRounding.AwayFromZero);
        }

    }
}
