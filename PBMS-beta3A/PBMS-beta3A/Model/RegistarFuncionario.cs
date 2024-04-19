using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PBMS_beta3A.Model
{
    public class RegistarFuncionario
    {
        public string Email                      { get; set; }
        public string Nome                       { get; set; }
        public string Apelido                    { get; set; }
        public string NumeroDeBI                 { get; set; }
  
        public string Telemove_1                 { get; set; }
        public string Telemovel_2                { get; set; }
        public string Telefone_fixo              { get; set; }

        public int  Acesso_Id_Referencia          { get; set; }
        public int  Categoria_Id_Referencia       { get; set; }
        public int  Especialidade_Id_Referencia   { get; set; }
        public bool Estado                        { get; set; }

    }
}