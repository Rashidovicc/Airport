using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Employees;
using AirportSystem.Service.DTO_s.Employees;

namespace AirportSystem.Service.Interfaces.IEmployeeServices
{
    public interface IEmployeeService
    {
        Task<Employee> CreateAsync(EmployeeForCreation employeeForCreation);
        Task<Employee> UpdateAsync(long id, EmployeeForCreation employeeForCreation);
        Task<bool> DeleteAsync(Expression<Func<Employee, bool>> expression);
        Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> expression = null,Tuple<int,int> pagination =null);
        Task<Employee> GetAsync(Expression<Func<Employee, bool>> expression);
        Task<bool> CheckLoginAsync(string username, string password);
        Task<Employee> ChangePasswordAsync(EmployeeForChangePassword forChangePassword);
        Task<Employee> GivingBonus(Expression<Func<Employee, bool>> expression);

    }
}