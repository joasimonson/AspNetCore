using System;

namespace AspNetCore.Domain.DTO.User
{
    public class UserUpdatedDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}