﻿//using Microsoft.Practices.Unity;
//using System.Web.Http.Dependencies;

//namespace WebHost
//{
//    public class UnityDependencyResolver : UnityDependencyScope, IDependencyResolver
//    {
//        public UnityDependencyResolver(IUnityContainer container)
//            : base(container)
//        {
//        }

//        public IDependencyScope BeginScope()
//        {
//            var childContainer = Container.CreateChildContainer();

//            return new UnityDependencyScope(childContainer);
//        }
//    }
//}