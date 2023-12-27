using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Core.Admin.Interfaces
{
  public interface IAdminRepository
  {
    public Task SetUserRole(IdentityUser user, string roleId);
  }
}
