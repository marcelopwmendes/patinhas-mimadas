using Newtonsoft.Json;
using PatinhasMimadas.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PatinhasMimadas.API
{
    public class ServiceResult
    {
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("code")]
        public ErrorEnum ErrorCode { get; set; }


        public string ErrorDescription { get; set; }
    }

    [JsonObject]
    public class ServiceResult<T> : ServiceResult
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        public ServiceResult()
        {
        }

        public ServiceResult(T data)
        : base()
        {
            Data = data;
            StatusCode = HttpStatusCode.OK;
        }
    }

    [JsonObject]
    public class ServiceCollectionResult<T> : ServiceResult<ICollection<T>>
    {
    }
}