using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IUser
    {
        void InsertUsers(Users users);
        int Login(Users user);
        Users GetUsersByName(string user_name);
        List<Users> SelectUsers(string user_name);
        Users GetUsersByID(int user_id);
        void UpdateUsersInfo(Users user);
        int AjaxLogin(string user_name, string user_pwd);
    }
}
