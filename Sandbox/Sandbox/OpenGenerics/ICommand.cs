using Sandbox.OpenGenerics.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
