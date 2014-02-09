using LogWriter4.Core.Interface;
using LogWriter4.Logger;
using Ninject.Modules;
using Services.Interface;
using Services.Service;

namespace LogWriter4.DIModule
{
    class ProductionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<ConsoleLogger>().InSingletonScope()
                .WithConstructorArgument("loglevel", LogLevelEnum.Fatal);

            Bind<IMyFakeService>().To<MyFakeService>().InSingletonScope();
            Bind<IMyOtherService>().To<MyOtherService>().InSingletonScope();
        }
    }
}
