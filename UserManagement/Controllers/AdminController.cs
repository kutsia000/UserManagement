using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Core.Admin.Interfaces;
using UserManagement.Core.Auth.Interfaces;
using UserManagement.DataAccess.Common;
using UserManagement.DataAccess.ModelDTOs;

namespace UserManagement.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize(Roles = StaticUserRolesString.Admin)]
  public class AdminController : ControllerBase
  {
    private readonly IAdminService _adminService;
    private readonly IAuthService _authService;
    public AdminController(IAdminService adminService, IAuthService authService)
    {
      _adminService = adminService;
      _authService = authService;
    }

    [HttpPost("SetUserRole")]
    public async Task<IActionResult> SetUserRole([FromBody] SetUserRoleDTO model)
    {
      try
      {
        var user = await _authService.UserExistsById(model.UserId);
        if (user is null)
          return BadRequest("User does not exist");

        var role = DictionaryUserRoles.GetUserRole(model.RoleId).ToString();

        await _adminService.SetUserRole(user, role);

        return Ok();
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
      }
    }
  }
}
