using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.Model
{
    public class RequisitarMaterial
    {
        //create on 27-05-2016
        public Int32 ID                   { get; set; }
        public DateTime ? Data            { get; set; }
        public string DescricaoDoEstado   { get; set; }
        public int Id_Estado              { get; set; }
        public string Material            { get; set; }

        public int ID_Resp                { get; set; }
        public string RespNome            { get; set; }
        public string RespApelido         { get; set; }
        public string ResEmail            { get; set; }
        public string ResTelemovel        { get; set; }
    }
}