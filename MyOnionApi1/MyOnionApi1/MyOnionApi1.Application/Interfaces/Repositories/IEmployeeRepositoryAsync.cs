using MyOnionApi1.Application.Features.Employees.Queries.GetEmployees;
using MyOnionApi1.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyOnionApi1.Application.Interfaces.Repositories
{
    public interface IEmployeeRepositoryAsync : IGenericRepositoryAsync<Employee>
    {
        Task<IEnumerable<Entity>> GetPagedEmployeeReponseAsync(GetEmployeesQuery requestParameter);
    }
}
