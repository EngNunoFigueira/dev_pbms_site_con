using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Mes
    {
        public int ID                  { get; set; }
        public string NomeDoMes        { get; set; }
    }
    internal partial class Mes_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Mes>
    {
        public Mes_configuration()
        {
            this.HasKey(a => a.ID);
            this.ToTable("Meses");
        }
    }
}