using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.Model
{
    public class FichaFuncionario
    {
       // Dados Pessoais
        public string Nome                 { get; set; }
        public string Apelido              { get; set; }
        // Documento
        public int DocumentoID             { get; set; }
        public string Tipo                 { get; set; }
        public string Numero               { get; set; }
        public DateTime? Validade          { get; set; }

        // Contactos
        public int ContactosID             { get; set; }
        public string Telefone             { get; set; }
        public string Telemovel            { get; set; }
        public string Email                { get; set; }

        // Hablitacao
        public string Grau                 { get; set; }
        public int Id_Grau                 { get; set; }

        // Funcao
        public int Id_Funcao            { get; set; }
        public string Descricao_Funcao     { get; set; }
    }
}