using AutoMapper;
using MyOnionApi1.Application.Features.Employees.Queries.GetEmployees;
using MyOnionApi1.Application.Features.Positions.Commands.CreatePosition;
using MyOnionApi1.Application.Features.Positions.Queries.GetPositions;
using MyOnionApi1.Domain.Entities;

namespace MyOnionApi1.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Position, GetPositionsViewModel>().ReverseMap();
            CreateMap<Employee, GetEmployeesViewModel>().ReverseMap();
            CreateMap<CreatePositionCommand, Position>();
        }
    }

}
