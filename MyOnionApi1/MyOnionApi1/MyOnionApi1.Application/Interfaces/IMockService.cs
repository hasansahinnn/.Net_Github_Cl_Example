using MyOnionApi1.Domain.Entities;
using System.Collections.Generic;

namespace MyOnionApi1.Application.Interfaces
{
    public interface IMockService
    {
        List<Position> GetPositions(int rowCount);
        List<Employee> GetEmployees(int rowCount);
        List<Position> SeedPositions(int rowCount);
    }
}