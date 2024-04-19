using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PBMS_beta3A.dbModel
{
    public class DadoDeLogin
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(200000)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(20000)]
        public string PasswordSalt { get; set; }
    }

    internal partial class DadoDeLogin_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DadoDeLogin>
    {
        public DadoDeLogin_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("DadoDeLogins");
        }
    }
}