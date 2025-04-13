using MVProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVProject.Domain.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<bool> EmailExistsAsync(string email);
        Task CreateUserAsync(User user);
    }
}
