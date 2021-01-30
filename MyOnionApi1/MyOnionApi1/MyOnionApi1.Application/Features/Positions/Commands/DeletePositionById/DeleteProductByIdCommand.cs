using MediatR;
using MyOnionApi1.Application.Exceptions;
using MyOnionApi1.Application.Interfaces.Repositories;
using MyOnionApi1.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace MyOnionApi1.Application.Features.Positions.Commands.DeletePositionById
{
    public class DeletePositionByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeletePositionByIdCommandHandler : IRequestHandler<DeletePositionByIdCommand, Response<int>>
        {
            private readonly IPositionRepositoryAsync _positionRepository;
            public DeletePositionByIdCommandHandler(IPositionRepositoryAsync positionRepository)
            {
                _positionRepository = positionRepository;
            }
            public async Task<Response<int>> Handle(DeletePositionByIdCommand command, CancellationToken cancellationToken)
            {
                var position = await _positionRepository.GetByIdAsync(command.Id);
                if (position == null) throw new ApiException($"Position Not Found.");
                await _positionRepository.DeleteAsync(position);
                return new Response<int>(position.Id);
            }
        }
    }
}
