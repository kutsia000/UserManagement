using Microsoft.AspNetCore.Identity;
using UserManagement.Core.Auth.Interfaces;
using UserManagement.DataAccess.Common;

namespace UserManagement.Infrastructure.Auth
{
  public class AuthRepository : IAuthRepository
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public AuthRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      _userManager = userManager;
      _roleManager = roleManager;
    }

    public async Task SeedRoles()
    {
      try
      {
        if (!_roleManager.RoleExistsAsync(StaticUserRoles.Admin.ToString()).Result)
          await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.Admin.ToString()));

        if (!_roleManager.RoleExistsAsync(StaticUserRoles.User.ToString()).Result)
          await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.User.ToString()));
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<IdentityUser> UserExistsByName(string userName)
    {
      return await _userManager.FindByNameAsync(userName);
    }

    public async Task<IdentityResult> Register(IdentityUser user, string password, string roleId)
    {
      try
      {
        var res = await _userManager.CreateAsync(user, password);
        var role = DictionaryUserRoles.GetUserRole(roleId).ToString();
        await _userManager.AddToRoleAsync(user, role);

        return res;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<bool> CheckPassword(IdentityUser user, string password)
    {
      return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<List<string>> GetUserRoles(IdentityUser user)
    {
      return await _userManager.GetRolesAsync(user) as List<string>;
    }

    public async Task<bool> CheckUserRole(IdentityUser user, string role)
    {
      return await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<IdentityUser> UserExistsById(string Id)
    {
      return await _userManager.FindByIdAsync(Id);
    }
  }
}
