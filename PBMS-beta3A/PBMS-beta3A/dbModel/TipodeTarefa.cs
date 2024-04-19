using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class TipodeTarefa
    {
        public int ID             { get; set; }
        public string Descricao   { get; set; }
    }
    internal partial class TipodeTarefa_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TipodeTarefa>
    {
        public TipodeTarefa_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("TipodeTarefas");
        }
    }
}