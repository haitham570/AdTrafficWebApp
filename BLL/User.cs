using AdTrafficWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdTrafficWebApp.BLL
{
    public class User
    {
        private int userId;
        private string userName;
        private string password;
        private string email;
        private string roleName;

        public int UserId { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string RoleName { get => roleName; set => roleName = value; }
        public string UserName { get => userName; set => userName = value; }

        public User()
        {
            userId = 0;
            password = string.Empty;
            email = string.Empty;
            roleName = string.Empty;
        }

        public bool login(int userId, string password)=>UserDB.AuthenticateUser(userId, password);
        public void Register(User user)=>UserDB.RegisterUser(user);
        public bool IsDuplicateUserID(int user) => UserDB.IsDublicateId(user);



    }
}