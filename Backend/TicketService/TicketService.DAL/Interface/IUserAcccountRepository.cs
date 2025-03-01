using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Models;

namespace TicketService.DAL.Interface
{
    public interface IUserAcccountRepository
    {
        public Task InserUserAsync(UserModel userModel);
        public Task<UserModel?> GetUserByEmailAsync(string email);
        public Task<UserRolesModel?> GetUserRolesById(int id);
    }
}
