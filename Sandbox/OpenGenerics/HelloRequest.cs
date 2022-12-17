namespace Sandbox.OpenGenerics
{
    internal class HelloRequest : IRequest
    {
        public string Message { get; set; } = string.Empty;
    }
}
