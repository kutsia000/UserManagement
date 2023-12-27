using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Auth;
using UserManagement.Core.Auth.Interfaces;
using UserManagement.Infrastructure.Auth;

namespace UserManagement.Infrastructure.Configurations
{
  public static class ConfigureAuthServices
  {
    public static IServiceCollection AddAuthServices(this IServiceCollection services)
    {
      services.AddScoped<IAuthService, AuthService>();
      services.AddScoped<IAuthRepository, AuthRepository>();
      return services;
    }
  }
}
