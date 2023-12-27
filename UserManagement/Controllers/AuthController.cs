using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserManagement.Core.Auth.Interfaces;
using UserManagement.DataAccess.Common;
using UserManagement.DataAccess.ModelDTOs;
using UserManagement.Helpers;

namespace UserManagement.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IConfiguration _configuration;
    private readonly IAuthService _authService;
    public AuthController(IConfiguration configuration, IAuthService authService)
    {
      _configuration = configuration;
      _authService = authService;
    }

    [HttpPost("SeedRoles")]
    public async Task<IActionResult> SeedRoles()
    {
      try
      {
        await _authService.SeedRoles();
        return Ok();
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
      }
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {
      try
      {
        if (await _authService.UserExistsByName(registerDTO.UserName) is null)
          return BadRequest("User already exists");

        var result = await _authService.Register(registerDTO);

        if (!result.Succeeded)
          return BadRequest(result.Errors);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
      }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
      try
      {
        var user = await _authService.UserExistsByName(loginDTO.UserName);

        if (user is null)
          return BadRequest("Invalid Credentials");

        var isPasswordCorrect = await _authService.CheckPassword(user, loginDTO.Password);

        if (!isPasswordCorrect)
          return BadRequest("Invalid Password");

        var userRoles = await _authService.GetUserRoles(user);

        var claims = new List<Claim>
        {
          new(ClaimTypes.NameIdentifier, user.Id),
          new(ClaimTypes.Name, user.UserName),
          new(ClaimTypes.Email, user.Email),
          new(ClaimTypes.Role, userRoles[0]),
          new("JWTID",Guid.NewGuid().ToString())
        };

        foreach (var role in userRoles)
          claims.Add(new Claim(ClaimTypes.Role, role));

        var h = new JWTHelper(_configuration);
        var token = h.GenerateNewJwtToken(claims);

        return Ok(token);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
      }
    }

  }
}
