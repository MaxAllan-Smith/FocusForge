using System.Reflection;

namespace FocusForge.Application.Interfaces.MediatR
{
    public class Mediator(IServiceProvider serviceProvider) : IMediator
    {
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            Type handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            object handler = serviceProvider.GetService(handlerType)
                             ?? throw new InvalidOperationException($"Handler for {request.GetType().Name} not found.");

            MethodInfo handleMethod = handlerType.GetMethod("Handle")
                                      ?? throw new InvalidOperationException("Handle method not found.");

            object? result = handleMethod.Invoke(handler, [request]);

            return (Task<TResponse>)result!;
        }
    }
}
