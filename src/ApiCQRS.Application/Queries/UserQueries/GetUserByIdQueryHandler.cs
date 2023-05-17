using ApiCQRS.Application.Enums;
using ApiCQRS.Application.Queries.Responses;
using ApiCQRS.Application.Queries.UserQueries.DTOs;
using ApiCQRS.Application.Shared;
using ApiCQRS.Core.UserContext;
using MediatR;

namespace ApiCQRS.Application.Queries.UserQueries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdCommand, ResponseResult>
    {
        private IUserReadOnlyRepository _repository { get; }

        public GetUserByIdQueryHandler(IUserReadOnlyRepository _repository) 
        {
            this._repository = _repository;
        }

        public async Task<ResponseResult> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            ResponseResult response;
            User result = null;

            try
            {
                result = await _repository.FindById(request.Id);
            }
            catch 
            {
                response = new ResponseResult(HttpResultEnum.InternalServerError, $"Error With Server");
                return response;
            }

            if(result is null) 
            {
                response = new ResponseResult(HttpResultEnum.NotFound, $"User with Id {request.Id} not found");
                return response;
            }

            var resultDto = new UserDto 
            {
                Id = result.Id,
                Name = result.Name,
                LastName = result.LastName,
                Email = result.Email
            };

            response =  new ResponseResult(HttpResultEnum.Ok, resultDto);
            return response;
        }
    }
}