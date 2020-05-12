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

        public async Task<OperationResult<string>> SendNewPassword(string email, string newPassword)
        {
            //TODO: Create business email
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential("marcelopwmendes@gmail.com", "PASSWORD");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("marcelopwmendes@gmail.com", "Marcelo Mendes");
            mail.To.Add(new MailAddress(email));
            mail.Subject = "Recuperar Password";
            mail.Body = "Devido ao pedido de recuperação, enviamos aqui a sua nova password: " + newPassword;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Send(mail);
            return new OperationResult<string>(email);
        }

        public string GeneratePassword()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[8];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
