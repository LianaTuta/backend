using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TicketService.DAL.Interface;
using TicketService.Models;

namespace TicketService.DAL.Implemenatation
{
    public  class UserAccountRepository:IUserAcccountRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserAccountRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task InserUserAsync(UserModel userModel)
        {
            
            string query = "INSERT INTO Users (Email, Password, RoleId) VALUES (@Email, @Password, @RoleId)";
            _dbConnection.Execute(query, new { Email = userModel.Email, Password = userModel.Password, RoleId = userModel.RoleId });
            
        }

        public async Task<UserModel?> GetUserByEmailAsync(string email)
        {
            string query = "SELECT * FROM Users WHERE Email = @Email";
            return await _dbConnection.QueryFirstOrDefaultAsync<UserModel>(query, new { Email = email });

        }

        public async Task<UserRolesModel?> GetUserRolesById(int id)
        {
            string query = "SELECT * FROM UserRoles WHERE Id = @id";
            return await _dbConnection.QueryFirstOrDefaultAsync<UserRolesModel>(query, new { Id = id });

        }
    }
}
