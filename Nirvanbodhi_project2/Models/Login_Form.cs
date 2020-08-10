using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nirvanbodhi_project2.Models
{
    public class Login_Form
    {
        public enum gender
        {
            MALE, FEMALE
        }
        [Required(ErrorMessage = "Please enter the UserName")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter the Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter the Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public gender Gender { get; set; }

    }
}
