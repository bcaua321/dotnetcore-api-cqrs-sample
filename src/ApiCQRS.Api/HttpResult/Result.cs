using ApiCQRS.Api.HttpResult.Abstraction;
using ApiCQRS.Application.Enums;
using ApiCQRS.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ApiCQRS.Api.HttpResult
{
    public class Result : Next<OkResult>, IChainResult
    {
        public IActionResult Execute(ResponseResult response)
        {
            // First chain is defined by Next<OkResult>
            return NextResult.Execute(response);
        }
    }
}