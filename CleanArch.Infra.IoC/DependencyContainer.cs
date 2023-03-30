using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Data.Context;
using CleanArch.Data.Repository;
using CleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterDepandancy(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}
