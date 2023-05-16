using ApiCQRS.Application.Responses;
using MediatR;

namespace ApiCQRS.Application.Queries.UserQueries.DTOs
{
    public class GetUserByIdCommand: IRequest<ResponseQuery<UserDto>>
    {
        public Guid Id { get; set; }
    }
}