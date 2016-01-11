using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mime;
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CV.MODELS
{
    public class Email
    {
        static Email instancia;

        public static Email Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new Email();
                return instancia;
            }
        }

        #region Métodos de envio utilizando servidor mandrillapp

        public int Enviar(MailMessage objEmail, string rotina)
        {
            //Cria objeto com os dados do SMTP
            string servidor = "smtp.mandrillapp.com";
            int porta = 587;

            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient(servidor, porta);

            objSmtp.UseDefaultCredentials = false;
            objSmtp.Credentials = new System.Net.NetworkCredential("thiago_badboy300@hotmail.com", "9dM_xrca5IK6sgcu9Ld2Rw");
            objSmtp.EnableSsl = true;

            //Enviamos o e-mail através do método .send()
            try
            {
                objSmtp.Send(objEmail);
                objEmail.Dispose();
                return 1;
            }
            catch (Exception ex)
            {
                objEmail.Dispose();
                //System.Web.HttpContext.Current.Session.Add("erro", ex);
                // System.Web.HttpContext.Current.Response.Redirect("erro.aspx?erro=" + rotina, false);
                return (0);
            }
        }

        [Required]
        private String assunto;
        [Required]
        private String mensagem;
        [Required]
        private List<String> Listadestinatario;



        public Email()
        {
            assunto = "";
            mensagem = "";
            Listadestinatario = new List<String>();
        }

        public String getAssunto()
        {
            return assunto;
        }

        public void setAssunto(String assunto)
        {
            this.assunto = assunto;
        }

        public String getMensagem()
        {
            return mensagem;
        }

        public void setMensagem(String mensagem)
        {
            this.mensagem = mensagem;
        }

        public List<String> getDestinatario()
        {
            return Listadestinatario;
        }

        public void setDestinatario(String destinatario)
        {
            this.Listadestinatario.Add(destinatario);
        }


    }
}

#endregion
