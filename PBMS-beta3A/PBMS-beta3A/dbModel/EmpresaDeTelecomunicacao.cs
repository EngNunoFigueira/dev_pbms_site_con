using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace PBMS_beta3A.dbModel
{
    public class EmpresaDeTelecomunicacao
    {
        public int ID              { get; set; }
        public string Descricao    { get; set; }
    }
    internal partial class EmpresaDeTelecomunicacao_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<EmpresaDeTelecomunicacao>
    {
        public EmpresaDeTelecomunicacao_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("EmpresaDeTelecomunicacoes");
        }
    }

}