using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatinhasMimadas.API.Enums;

namespace PatinhasMimadas.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ServiceResult Success()
        {
            return new ServiceResult
            {
                ErrorCode = ErrorEnum.None,
                StatusCode = HttpStatusCode.OK
            };
        }

        protected ServiceResult<T> Success<T>(T data)
        {
            return new ServiceResult<T>
            {
                Data = data,
                ErrorCode = ErrorEnum.None,
                StatusCode = HttpStatusCode.OK
            };
        }

        protected ServiceCollectionResult<T> Success<T>(ICollection<T> data)
        {
            return new ServiceCollectionResult<T>
            {
                Data = data,
                ErrorCode = ErrorEnum.None,
                StatusCode = HttpStatusCode.OK
            };
        }

        protected T Error<T>(ErrorEnum error)
            where T : ServiceResult
        {
            T result = (T)Activator.CreateInstance(typeof(T));
            result.StatusCode = ErrorMethods.ToStatusCode(error);
            result.ErrorCode = error;

            Response.StatusCode = (int)result.StatusCode;

            return result;
        }

        protected T Error<T>(ErrorEnum error, string errorDescription)
           where T : ServiceResult
        {
            T result = (T)Activator.CreateInstance(typeof(T));
            result.StatusCode = ErrorMethods.ToStatusCode(error);
            result.ErrorCode = error;
            result.ErrorDescription = errorDescription;

            Response.StatusCode = (int)result.StatusCode;

            return result;
        }
    }
}