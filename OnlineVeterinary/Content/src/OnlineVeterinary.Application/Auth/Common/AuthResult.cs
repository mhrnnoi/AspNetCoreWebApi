using System;
using OnlineVeterinary.Domain.Role.Enums;

namespace OnlineVeterinary.Application.Auth.Common
{
    public record AuthResult(Guid Id,  string FirstName, string LastName, string Email, string Password, string Role, string Token);
    
    
}
