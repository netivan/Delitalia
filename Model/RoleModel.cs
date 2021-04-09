using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelliItalia_Razor.Model
{
    public class RoleModel
    {
        [Required]
        [DisplayName("Roll/Behörighet:")]
        public string RoleName { get; set; }
    }
}
