using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.OpenGenerics.Handlers
{
    internal class HelloCommandHandler : CommandHandlerBase<HelloRequest, HelloResponse>
    {
        public override HelloResponse Handle(HelloRequest input)
        {
            return new HelloResponse()
            {
                Message = $"Echo {input.Message}",
                ResponseTime = DateTime.Now,
            };
        }
    }
}
