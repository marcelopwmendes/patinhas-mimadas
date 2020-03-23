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
    
    }
}
