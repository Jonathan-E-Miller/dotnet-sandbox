namespace Sandbox.OpenGenerics
{
    internal class HelloResponse : IResponse
    {
        public DateTime ResponseTime { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
