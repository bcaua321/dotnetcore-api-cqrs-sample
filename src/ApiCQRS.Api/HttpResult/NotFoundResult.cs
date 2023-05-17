using ApiCQRS.Api.HttpResult.Abstraction;
using ApiCQRS.Application.Enums;
using ApiCQRS.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ApiCQRS.Api.HttpResult
{
    public class NotFoundResult : Next<BadRequestResult>, IChainResult 
    {
        public IActionResult Execute(ResponseResult response)
        {
            if(response.HttpResultEnum == HttpResultEnum.NotFound) {
                return new BadRequestObjectResult(response.Result);
            }

            return NextResult.Execute(response);
        }
    }
}