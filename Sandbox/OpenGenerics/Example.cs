using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Sandbox.OpenGenerics.Handlers;

namespace Sandbox.OpenGenerics
{
    internal static class Example
    {
        public static void Run()
        {
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

            // We can make the open generic a closed generic e.g. ICommand<HelloRequest>
            Type closed = t.MakeGenericType(request.GetType());

            // we can now get this service and cast to the IBaseCommand.
            var generatedHandler = serviceProvider.GetService(closed) as ICommandBase;

            // Here, we are calling the CommandHandlerBase "Handle" method, which then calls the abstract method
            // that is overriden in the handler.
            var generatedResponse = generatedHandler!.Handle(request);

            // Handle the response.
            Console.WriteLine($"response: {generatedResponse.Message} {generatedResponse.ResponseTime}");
        }

        public static void RunAutofacExample()
        {
            // Create the autofac builder.
            var builder = new ContainerBuilder();

            // register all closed types of the ICommand interface
            // Offical doc: https://autofac.org/apidoc/html/150314CB.htm
            // Stack Overflow: https://stackoverflow.com/questions/16757945/how-to-register-many-for-open-generic-in-autofac
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(ICommand<>)).AsImplementedInterfaces();

            var container = builder.Build();

            HelloRequest request = new HelloRequest()
            {
                Message = "Autofac example"
            };

            // Create an open generic
            Type t = typeof(ICommand<>);
            Type closed = t.MakeGenericType(request.GetType());

            using (var scope = container.BeginLifetimeScope())
            {
                var handler = scope.Resolve(closed) as ICommandBase;
                var response = handler!.Handle(request);

                Console.WriteLine($"response: {response.Message} {response.ResponseTime}");
            }

        }
    }
}
