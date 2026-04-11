using System.Net;
using System.Net.Mail;

namespace HolaMundo.Notificaciones
{
    public class Notificacion: INotificacion
    {
        public async Task EnviarAsync(string correoDestino)
        {
            var from = "notificacion@vmartinez84.xyz";
            var to = correoDestino;//"ahal_tocob@hotmail.com";
            var subject = "Prueba desde C#";
            var body = "Hola, es un correo de prueba enviado con C#.";

            Task.Delay(5000).Wait(); // Simula un retraso en el envío del correo
            try
            {
                using (var client = new SmtpClient("vmartinez84.xyz", 587))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(from, "1s31f?G6e");

                    var mail = new MailMessage(from, to, subject, body)
                    {
                        IsBodyHtml = false
                    };

                    await client.SendMailAsync(mail);
                    Console.WriteLine("Correo enviado");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task EnviarConGmail(string correoDestino)
        {
            var from = "superior.viktor@gmail.com";
            var to = correoDestino;
            var subject = "Prueba desde C#";
            var body = "Hola, es un correo de prueba enviado con C#.";

            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;                
                client.Credentials = new NetworkCredential(from, "Su clave");

                var mail = new MailMessage(from, to, subject, body)
                {
                    IsBodyHtml = false
                };

                await client.SendMailAsync(mail);
                Console.WriteLine("Correo enviado correctamente");
            }
        }
    }

    public interface INotificacion
    {
        Task EnviarAsync(string correoDestino);
        Task EnviarConGmail(string correoDestino);
    }
}
