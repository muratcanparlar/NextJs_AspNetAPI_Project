using MediatR;

namespace Ginosis.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;