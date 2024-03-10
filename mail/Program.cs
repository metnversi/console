using System.Net;
using System.Net.Mail;
// remmember, the email account must not have 2-step verification enabled
public class Program
{
    static void Main()
    {
        SendEmail();
    }

    public static void SendEmail()
    {
        MailMessage mail = new MailMessage("sender@sis.hust.edu.vn", "receiver@gmail.com");
        mail.Subject = "Test Email";
        mail.Body = @"
        <html>
        <head>
            <style>
                body {font-family: Arial, sans-serif; border: 1px solid #333;}
                .header {background-color: #ff9900; padding: 10px; display: flex; justify-content: center; align-items: center; border: 1px solid #333;}
                .content {margin: auto; width: 50%; padding: 10px;}
                .footer {background-color: #ff9900; padding: 10px; text-align: center; border: 1px solid #333;}
                h1 {color: #333;}
                p {color: #333;}
            </style>
        </head>
        <body>
            <div class='header'>
                <a href='https://yoosungkn.com/'>
                    <img src='https://yoosungkn.com/Upload/logo/%EC%9C%A0%EC%84%B1%EB%A1%9C%EA%B3%A0-logo-big-yoosung-general.jpg' alt=' Logo' width='150'>
                </a>
            </div>
            <div class='content'>
                <p>Dear Mr,</p>
                <p>I'm telling you.</p>
                <p>Bye.</p>
            </div>
            <div class='footer'>
                <img src='https://link-to-footer-image' alt=' Footer Image' width='100'>
            </div>
        </body>
        </html>";

        mail.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
        client.Port = 587;
        client.Credentials = new NetworkCredential("sender@sis.hust.edu.vn", "password");
        client.EnableSsl = true;

        try
        {
            client.Send(mail);
            Console.WriteLine("Email sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to send email. Error: " + ex.Message);
        }
    }
}