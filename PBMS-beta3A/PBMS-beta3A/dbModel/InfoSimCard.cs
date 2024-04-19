using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.dbModel
{
    public class InfoSimCard
    {
        public Int32 ID                                       { get; set; }
        public string Numero                                  { get; set; }
        public int PinCode                                    { get; set; }
        public int Puk_1                                      { get; set; }
        public int Puk_2                                      { get; set; }
        public EmpresaDeTelecomunicacao Operadora             { get; set; }
        public int Id_Operadora                               { get; set; }
        public Estado Estado                                  { get; set; }
        public int Id_Estado                                  { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DataDaCompra    { get; set; }
    }

    internal partial class InfoSimCard_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<InfoSimCard>
    {
        public InfoSimCard_configuration()
        {
            this.HasKey(t => t.ID);
            this.HasRequired(a => a.Operadora).WithMany().HasForeignKey(a => a.Id_Operadora);
            this.HasRequired(b => b.Estado).WithMany().HasForeignKey(b => b.Id_Estado);

            this.ToTable("InfoSimCards");
        }
    }
}