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

namespace CV.MODELS
{
    public class MAIL
    {
        static MAIL instancia;

        public static MAIL Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new MAIL();
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


    }
}

#endregion
