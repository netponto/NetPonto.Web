using System;
using System.Reflection;
using Autofac;
using Autofac.Integration.Web.Mvc;
using Module = Autofac.Module;

namespace NetPonto.Web.Modules
{
    public class WebModule : Module
    {
        private readonly Assembly _webAssembly;

        public WebModule(Assembly webAssembly)
        {
            _webAssembly = webAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(_webAssembly);

        }
    }
}