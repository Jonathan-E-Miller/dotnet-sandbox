using Microsoft.Extensions.DependencyInjection;
using Sandbox.OpenGenerics.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.OpenGenerics
{
    internal static class Example
    {
        public static void Run()
        {
            HelloCommandHandler handler = new HelloCommandHandler();
            var response = handler.Handle(new HelloRequest());
            Console.WriteLine(response.Message);

            var type = typeof(ICommand<>);
            
            // Here we are setting up our DI. We are saying that any ICommand<HelloRequest> use the HelloCommandHandler.
            // In other DI containers (autofac, castle windsor) it is possible to register all closed versions of an interface
            // in a single line.
            var serviceProvider = new ServiceCollection()
                .AddScoped<ICommand<HelloRequest>, HelloCommandHandler>()
                .BuildServiceProvider();

            // Create an open generic
            Type t = typeof(ICommand<>);

            // Imagine we had a method that received a request, we need to get the correct handler for the request.
            var request = new HelloRequest();

            // WE can make the open generic a closed generic e.g. ICommand<HelloRequest>
            Type closed = t.MakeGenericType(request.GetType());

            // we can now get this service and cast to the IBaseCommand.
            var generatedHandler = serviceProvider.GetService(closed) as ICommandBase;

            // Here, we are calling the CommandHandlerBase "Handle" method, which then calls the abstract method
            // that is overriden in the handler.
            var generatedResponse = generatedHandler!.Handle(request);

            // Handle the response.
            Console.WriteLine($"response: {generatedResponse.Message} {generatedResponse.ResponseTime}");
        }
    }
}
