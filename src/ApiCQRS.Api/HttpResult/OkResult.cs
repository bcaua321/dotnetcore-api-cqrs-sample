using Microsoft.AspNetCore.Mvc;
using ApiCQRS.Application.Enums;
using ApiCQRS.Api.HttpResult.Abstraction;
using ApiCQRS.Application.Shared;

namespace ApiCQRS.Api.HttpResult
{
    public class OkResult : Next<NotFoundResult>, IChainResult 
    {
        public IActionResult Execute(ResponseResult response)
        {
            if(response.HttpResultEnum == HttpResultEnum.Ok) {
                return new OkObjectResult(response.Result);
            }

            return NextResult.Execute(response);
        }
    }
}