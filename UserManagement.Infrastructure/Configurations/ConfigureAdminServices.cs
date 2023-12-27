using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.Admin.Interfaces;
using UserManagement.Infrastructure.Admin;
using UserManagement.Application.Admin;

namespace UserManagement.Infrastructure.Configurations
{
  public static class ConfigureAdminServices
  {
    public static IServiceCollection AddAminServices(this IServiceCollection services)
    {
      services.AddScoped<IAdminService, AdminService>();
      services.AddScoped<IAdminRepository, AdminRepository>();

      return services;
    }
  }
}
