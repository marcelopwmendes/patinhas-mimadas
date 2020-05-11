using PatinhasMimadas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public string EncriptPassword(string password, Guid salt)
        {
            return ComputeHash(password + salt);
        }

        private string ComputeHash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public async Task<OperationResult<string>> SendNewPassword(string email)
        {
            //TODO: Create business email
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential("marcelopwmendes@gmail.com", "PASSWORD");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("marcelopwmendes@gmail.com", "Marcelo Mendes");
            mail.To.Add(new MailAddress(email));
            mail.Subject = "Test App";
            mail.Body = "Test";
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Send(mail);
            return new OperationResult<string>(email);
        }
    }
}
