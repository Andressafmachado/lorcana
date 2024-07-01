using BoardGame.Domain.Shared;
using MediatR;

namespace BoardGame.Application.Abstractions;

public interface ICommand : IRequest<Result>
{
    
}

public interface ICommand<T> : IRequest<Result<T>>
{
    
}