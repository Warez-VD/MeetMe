using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using Ninject;

namespace MeetMe.Web.App_Start
{
    public class SignalRConfig : DefaultDependencyResolver
    {
        private readonly IKernel kernel;

        public SignalRConfig(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public override object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType) ?? base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType).Concat(base.GetServices(serviceType));
        }
    }
}