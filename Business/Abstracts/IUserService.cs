﻿using Entity.Concretes.Models;
using System.Linq.Expressions;

namespace Business.Abstracts
{
    public interface IUserService
    {
        bool Add(User user);
        bool Update(User user);
        bool Delete(int userId);
        List<User> GetUsers(Expression<Func<ToDo, bool>> filter);
        User GetUser(int userId);
        User GetUserByMail(string userMailAddress);
    }
}
