using System.Net;
using System.Net.Mail;
// remmember, the email account must not use 2-step verification :v (or you have to create an app password)
class Program
{
    static void Main()
    {
        SendEmail();
    }

    public static void SendEmail()
    {
        MailMessage mail = new MailMessage("g@sis.hust.edu.vn", "i@gmail.com");
        mail.Subject = "Test Email";
        mail.Body = @"
        <html>
        <head>
            <style>
                body {font-family: Arial, sans-serif;}
                .content {margin: auto; width: 50%; padding: 10px;}
                h1 {color: #ff9900;}
                p {color: #333;}
            </style>
        </head>
        <body>
            <div class='content'>
                <h1>This is a test email</h1>
                <p>Sent from a C# application.</p>
            </div>
        </body>
        </html>";
        mail.IsBodyHtml = true;

        SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
        client.Port = 587;
        client.Credentials = new NetworkCredential("g@sis.hust.edu.vn", "strongPassword");
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