using HMS.Application;
using HMS.Application.Shared.Common.Interfaces;
using HMS.Application.Shared.Interfaces;
using HMS.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.API.Dependencies
{
    public static class DependencyInjection
    {
        private static IServiceCollection _services;

        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            _services = services;

            //_services.AddScoped<IRepository, Repository>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            _services.AddTransient<ITestAppService, TestAppService>();
            _services.AddTransient<IRoomAppService, RoomAppService>();
            _services.AddTransient<ILocationAppService, LocationAppService>();
            _services.AddTransient<IUserAppService, UserAppService>();


            return _services;
        }
    }
}
