using Microsoft.Extensions.Options;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MosarticoApi.Domain.Services.Services
{
    public class ServiceEmailSender : IEmailSender
    {
        private readonly EnviaEmail _emailSettings;

        public ServiceEmailSender(IOptions<EnviaEmail> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public Task SendEmailRecoveryPassAsync(string toEmail, string token)
        {
            try
            {
                var messageTemplate = string.Format(
                    "Prezado(a)," +
                    "<br><br>" +
                    "Para criar uma nova senha senha, utilize o código abaixo:" +
                    "<br><br> " +
                    "<b>123456</b>", token, toEmail);             


                Execute(toEmail, "Recuperação de senha - Equipe Mosartico", messageTemplate, "Mosartico - Recuperação de senha").Wait();
                return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Execute(string toEmail, string subject, string message, string title)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, title)
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.Subject = $"{subject}";
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}
