using Microsoft.AspNetCore.Mvc;
using ApiCQRS.Application.Enums;
using ApiCQRS.Application.Shared;

namespace ApiCQRS.Api.HttpResult.Abstraction
{
    public interface IChainResult
    {
        IActionResult Execute(ResponseResult response);
    }
}