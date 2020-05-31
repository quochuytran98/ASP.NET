using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugStore.Models
{
    public partial class User
    {
        [Required(ErrorMessage ="không được bỏ trống")]
        public int Id_Customer { get; set; }
        [Required(ErrorMessage = "không được bỏ trống")]
        public String Username { get; set; }
        [Required(ErrorMessage = "không được bỏ trống")]
        [DataType(DataType.Password                                                      )]
        public String Password { get; set; }
        [Required(ErrorMessage = "không được bỏ trống")]
        [DataType(DataType.Password)]
        public String Repeat_Password { get; set; }
        [Required(ErrorMessage = "không được bỏ trống")]
        public String Name_Customer { get; set; }
        [Required(ErrorMessage = "không được bỏ trống")]
        public String Email_Customer { get; set; }
        [Required(ErrorMessage = "không được bỏ trống")]
        public int Phone_Customer { get; set; }
        [Required(ErrorMessage = "không được bỏ trống")]
        public String Address_Customer { get; set; }
        
    }
}