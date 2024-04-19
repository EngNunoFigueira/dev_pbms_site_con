using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.Model
{
    public class RegistarSimCard
    {
        public int Operadora         { get; set; }
        public string Numero         { get; set; }
        public int PinCode           { get; set; }
        public int Puk_1             { get; set; }
        public int Puk_2             { get; set; }
        public int Status_Referencia { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DataDaCompra { get; set; }
    }
}