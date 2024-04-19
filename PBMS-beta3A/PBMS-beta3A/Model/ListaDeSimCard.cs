using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.Model
{
    public class ListaDeSimCard
    {
        public Int32 ID                     { get; set; }
        public int Estado                   { get; set; }
        public string EstadoDescricao       { get; set; }
        public string Numero                { get; set; }
        public string Operadora             { get; set; }
       
        public int Puk_1                    { get; set; }
        public int Puk_2                    { get; set; }
        public int PinCode                  { get; set; }
        public int ValorEmUTTs              { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DataUltimaRecarga    { get; set; }
    }
}