using PatinhasMimadas.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatinhasMimadas.Services
{
    public class OperationResult
    {
        public bool HasSucceeded { get; set; }
        public Exception Exception { get; set; }
        public ErrorEnum Error { get; set; }
        public string ErrorDescription { get; set; }

        public OperationResult(bool hasSucceeded)
        {
            if (hasSucceeded)
            {
                HasSucceeded = true;
                return;
            }

            HasSucceeded = false;
        }

        public OperationResult(Exception ex)
        {
            HasSucceeded = false;
            Exception = ex;
            Error = ErrorEnum.System;
            ErrorDescription = ex.Message;
        }

        public OperationResult()
        {
        }

    }

    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }

        public OperationResult(T result)
        {
            Result = result;
            HasSucceeded = true;
        }

        public OperationResult(Exception ex) : base(ex)
        {
        }

        public OperationResult(Exception ex, ErrorEnum error) : base(ex)
        {
            Error = error;
            ErrorDescription = ex.Message;
        }


    }
}
