﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DataAccess.ModelDTOs
{
  public class SetUserRoleDTO
  {
    [Required]
    public string UserId { get; set; }
    [Required]
    public string RoleId { get; set; }
  }
}
