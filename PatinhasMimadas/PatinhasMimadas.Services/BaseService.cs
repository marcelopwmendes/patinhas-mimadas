using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PatinhasMimadas.Services
{
    public abstract class BaseService
    {

        public OperationResult<T> ExecuteOperation<T>(Func<T> func)
        {
            TransactionOptions transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromSeconds(30)
            };

            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                try
                {
                    T result = func();
                    transactionScope.Complete();
                    return new OperationResult<T>(result);
                }
                catch (Exception ex)
                {
                    return new OperationResult<T>(ex);
                }
            }
        }

        public OperationResult ExecuteOperation(Action action)
        {
            TransactionOptions transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromSeconds(30)
            };
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                try
                {
                    action();
                    transactionScope.Complete();
                    return new OperationResult(true);
                }
                catch (Exception ex)
                {
                    return new OperationResult(ex);
                }
            }
        }

        public async Task<OperationResult<T>> ExecuteOperationAsync<T>(Func<Task<T>> func)
        {
            TransactionOptions transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromSeconds(30)
            };

            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                try
                {
                    T result = await func();
                    transactionScope.Complete();
                    return new OperationResult<T>(result);
                }
                catch (Exception ex)
                {
                    return new OperationResult<T>(ex);
                }
            }
        }

        public async Task<OperationResult> ExecuteOperationAsync(Func<Task> func)
        {
            TransactionOptions transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromSeconds(30)
            };
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                try
                {
                    await func();
                    transactionScope.Complete();
                    return new OperationResult(true);
                }
                catch (Exception ex)
                {
                    return new OperationResult(ex);
                }
            }
        }

    }
}
