using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using UnityEngine.UI;

public class mono_gmail : MonoBehaviour
{
    public InputField Remitente, Destinatario, Contrasena, Mensaje ,Asunto;
    public void EnviarMail()
    {
        //Debug.Log( "El destino: " + Destinatario.text + ", El Remitente:" + Remitente.text + " ,Password:"+ Contrasena.text +" , Mensaje:" + Mensaje.text);
        MailLogic(Destinatario.text, Remitente.text, Contrasena.text, Mensaje.text, Asunto.text);
        //Para enviar correos
    }

    void MailLogic(string destino, string remi,string pass, string mssg, string subj)
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(remi);
        mail.To.Add(destino);
        mail.Subject = subj;
        mail.Body = mssg;

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential(remi, "mezsjzyezxfaftan") as ICredentialsByHost;
        //Se genera en el correo en acceso a apps de terceros              esta cosa
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        Debug.Log("success");
    }
}
