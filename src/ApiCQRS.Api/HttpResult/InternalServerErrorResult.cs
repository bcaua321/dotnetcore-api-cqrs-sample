using ApiCQRS.Api.HttpResult.Abstraction;
using ApiCQRS.Api.HttpResult.ObjectsResults;
using ApiCQRS.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ApiCQRS.Api.HttpResult
{
    public class InternalServerErrorResult : IChainResult
    {
        public IActionResult Execute(ResponseResult response)
        {
            return new ServerErrorObjectResult(response.Result);
        }
    }
}