﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EssentialTools.Models;
using Ninject;
using System.Web.Mvc;

namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernal;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernal = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernal.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernal.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernal.Bind<IValueCalculator>().To<LinqValueCalculator>();
        }
    }
}