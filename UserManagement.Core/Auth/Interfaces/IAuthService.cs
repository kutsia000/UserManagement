using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.DataAccess.ModelDTOs;

namespace UserManagement.Core.Auth.Interfaces
{
  public interface IAuthService
  {
    public Task SeedRoles();
    public Task<IdentityUser> UserExistsByName(string userName);
    public Task<IdentityUser> UserExistsById(string Id);
    public Task<IdentityResult> Register(RegisterDTO registerDTO);
    public Task<bool> CheckPassword(IdentityUser user, string password);
    public Task<List<string>> GetUserRoles(IdentityUser user);
    public Task<bool> CheckUserRole(IdentityUser user, string role);
  }
}
