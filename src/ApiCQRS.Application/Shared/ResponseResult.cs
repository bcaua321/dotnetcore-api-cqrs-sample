using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCQRS.Application.Enums;

namespace ApiCQRS.Application.Shared
{
    public class ResponseResult
    {
        public HttpResultEnum HttpResultEnum { get; set; }
        public Object Result { get; set; }
        public ResponseResult(HttpResultEnum httpResultEnum, Object result) 
        {
            this.HttpResultEnum = httpResultEnum;
            this.Result = result;
        }
    }
}