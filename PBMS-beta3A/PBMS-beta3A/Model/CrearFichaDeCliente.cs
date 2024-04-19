using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.Model
{
    public class CrearFichaDeCliente
    {
        public string Nome                    { get; set; }
        public string Apelido                 { get; set; }

        public string Referencia              { get; set; }
        public int Id_Referencia              { get; set; }

        public string Estado                  { get; set; }
        public int Id_Estado                  { get; set; }

        public int Id_Contacto                { get; set; }
        public string Contacto_Email          { get; set; }
        public string Contacto_Telefone       { get; set; }
        public string Contacto_Telemovel      { get; set; }
        public string Contacto_URL            { get; set; }

        public string Id_Morada              { get; set; }
        public int    Id_Morada_Bairro       { get; set; }
        public string Morada_Bairro          { get; set; }
        public string Morada_Municipio       { get; set; }
        public string Morada_Provincia       { get; set; }
        public string Morada_Rua_AVD         { get; set; }
        public string Morada_Numero_Porta    { get; set; }

        public DateTime? DataAbertura       { get; set; }

    }
}


      