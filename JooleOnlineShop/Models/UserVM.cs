using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JooleOnlineShop.Models
{
    public class UserVM
    {
        [Required(ErrorMessage = "This filed is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This filed is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}