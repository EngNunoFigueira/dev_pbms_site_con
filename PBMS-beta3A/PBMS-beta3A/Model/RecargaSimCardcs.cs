using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.Model
{
    public class RecargaSimCardcs
    {
        public int   UTTs                     { get; set; }
        public Int32 Id_SimCard               { get; set; }
        public string CodigoRecarga           { get; set; }
        public int Feedback_Referencia        { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DataCompra            { get; set; }
    }
}