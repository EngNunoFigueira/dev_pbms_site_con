using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Geraway
    {
        public Int32 ID                     { get; set; }
        public string modelo                { get; set; }
        public string firmware_version      { get; set; }
        public string serial_number         { get; set; }
        public string part_number           { get; set; }
    
        public int n_sensore_I              { get; set; }
        public int n_sensores_V             { get; set; }
        public int n_sensores_P             { get; set; }
        public int n_sensores_T             { get; set; }
        public int n_sensores_N             { get; set; }
        public int n_sensores_F             { get; set; }
        public string tipo_M_T_B            { get; set; }
        public string PCB_version           { get; set; }

        public Estado Estado                { get; set; }
        public int Id_Estado                { get; set; }
    }
    internal partial class Geraway_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Geraway>
    {
        public Geraway_configuration()
        {
            this.HasKey(t => t.ID);
            this.HasRequired(a => a.Estado).WithMany().HasForeignKey(a => a.Id_Estado);
            this.ToTable("Geraways");
        }
    }
}