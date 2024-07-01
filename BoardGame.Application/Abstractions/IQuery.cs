using BoardGame.Domain.Shared;
using MediatR;

namespace BoardGame.Application.Abstractions;

public interface IQuery<TResponse> :IRequest<Result<TResponse>>
{
    
}