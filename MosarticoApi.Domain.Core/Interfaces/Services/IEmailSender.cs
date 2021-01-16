using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MosarticoApi.Domain.Core.Interfaces.Services
{
    public interface IEmailSender
    {
        Task SendEmailRecoveryPassAsync(string email, string token);
    }
}
