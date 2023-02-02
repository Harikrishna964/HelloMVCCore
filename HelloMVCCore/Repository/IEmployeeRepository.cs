using HelloCoreMvc.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HelloCoreMvc.Repository
{
    interface IEmployeeRepository
    {
        DbSet<Employee> GetEmployees();
        Task<Employee> GetEmployee(int employeeId);
    }
}