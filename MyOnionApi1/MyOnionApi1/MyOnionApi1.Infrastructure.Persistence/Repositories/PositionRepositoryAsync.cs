﻿using LinqKit;
using Microsoft.EntityFrameworkCore;
using MyOnionApi1.Application.Features.Positions.Queries.GetPositions;
using MyOnionApi1.Application.Interfaces;
using MyOnionApi1.Application.Interfaces.Repositories;
using MyOnionApi1.Domain.Entities;
using MyOnionApi1.Infrastructure.Persistence.Contexts;
using MyOnionApi1.Infrastructure.Persistence.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace MyOnionApi1.Infrastructure.Persistence.Repositories
{
    public class PositionRepositoryAsync : GenericRepositoryAsync<Position>, IPositionRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Position> _positions;
        private IDataShapeHelper<Position> _dataShaper;
        private readonly IMockService _mockData;



        public PositionRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Position> dataShaper, IMockService mockData) : base(dbContext)
        {
            _dbContext = dbContext;
            _positions = dbContext.Set<Position>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }

        public async Task<bool> IsUniquePositionNumberAsync(string positionNumber)
        {
            return await _positions
                .AllAsync(p => p.PositionNumber != positionNumber);
        }
        public async Task<bool> SeedDataAsync(int rowCount)
        {

            foreach (Position position in _mockData.GetPositions(rowCount))
            {
                await this.AddAsync(position);

            }
            return true;
        }

        public async Task<IEnumerable<Entity>> GetPagedPositionReponseAsync(GetPositionsQuery requestParameter)
        {
            var positionNumber = requestParameter.PositionNumber;
            var positionTitle = requestParameter.PositionTitle;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            var result = _positions
                .AsNoTracking()
                .AsExpandable()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            // filter
            FilterByColumn(ref result, positionNumber, positionTitle);
            // order by
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                result = result.OrderBy(orderBy);
            }
            // query field limit
            if (!string.IsNullOrWhiteSpace(fields))
            {
                result = result.Select<Position>("new(" + fields + ")");
            }
            // retrieve data to list
            var resultData = await result.ToListAsync();
            // shape data
            return _dataShaper.ShapeData(resultData, fields);

        }
        private void FilterByColumn(ref IQueryable<Position> positions, string positionNumber, string positionTitle)
        {
            if (!positions.Any())
                return;

            if (string.IsNullOrEmpty(positionTitle) && string.IsNullOrEmpty(positionNumber))
                return;

            var predicate = PredicateBuilder.New<Position>();

            if (!string.IsNullOrEmpty(positionNumber))
                predicate = predicate.And(p => p.PositionNumber.Contains(positionNumber.Trim()));

            if (!string.IsNullOrEmpty(positionTitle))
                predicate = predicate.And(p => p.PositionTitle.Contains(positionTitle.Trim()));

            positions = positions.Where(predicate);
        }
    }
}
