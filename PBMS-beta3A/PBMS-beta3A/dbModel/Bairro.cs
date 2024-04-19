using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.dbModel
{         
    public class Bairro
    {
        public  Int32  ID                   { get; set; }
        public string Nome                  { get; set; }
        public  Municipio Municipio         { get; set; }
        public int Id_Municipio             { get; set; }
    }

    internal partial class Bairro_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Bairro>
    {
        public Bairro_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Bairros");

            this.HasRequired(t => t.Municipio).WithMany().HasForeignKey(t => t.Id_Municipio);
        }
    }
     
  }