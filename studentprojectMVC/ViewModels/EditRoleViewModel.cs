using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace studentprojectMVC.ViewModels
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter the appropriate role name")]
        [Display(Name = "Selected Role Name")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}