using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.Model
{
    public class CriarContrato
    {
        public int Cliente_Id { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime Data    { get; set; }

        public int clausa_1   { get; set; }
        public int clausa_2   { get; set; }
        public int clausa_3   { get; set; }
        public int clausa_4   { get; set; }
        public int clausa_5   { get; set; }
        public int clausa_6   { get; set; }
        public int clausa_7   { get; set; }
        public int clausa_8   { get; set; }
        public int clausa_9   { get; set; }
        public int clausa_10  { get; set; }
    }
}