using Gestiminio.Business;
using Gestiminio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Gestiminio.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        UserBusiness userBusiness = new UserBusiness();

        [HttpGet]
        public User getLogin(string email, string pwd) {
            var user = userBusiness.getlogin(email, pwd);
            return user;
        }

        [HttpPost]
        public string createUser(User user)
        {
            string msg = "";
            msg = userBusiness.addUser(user);
            return msg;
        }

        [HttpGet]
        public List<User> getAllUsers()
        {
            var list = userBusiness.getUsersList();
            return list;
        }

        [HttpGet]
        public User getUserById(int userId)
        {
            var list = userBusiness.getUsersList();
            User user = list.FirstOrDefault(x => x.userId == userId);
            return user;
        }


        [HttpPost]
        public string updateUser(User user)
        {
            string msg = "";
            msg = userBusiness.updateUser(user);
            return msg;
        }

        [HttpPost]
        public string deleteUser(int UserId)
        {
            string msg = "";
            msg = userBusiness.deleteUser(UserId);
            return msg;
        }
    }
}
