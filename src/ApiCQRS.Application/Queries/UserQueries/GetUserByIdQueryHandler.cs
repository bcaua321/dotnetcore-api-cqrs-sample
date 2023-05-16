using ApiCQRS.Application.Queries.UserQueries.DTOs;
using ApiCQRS.Application.Responses;
using ApiCQRS.Core.UserContext;
using MediatR;

namespace ApiCQRS.Application.Queries.UserQueries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdCommand, ResponseQuery<UserDto>>
    {
        private IUserReadOnlyRepository _repository { get; }

        public GetUserByIdQueryHandler(IUserReadOnlyRepository _repository) 
        {
            this._repository = _repository;
        }

        public async Task<ResponseQuery<UserDto>> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            ResponseQuery<UserDto> response;
            var result = await _repository.FindById(request.Id);

            if(result is null) 
            {
                response = new ResponseQuery<UserDto> { Message = $"Usuário com o Id {request.Id} não encontrado", Sucess = false };  
                return response;
            }

            var resultDto = new UserDto 
            {
                Id = result.Id,
                Name = result.Name,
                LastName = result.LastName,
                Email = result.Email
            };

            return response =  new ResponseQuery<UserDto> { Result = resultDto };
        }
    }
}