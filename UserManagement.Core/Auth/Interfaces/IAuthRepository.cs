using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Core.Auth.Interfaces
{
  public interface IAuthRepository
  {
    public Task SeedRoles();
    public Task<IdentityUser> UserExistsByName(string userName);
    public Task<IdentityUser> UserExistsById(string Id);
    public Task<IdentityResult> Register(IdentityUser user, string password, string roleId);
    public Task<bool> CheckPassword(IdentityUser user, string password);
    public Task<List<string>> GetUserRoles(IdentityUser user);
    public Task<bool> CheckUserRole(IdentityUser user, string role);
  }
}
