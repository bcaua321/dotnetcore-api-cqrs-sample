using Commerce.Domain.Shared;

namespace ApiCQRS.Core.UserContext
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}