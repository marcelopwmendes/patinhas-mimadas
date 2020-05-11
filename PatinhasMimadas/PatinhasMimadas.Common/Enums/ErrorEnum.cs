using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PatinhasMimadas.Common.Enums
{
    public enum ErrorEnum
    {
        None = 0,
        NotFound = 1,
        System = 2,
        BadRequest = 3,
        Unauthorized = 4
    }

    public static class ErrorMethods
    {
        public static HttpStatusCode ToStatusCode(ErrorEnum error)
        {
            switch (error)
            {
                case ErrorEnum.NotFound:
                    return HttpStatusCode.NotFound;

                case ErrorEnum.System:
                    return HttpStatusCode.InternalServerError;

                case ErrorEnum.None:
                    return HttpStatusCode.OK;

                case ErrorEnum.Unauthorized:
                    return HttpStatusCode.Unauthorized;

                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}