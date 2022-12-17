namespace Sandbox.OpenGenerics.Handlers
{
    public class HelloCommandHandler : ICommand<HelloRequest>
    {
        public IResponse Handle(IRequest request)
        {
            return new HelloResponse()
            {
                Message = $"Echo {request.Message}",
                ResponseTime = DateTime.Now,
            };
        }
    }
}
