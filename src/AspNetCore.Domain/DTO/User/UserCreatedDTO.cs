using System;

namespace AspNetCore.Domain.DTO.User
{
    public class UserCreatedDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
    }
}