using ApiCQRS.Application.Queries.Responses;
using ApiCQRS.Application.Shared;
using MediatR;

namespace ApiCQRS.Application.Queries.UserQueries.DTOs
{
    public class GetUserByIdCommand: IRequest<ResponseResult>
    {
        public Guid Id { get; set; }
    }
}