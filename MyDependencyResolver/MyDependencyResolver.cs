using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyDependencyResolverService
{
    public class MyDependencyResolver : IDependencyResolver
    {
        IUnityContainer _container;
        public MyDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }
        public object GetService(Type serviceType)
        {
           return _container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType);
        }
    }
}
