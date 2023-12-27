using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.Admin.Interfaces;

namespace UserManagement.Application.Admin
{
  public class AdminService : IAdminService
  {
    private readonly IAdminRepository _adminRepository;
    public AdminService(IAdminRepository adminRepository)
    {
      _adminRepository = adminRepository;
    }
    public async Task SetUserRole(IdentityUser user, string roleId)
    {
      await _adminRepository.SetUserRole(user, roleId);
    }
  }
}
