using eCommerceSE.Model;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;

namespace Enviosbase.Business
{
    public class EmailBussines
    {
        public void SendMailRecovery(RecoveryPasswordModel recoveryPassword, Login login, string url)
        {
            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            string strHost = smtpSection.Network.Host;
            int port = smtpSection.Network.Port;
            bool ssl = smtpSection.Network.EnableSsl;
            string strUserName = smtpSection.Network.UserName;
            string strFromPass = smtpSection.Network.Password;

            SmtpClient smtp = new SmtpClient(strHost, port);
            smtp.UseDefaultCredentials = false;
            NetworkCredential cert = new NetworkCredential(strUserName, strFromPass);
            smtp.Credentials = cert;
            smtp.EnableSsl = ssl;

            string sitio = ConfigurationManager.AppSettings.Get("UrlSito");

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(smtpSection.From);
            msg.To.Add(new MailAddress(login.Email));
            msg.Subject = "Recuperación de Contraseña";
            msg.IsBodyHtml = true;
            msg.Body += "Estimado usuario " + login.Nombres + " " + login.Apellidos;
            msg.Body += "<br><br>Has recibido este mensaje ya que has solicitado el cambio de contrase&ntilde;a de tu cuenta en " + sitio;
            msg.Body += "<br>Para ello, simplemente haz click en el siguiente enlace y introduce una nueva contraseña: ";
            msg.Body += url + "/ResetPassword.aspx?token=" + recoveryPassword.Token;
            msg.Body += "<br><br>Por favor, ignora este mensaje en el caso que no hayas solicitado un cambio de contrase&ntilde;a de tu cuenta.";
            msg.Body += "<br>----<br>Equipo SusEnvios \n\r" + sitio;

            smtp.Send(msg);
        }

        public void SendMailCreateUserEst(string usuario, string contraseña, string nombre, string correo)
        {
            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            string strHost = smtpSection.Network.Host;
            int port = smtpSection.Network.Port;
            bool ssl = smtpSection.Network.EnableSsl;
            string strUserName = smtpSection.Network.UserName;
            string strFromPass = smtpSection.Network.Password;

            SmtpClient smtp = new SmtpClient(strHost, port);
            smtp.UseDefaultCredentials = false;
            NetworkCredential cert = new NetworkCredential(strUserName, strFromPass);
            smtp.Credentials = cert;
            smtp.EnableSsl = ssl;

            string sitio = ConfigurationManager.AppSettings.Get("UrlSito");

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(smtpSection.From);
            msg.To.Add(new MailAddress(correo));
            msg.Subject = "Usuario sus envios";
            msg.IsBodyHtml = true;
            msg.Body += "Estimado usuario " + nombre;
            msg.Body += "<br><br>Has recibido este mensaje ya que se ha creado el usuario de tu cuenta en " + sitio;
            msg.Body += "<br>Para ello, simplemente haz click en el siguiente enlace y introduce tu usuario: <b>" + usuario + "</b> y tu contrase&ntilde;a: <b>";
            msg.Body += contraseña;
            msg.Body += "</b><br>----<br>Equipo SusEnvios \n\r" + sitio;

            smtp.Send(msg);

        }

        public void SendMailCreateUserDom(string usuario, string contraseña, string nombre, string correo)
        {
            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            string strHost = smtpSection.Network.Host;
            int port = smtpSection.Network.Port;
            bool ssl = smtpSection.Network.EnableSsl;
            string strUserName = smtpSection.Network.UserName;
            string strFromPass = smtpSection.Network.Password;

            SmtpClient smtp = new SmtpClient(strHost, port);
            smtp.UseDefaultCredentials = false;
            NetworkCredential cert = new NetworkCredential(strUserName, strFromPass);
            smtp.Credentials = cert;
            smtp.EnableSsl = ssl;

            string sitio = ConfigurationManager.AppSettings.Get("UrlSito");

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(smtpSection.From);
            msg.To.Add(new MailAddress(correo));
            msg.Subject = "Usuario sus envios";
            msg.IsBodyHtml = true;
            msg.Body += "Estimado usuario " + nombre;
            msg.Body += "<br><br>Has recibido este mensaje ya que se ha creado el usuario de tu cuenta";
            msg.Body += "<br>Para ello, Descarga la app en la play store SEDomiciliario e ingresa, introduce tu usuario: <b>" + usuario + "</b> y tu contrase&ntilde;a: <b>";
            msg.Body += contraseña;
            msg.Body += "<br><br>";
            msg.Body += "</b><br>----<br>Equipo SusEnvios \n\r" + sitio;

            smtp.Send(msg);

        }

        public void SendMailRememberUserDom(string usuario, string contraseña, string nombre, string correo)
        {
            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            string strHost = smtpSection.Network.Host;
            int port = smtpSection.Network.Port;
            bool ssl = smtpSection.Network.EnableSsl;
            string strUserName = smtpSection.Network.UserName;
            string strFromPass = smtpSection.Network.Password;

            SmtpClient smtp = new SmtpClient(strHost, port);
            smtp.UseDefaultCredentials = false;
            NetworkCredential cert = new NetworkCredential(strUserName, strFromPass);
            smtp.Credentials = cert;
            smtp.EnableSsl = ssl;

            string sitio = ConfigurationManager.AppSettings.Get("UrlSito");

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(smtpSection.From);
            msg.To.Add(new MailAddress(correo));
            msg.Subject = "Usuario sus envios";
            msg.IsBodyHtml = true;
            msg.Body += "Estimado usuario " + nombre;
            msg.Body += "<br><br>Has recibido este mensaje ya que solicitaste reestablecer el usuario de tu cuenta";
            msg.Body += "<br>Para ello, Descarga la app en la play store SEDomiciliario e introduce tu usuario: <b>" + usuario + "</b> y tu contrase&ntilde;a: <b>";
            msg.Body += contraseña;
            msg.Body += "<br><br>";
            msg.Body += "</b><br>----<br>Equipo SusEnvios \n\r" + sitio;

            smtp.Send(msg);

        }

        public void SendMailEnRuta(string nombre, string to, string fechaEnvio)
        {
            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            string strHost = smtpSection.Network.Host;
            int port = smtpSection.Network.Port;
            bool ssl = smtpSection.Network.EnableSsl;
            string strUserName = smtpSection.Network.UserName;
            string strFromPass = smtpSection.Network.Password;

            SmtpClient smtp = new SmtpClient(strHost, port);
            smtp.UseDefaultCredentials = false;
            NetworkCredential cert = new NetworkCredential(strUserName, strFromPass);
            smtp.Credentials = cert;
            smtp.EnableSsl = ssl;

            string messageHtml = "Estimado usuario " + nombre;
            messageHtml += "<br><br>Su mercé el mercadito ya esta listo y llegara el " + fechaEnvio + " pa que esté pendiente.";
            messageHtml += "<br><br>Recuerda que puedes consultar el estado de tus pedidos en la sección \"Mis pedidos\"";
            messageHtml += "</b><br>----<br>Equipo FruBitCol \n\r";

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(smtpSection.From);
            msg.To.Add(new MailAddress(to));
            msg.Subject = "Pedido Listo";
            msg.IsBodyHtml = true;
            msg.Body = messageHtml;

            smtp.Send(msg);
        }
    }
}
