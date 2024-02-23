using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.AppUserDtos
{
	public class AppUserChangePasswordDto
	{

        public string OldPassword { get; set; }

       
        public string Password { get; set; }

   
        public string ConfirmPassword { get; set; }
	}
}
