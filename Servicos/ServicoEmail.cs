using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Mvc_ConfRec.Servicos
{
    public class ServicoEmail
    {
        public static async Task EnviaEmailAsync(string email, string assunto, string mensagem)
        {
            var apiKey = "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"; // Substitua pelo seu API Key do SendGrid
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("contato@acesv.com.br", "Acesv Contato");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, assunto, mensagem, mensagem);

            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                throw new Exception($"Failed to send email. Status code: {response.StatusCode}");
            }
        }
    }
}
