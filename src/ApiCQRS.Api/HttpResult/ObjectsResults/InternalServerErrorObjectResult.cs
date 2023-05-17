using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ApiCQRS.Api.HttpResult.ObjectsResults
{
    public class ServerErrorObjectResult : ObjectResult
    {
        public ServerErrorObjectResult(object value) : base(value)
        {
            this.StatusCode = 500;
        }
    }
}