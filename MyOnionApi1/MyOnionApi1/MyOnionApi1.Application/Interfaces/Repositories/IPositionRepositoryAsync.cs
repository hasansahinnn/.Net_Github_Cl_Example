using MyOnionApi1.Application.Features.Positions.Queries.GetPositions;
using MyOnionApi1.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyOnionApi1.Application.Interfaces.Repositories
{
    public interface IPositionRepositoryAsync : IGenericRepositoryAsync<Position>
    {
        Task<bool> IsUniquePositionNumberAsync(string positionNumber);
        Task<bool> SeedDataAsync(int rowCount);
        Task<IEnumerable<Entity>> GetPagedPositionReponseAsync(GetPositionsQuery requestParameters);
    }
}
