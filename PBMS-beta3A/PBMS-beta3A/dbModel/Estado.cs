using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Estado
    {
        public int ID              { get; set; }
        public string Descricao    { get; set; }
    }
    internal partial class Estado_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Estado>
    {
        public Estado_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Estados");
        }
    }
}

