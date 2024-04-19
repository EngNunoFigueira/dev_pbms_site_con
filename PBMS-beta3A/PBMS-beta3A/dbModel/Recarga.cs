using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.dbModel
{
    public class Recarga
    {
        public Int32 ID                    { get; set; }
        public int UTT                     { get; set; }
        public string CodigoRecarga        { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DataCompra         { get; set; }

        public InfoSimCard InfoSimCard     { get; set; }
        public Int32 Id_InfoSimCard        { get; set; }
        public int Feedback                { get; set; }
    }

    internal partial class Recarga_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Recarga>
    {
        public Recarga_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Recargas");
            this.HasRequired(t => t.InfoSimCard).WithMany().HasForeignKey(t => t.Id_InfoSimCard);
        }
    }
}