﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DataAccess.ModelDTOs
{
  public class UpdatePermissionDTO
  {
    [Required]
    public string UserName { get; set; }
  }
}
