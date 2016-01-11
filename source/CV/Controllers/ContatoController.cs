using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV.MODELS;

namespace CV.Controllers
{
    public class ContatoController : Controller
    {
        // GET: Contato
        [HttpPost]
        public JsonResult Enviar(String name, String telefone, String email, String subject,int newsletter, String message)
        {

            if( EnviarEmail(Notifica(name, telefone, email, subject, newsletter, message), "ENVIO DE EMAIL")>0)
                return Json("OK");
            else
                return Json("Não enviou");
        }

        /********************Notifica cadastro usuário***************************************/
        public Email Notifica(String name, String telefone, String email, String subject, int newsletter, String message)
        {
            ////Define o corpo do e-mail.
            String conteudo = "Thiago o Sr. /Sra " + name + ", <br /><br />";
            conteudo += "entrou em contato sobre: "+subject+" <br /><br />";
            conteudo += message+" <br /><br />";

            conteudo += "Por favor, use estes contatos para dar um retorno:<br /><br />";
            conteudo += "Tel: " + telefone + "<br />";
            conteudo += "Email: " + email + "<br />";
            string validado = newsletter == 1 ? "Aceita" : "Não Aceita";
            conteudo += "Newsletter: " + validado + "<br /><br /><br />";

            //conteudo += "Link da Plataforma: <a>http://merck.novatela.com.br/ </a><br /><br />";






            Email obj = new Email();
            obj.setDestinatario(email);
            obj.setAssunto("thiagodesenv | " + subject);
            obj.setMensagem(conteudo);
            return obj;
        }


        public int EnviarEmail(Email obj, string rotina)
        {

            string conteudo = "";
            //Cria objeto com dados do e-mail.
            System.Net.Mail.MailMessage objEmail = new System.Net.Mail.MailMessage();

            //Define o remetente do e-mail.01:03
            objEmail.From = new System.Net.Mail.MailAddress("Thiago de Melo Lima <thiago@novatela.com.br>");

            //Define os destinatários do e-mail.
            //foreach (String destinatario in obj.getDestinatario())
                objEmail.To.Add("Thiago <thiago_melo1993@hotmail.com>");

            //Enviar cópia para.
            foreach (String destinatario in obj.getDestinatario())
            objEmail.To.Add(destinatario);

            //Enviar cópia oculta para.
            objEmail.Bcc.Add("Thiago <thiago@novatela.com.br>");

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //string fullpath = MapPath("~\\TestFile.txt");
            //objEmail.Attachments.Add(new Attachment("C:\\srv\\httpd\\merck.novatela.com.br\\merck\\public\\teste.txt"));
            //objEmail.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~/manual/usuario.txt"));
            //Define título do e-mail.
            objEmail.Subject = obj.getAssunto().ToString();

            //Define o corpo do e-mail.
            conteudo += obj.getMensagem();




            //conteudo += "NovaTela Solutions<br /><br />";
            conteudo += "Este é um e-mail automático utilizado somente para envio. <br /><br />";

            conteudo += "Data envio: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "";

            objEmail.Body = conteudo;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            Email mail = new Email();
            return mail.Enviar(objEmail, rotina);
        }

    }

}
