using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.Services.Interfaces
{
    public interface IAccountService
    {
        string EncriptPassword(string password, Guid salt);
        Task<OperationResult<string>> SendNewPassword(string email);
    }
}
