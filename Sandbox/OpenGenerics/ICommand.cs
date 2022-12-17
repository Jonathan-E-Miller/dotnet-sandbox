namespace Sandbox.OpenGenerics
{
    public interface ICommandBase
    {
        IResponse Handle(IRequest request);
    }

    public interface ICommand<T> : ICommandBase
        where T: IRequest
    {
    }

    public interface IRequest
    {
        public string Message { get; set; }
    }

    public interface IResponse
    {
        public DateTime ResponseTime { get; set; }
        public string Message { get; set; }
    }
}
