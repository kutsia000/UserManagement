using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.Admin.Interfaces;

namespace UserManagement.Infrastructure.Admin
{
  public class AdminRepository : IAdminRepository
  {
    private readonly UserManager<IdentityUser> _userManager;
    public AdminRepository(UserManager<IdentityUser> userManager)
    {
      _userManager = userManager;
    }
    public async Task SetUserRole(IdentityUser user, string roleId)
    {
      try
      {       
        await _userManager.AddToRoleAsync(user, roleId);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
