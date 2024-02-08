using Autofac.Core;
using Core.Utilittes.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection collectionService)
        {
            collectionService.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
