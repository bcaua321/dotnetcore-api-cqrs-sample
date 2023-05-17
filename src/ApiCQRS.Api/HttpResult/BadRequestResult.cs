using ApiCQRS.Api.HttpResult.Abstraction;
using ApiCQRS.Application.Enums;
using ApiCQRS.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ApiCQRS.Api.HttpResult
{
    public class BadRequestResult : Next<InternalServerErrorResult>, IChainResult
    {
        public IActionResult Execute(ResponseResult response)
        {
            if(response.HttpResultEnum.Equals(HttpResultEnum.Badrequest))
            {
                return new BadRequestObjectResult(response.Result);
            }

            return NextResult.Execute(response);
        }
    }
}