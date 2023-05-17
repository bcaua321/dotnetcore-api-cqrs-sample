using Microsoft.AspNetCore.Mvc;
using ApiCQRS.Application.Enums;
using ApiCQRS.Application.Shared;

namespace ApiCQRS.Api.HttpResult.Abstraction
{
    public interface IChainResult
    {
        // Execute according with the HttpResultEnum value
        IActionResult Execute(ResponseResult response);
    }
}