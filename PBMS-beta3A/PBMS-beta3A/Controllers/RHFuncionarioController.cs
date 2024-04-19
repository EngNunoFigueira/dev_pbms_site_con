using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBMS_beta3A.Model;
using PBMS_beta3A.dbModel;
using System.Net;
using System.Net.Mail;

namespace PBMS_beta3A.Controllers
{
    public class RHFuncionarioController : Controller
    {
  
        [HttpGet]
        public ActionResult RegistarFuncionario()
        {
            #region ESTA ACTION PERMITE REGISTAR FUNCIONÁRIOS - GET
            //Carrega a Lista de Bairros para facilitar a selecção da morada
            using (MyDbContext db = new MyDbContext())
            {
                var GetBairros = from items in db.Bairros
                                    where items.ID > 0
                                    orderby items.Nome
                                    select new {items.ID, items.Nome };  

                ViewBag.Bairros = GetBairros.ToList();
            }

            return View();
        #endregion
        }


        [HttpPost]
        public ActionResult RegistarFuncionario(FichaFuncionario model)
        {
            #region ESTA ACTION PERMITE REGISTAR FUNCIONÁRIOS - POST
            EnviadoEmailParaUtilizadorComDadosDeAcesso("", "");
            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    Funcionario FichaDeInscricao = new Funcionario();

                    //Dados Pessoais
                    FichaDeInscricao.Nome = model.Nome;
                    FichaDeInscricao.Apelido = model.Apelido;
                    //Documento
                    FichaDeInscricao.Documento.Tipo = model.Tipo;
                    FichaDeInscricao.Documento.Numero = model.Numero;
                    FichaDeInscricao.Documento.Validade = model.Validade;
                    //Contactos
                    FichaDeInscricao.Contacto.Email = model.Email;
                    FichaDeInscricao.Contacto.Telefone = model.Telefone;
                    FichaDeInscricao.Contacto.Telemovel = model.Telemovel;
                    //Hablitacao
                    FichaDeInscricao.Id_Hablitacao = model.Id_Grau;
                    //Funcao
                    FichaDeInscricao.Id_Funcao = model.Id_Funcao;

                    db.Funcionarios.Add(FichaDeInscricao);
                    db.SaveChanges();

                    #region Depois de Registar o funcionarios vamos criar um perfil de acesso ao PBMS

                    //string PrimeiraPasswordParaAlterar = "P21R_!8dJYo@";
                    //string PrimeiraPasswordParaAlterar = "M@mb*482016";  
                   // string PrimeiraPasswordParaAlterar = "b@ntu360Mu-k!ut0";
                    string PrimeiraPasswordParaAlterar = "k@b40T!-qR12";
                    var SistemaDeEncriptacao = new SimpleCrypto.PBKDF2();
                    var PasswordEncriptada = SistemaDeEncriptacao.Compute(PrimeiraPasswordParaAlterar);

                    DadoDeLogin PerfilDeAcessoParaNovoUtilizadorDoPBMS = new DadoDeLogin();

                    PerfilDeAcessoParaNovoUtilizadorDoPBMS.Email = model.Email;
                    PerfilDeAcessoParaNovoUtilizadorDoPBMS.Password = PasswordEncriptada;
                    PerfilDeAcessoParaNovoUtilizadorDoPBMS.PasswordSalt = SistemaDeEncriptacao.Salt;

                    db.DadoDeLogins.Add(PerfilDeAcessoParaNovoUtilizadorDoPBMS);
                    db.SaveChanges();

                    #endregion

                    #region Envia o Email com os dados de Login para o Itilizador recém registado.

                    EnviadoEmailParaUtilizadorComDadosDeAcesso("", "");

                    #endregion
                }
            }
            catch (Exception e) { ViewBag.MensagemdeError = e; }
           
            return View();

            #endregion
        }

        //AQUI VAMOS TRATAR DA INFORMACAO DOS CLIENTES

        [HttpGet]
        public ActionResult RegistoDeClientes()
        {
            #region ESTA ACTION MOSTRA O FORMULARIO PARA REGISTAR NOVO CLIENTE - GET

            using (MyDbContext db=new MyDbContext())
            {
                var GET_BAIRRROS = from items in db.Bairros
                                   select new { items.ID, items.Nome };

                                   ViewBag.Bairros = GET_BAIRRROS.ToList();

            }

            return View();

            #endregion
        }

        [HttpPost]
        public ActionResult RegistoDeClientes(CrearFichaDeCliente model)
        {

            #region ESTA ACTION RECEBE OS DADOS DO NOVO CLIENTE E GUARDA EM BASE DE DADOS - POST

            using (MyDbContext db = new MyDbContext())
            {
              
                Cliente RegistarCliente = new Cliente();

                //Dados do Cliente
                RegistarCliente.Nome = model.Nome;
                RegistarCliente.Apelido = model.Apelido;
                RegistarCliente.URL = model.Contacto_URL;

                //Data DA ABERTURA DO CONTRATO
                RegistarCliente.Data = DateTime.Now;

                //MORADA
                RegistarCliente.Morada.Descricao = "Actual";
                RegistarCliente.Morada.Id_Bairro = model.Id_Morada_Bairro;
                RegistarCliente.Morada.Morada_Rua_AVD = model.Morada_Rua_AVD;
                RegistarCliente.Morada.Morada_Numero_Porta = model.Morada_Numero_Porta;
                    
                //CONTACTOS
                RegistarCliente.Contacto.Email = model.Contacto_Email;
                RegistarCliente.Contacto.Telefone = model.Contacto_Telefone;
                RegistarCliente.Contacto.Telemovel = model.Contacto_Telemovel;

                //ESTADO
                RegistarCliente.Id_Estado = 20;

                //REFERENCIA 
                RegistarCliente.Id_Referencia = model.Id_Referencia;

                db.Clientes.Add(RegistarCliente);
                db.SaveChanges();
                  
            }

            return (RedirectToAction("ListaDeClientes"));
            #endregion
        }

        [HttpGet]
        public ActionResult ListaDeClientes()
        {
            #region ESTA ACTION MOSTRA A LISTA DE CLIENTES -GET

            using (MyDbContext db=new MyDbContext())
            {
                List<CrearFichaDeCliente> Clientes = new List<CrearFichaDeCliente>();

                try
                {

                    var GET_CLIENTES = from items in db.Clientes
                                       where items.Estado.ID == 20
                                       select new
                                       {
                                           items.Nome,
                                           items.Apelido,
                                           items.Data,
                                           items.Referencia,
                                           items.Estado,
                                           items.Contacto,
                                           items.Morada,
                                           items.Morada.Bairro,
                                           items.Morada.Bairro.Municipio,
                                           items.Morada.Bairro.Municipio.provincia,
                                           items.URL
                                       };

                    GET_CLIENTES.ToList();


                    for (int i = 0; i < GET_CLIENTES.ToArray().Length; i++)
                    {

                        Clientes.Add(new CrearFichaDeCliente
                        {
                            Nome = GET_CLIENTES.ToArray()[i].Nome,
                            Apelido = GET_CLIENTES.ToArray()[i].Apelido,
                            Referencia = GET_CLIENTES.ToArray()[i].Referencia.Descricao,
                            Estado = GET_CLIENTES.ToArray()[i].Estado.Descricao,
                            Contacto_Email = GET_CLIENTES.ToArray()[i].Contacto.Email,
                            Contacto_Telefone = GET_CLIENTES.ToArray()[i].Contacto.Telefone,
                            Contacto_Telemovel = GET_CLIENTES.ToArray()[i].Contacto.Telemovel,
                            Contacto_URL = GET_CLIENTES.ToArray()[i].URL,
                            Morada_Provincia = GET_CLIENTES.ToArray()[i].Morada.Bairro.Municipio.provincia.Nome,
                            Morada_Bairro = GET_CLIENTES.ToArray()[i].Morada.Bairro.Nome,
                            Morada_Municipio = GET_CLIENTES.ToArray()[i].Morada.Bairro.Municipio.Nome,
                            Morada_Rua_AVD = GET_CLIENTES.ToArray()[i].Morada.Morada_Rua_AVD,
                            Morada_Numero_Porta = GET_CLIENTES.ToArray()[i].Morada.Morada_Numero_Porta,
                            DataAbertura = GET_CLIENTES.ToArray()[i].Data

                        });

                    }

                }catch(Exception){}

                   return View(Clientes);
            }
            #endregion
        }

        [HttpGet]
        public PartialViewResult ActualizaAListaDeClientes(int operacao)
        {
          #region ESTA ACTION REFRESCA A LISTA DE CLIENTES - GET

            List<CrearFichaDeCliente> Clientes = new List<CrearFichaDeCliente>();

            using (MyDbContext db = new MyDbContext())
            {
                var GET_CLIENTES = from items in db.Clientes
                                   where items.Id_Referencia == operacao
                                   select new
                                   {
                                       items.Nome,
                                       items.Apelido,
                                       items.Data,
                                       items.Referencia,
                                       items.Estado,
                                       items.Contacto,
                                       items.Morada,
                                       items.Morada.Bairro,
                                       items.Morada.Bairro.Municipio,
                                       items.Morada.Bairro.Municipio.provincia,
                                       items.URL
                                   };

                GET_CLIENTES.ToList();


                for (int i = 0; i < GET_CLIENTES.ToArray().Length; i++)
                {
                    Clientes.Add(new CrearFichaDeCliente
                    {
                        Nome = GET_CLIENTES.ToArray()[i].Nome,
                        Apelido = GET_CLIENTES.ToArray()[i].Apelido,
                        Referencia = GET_CLIENTES.ToArray()[i].Referencia.Descricao,
                        Estado = GET_CLIENTES.ToArray()[i].Estado.Descricao,
                        Contacto_Email = GET_CLIENTES.ToArray()[i].Contacto.Email,
                        Contacto_Telefone = GET_CLIENTES.ToArray()[i].Contacto.Telefone,
                        Contacto_Telemovel = GET_CLIENTES.ToArray()[i].Contacto.Telemovel,
                        Contacto_URL = GET_CLIENTES.ToArray()[i].URL,
                        Morada_Bairro = GET_CLIENTES.ToArray()[i].Morada.Bairro.Nome,
                        Morada_Municipio = GET_CLIENTES.ToArray()[i].Morada.Bairro.Municipio.Nome,
                        Morada_Provincia = GET_CLIENTES.ToArray()[i].Morada.Bairro.Municipio.provincia.Nome,
                        Morada_Rua_AVD = GET_CLIENTES.ToArray()[i].Morada.Morada_Rua_AVD,
                        Morada_Numero_Porta = GET_CLIENTES.ToArray()[i].Morada.Morada_Numero_Porta,
                        DataAbertura = GET_CLIENTES.ToArray()[i].Data
                    });
                }
            }

            return PartialView(Clientes);
          #endregion
        }

        #region Gestor de Tarefas, neste ponto iremos desenvolver a lógica de negócio para fazer a gestao das manutenções

        [HttpGet]
        public ActionResult GestorDeTarefas()
        {
            using (MyDbContext db = new MyDbContext())
            {
                var GET_TASKS = (from itens_B in db.Manutencoes
                                 where itens_B.Id_Estado == 15
                                 select new
                                 {
                                     itens_B.NumeroDeHoras,
                                     itens_B.Funcionario,
                                     itens_B.DataFecho,
                                     itens_B.DataInicio,
                                     itens_B.Estado.Descricao,
                                     itens_B.TipodeTarefa
                                 }).ToList();

                List<GestorDeTarefas> Task = new List<GestorDeTarefas>();
              
                for (int i = 0; i < GET_TASKS.ToArray().Length; i++)
                {

                    for (int j = 0; j < GET_TASKS.ToArray()[i].Funcionario.Count; j++)
                    {
                        Task.Add(new GestorDeTarefas
                        {
                            DateFecho = GET_TASKS.ToArray()[i].DataFecho,
                            DateInicio= GET_TASKS.ToArray()[i].DataInicio,
                            NomeDoFuncionario = GET_TASKS.ToArray()[i].Funcionario.ToArray()[j].Nome,
                            ApelifoDoFuncionario = GET_TASKS.ToArray()[i].Funcionario.ToArray()[j].Apelido,
                            TarefaEmCurso = GET_TASKS.ToArray()[i].TipodeTarefa.Descricao,
                            EstadoActual = GET_TASKS.ToArray()[i].Descricao,
                            NumeroDeHoras = GET_TASKS.ToArray()[i].NumeroDeHoras
                        });
                    }
                }
                return View(Task);
            }
        }

#endregion 

        #region Gestor de Tarefas, parte de HttpPost
        //[HttpPost]
        //public ActionResult GestorDeTarefas()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public PartialView GestorDeTarefas()
        //{
        //    return View();
        //}
        #endregion

        #region Funcao que envia os Emails com as credencias dos utilzadores registados

        private void EnviadoEmailParaUtilizadorComDadosDeAcesso(string Email, string Mensagem)
        {
            MailMessage EnviarPerfilPorEmail = new MailMessage();

            EnviarPerfilPorEmail.From = new MailAddress("wezaembedded@gmail.com");
            EnviarPerfilPorEmail.To.Add(new MailAddress("ekumbi48172@hotmail.com"));
            EnviarPerfilPorEmail.Subject=("Dados de Acesso a Plataforma PBMS");
            EnviarPerfilPorEmail.Body = ("Caro António, " + Environment.NewLine + " Bem-vindo ao sistema Power Backup Manager Sistem. A continuação poderá encontrar as informações para aceder ao sistema." 
                + Environment.NewLine+ "Por favor sempre deverá mudar a sua password o mais breve possível"+ Environment.NewLine+ "Com os melhores cumprimentos,"+ Environment.NewLine+ "A equipa de gestão da Nundel Technologies");

        using (var ServidorDeEmail = new SmtpClient())
        {
            //var credential = new NetworkCredential 
            //{
            //    UserName = "wezaembedded@gmail.com",  
            //    Password = "S2ISF3RP"  
            //};

           // ServidorDeEmail.Credentials = credential;
            ServidorDeEmail.Credentials = new NetworkCredential("wezaembedded@gmail.com", "S2ISF3RP");
            ServidorDeEmail.Host = "smtp.gmail.com";
            ServidorDeEmail.Host = "587";
            //ServidorDeEmail.Port = 25;
            ServidorDeEmail.EnableSsl = false;
           // ServidorDeEmail.SendAsync(EnviarPerfilPorEmail,"");
            ServidorDeEmail.Send(EnviarPerfilPorEmail);
        }

        MailMessage mail  = new MailMessage("ekumbi48172@hotmail.com", "ekumbi48172@hotmail.com");
        SmtpClient client = new SmtpClient();
        client.Port = 25;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Host = "smtp.gmail.com";
        mail.Subject = "this is a test email.";
        mail.Body = "this is my test email body";
        client.Send(mail);

        }

        #endregion
    }
}

