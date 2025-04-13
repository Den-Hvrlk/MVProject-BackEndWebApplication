using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVProject.Application.DTOs;

namespace MVProject.Application.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateUserAsync(CreateUserRequest request);
    }
}
