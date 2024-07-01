using BoardGame.Domain.Shared;
using MediatR;

namespace BoardGame.Application.Abstractions;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
{
    
}