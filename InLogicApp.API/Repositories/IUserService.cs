using System;
using InLogicApp.API.Entities;
using InLogicApp.API.Model.Users;

namespace InLogicApp.API.Repositories
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Register(RegisterRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
}
