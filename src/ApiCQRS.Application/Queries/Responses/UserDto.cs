using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCQRS.Application.Queries.Responses
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName{ get; set; }

        public string Email { get; set; }
    }
}