using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.Auth.Interfaces;
using UserManagement.DataAccess.ModelDTOs;

namespace UserManagement.Application.Auth
{
  public class AuthService : IAuthService
  {
    private readonly IAuthRepository _authRepository;
    public AuthService(IAuthRepository authRepository)
    {
      _authRepository = authRepository;
    }

    public async Task SeedRoles()
    {
      await _authRepository.SeedRoles();
    }

    public async Task<IdentityUser> UserExistsByName(string userName)
    {
      return await _authRepository.UserExistsByName(userName);
    }

    public async Task<IdentityResult> Register(RegisterDTO registerDTO)
    {
      var newUser = new IdentityUser
      {
        UserName = registerDTO.UserName,
        Email = registerDTO.Email,
        SecurityStamp = Guid.NewGuid().ToString()
      };

      return await _authRepository.Register(newUser, registerDTO.Password, registerDTO.RoleId);
    }

    public async Task<bool> CheckPassword(IdentityUser user, string password)
    {
      return await _authRepository.CheckPassword(user, password);
    }

    public async Task<List<string>> GetUserRoles(IdentityUser user)
    {
      return await _authRepository.GetUserRoles(user);
    }

    public async Task<bool> CheckUserRole(IdentityUser user, string role)
    {
      return await _authRepository.CheckUserRole(user, role);
    }

    public async Task<IdentityUser> UserExistsById(string Id)
    {
      return await _authRepository.UserExistsById(Id);
    }
  }
}
