using System.Collections.Generic;

namespace UserManagement.DataAccess.Common
{
  public static class DictionaryUserRoles
  {
    private static readonly Dictionary<string, StaticUserRoles> userRoles = new()
    {
      { "8cb7a002-2713-4302-bca4-f0332f4ce335", StaticUserRoles.Admin },
      { "d10158d9-adb7-403c-a896-15f79b0d49fc", StaticUserRoles.User }
    };

    public static StaticUserRoles GetUserRole(string roleId)
    {
      return !string.IsNullOrEmpty(roleId) && userRoles.TryGetValue(roleId, out var value) ? value : StaticUserRoles.User;
    }

    public static string GetUserRoleId(StaticUserRoles role)
    {
      return userRoles.ContainsValue(role) ? userRoles.FirstOrDefault(x => x.Value == role).Value.ToString() : string.Empty;
    }
  }
}