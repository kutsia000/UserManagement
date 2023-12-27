namespace UserManagement.DataAccess.Common
{
  public enum StaticUserRoles
  {
    Admin,
    User
  }

  public class StaticUserRolesString
  {
    public const string Admin = nameof(StaticUserRoles.Admin);
    public const string User = nameof(StaticUserRoles.User);
  }
}