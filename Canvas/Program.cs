using Autofac;
using Canvas.Common;
using Canvas.Interfaces;

namespace Canvas
{
    class MainClass
    {
        private static IContainer Container { get; set; }
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<InputParser>().As<IParser>();
            builder.RegisterType<StartUp>().As<IStartUp>();
            builder.RegisterType<Components.MyCanvas>().As<ICanvas>().SingleInstance();
            builder.RegisterType<Components.Printer>().As<IPrinter>();
            Container = builder.Build();

            Run();
        }

        public static void Run()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var startUp = scope.Resolve<IStartUp>();
                startUp.Run();
            }
        }
    }
}
