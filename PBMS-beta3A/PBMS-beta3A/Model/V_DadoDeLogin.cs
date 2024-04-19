using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PBMS_beta3A.Model
{
    public class V_DadoDeLogin
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string PasswordSalt { get; set; }
    }
}