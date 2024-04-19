using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.dbModel
{
    public class Contrato
    {
        public Int32 ID         { get; set; }

        public Cliente Cliente  { get; set; }
        public int Id_Cliente   { get; set; }

        public Referencia clausa_1 { get; set; }
        public Referencia clausa_2 { get; set; }
        public Referencia clausa_3 { get; set; }
        public Referencia clausa_4 { get; set; }
        public Referencia clausa_5 { get; set; }
        public int clausa_6  { get; set; }
        public int clausa_7  { get; set; }
        public int clausa_8  { get; set; }
        public int clausa_9  { get; set; }
        public int clausa_10 { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime Data { get; set; }
    }

    internal partial class Contrato_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Contrato>
    {
        public Contrato_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Contratos");
            this.HasRequired(t => t.Cliente).WithMany().HasForeignKey(t => t.Id_Cliente);
        }
    }
}