﻿using LogWriter4.Core.Interface;
using LogWriter4.Logger;
using Ninject.Modules;
using Services.Interface;
using Services.Service;

namespace LogWriter4.DIModule
{
    class DebugModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<Log4NetLogger>().InSingletonScope();

            Bind<IMyFakeService>().To<MyFakeService>().InSingletonScope();
            Bind<IMyOtherService>().To<MyOtherService>().InSingletonScope();
        }
    }
}