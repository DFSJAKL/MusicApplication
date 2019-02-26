using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using Model;
using IDAL;

namespace BLL
{
    public class UserBLL/*:BaseManager<Users>*/
    {
        private IUser iuser = DataAccess.CreateUsers();
        //public override IBase<Users> GetDal()
        //{
        //    return DataAccess.CreateUsers();
        //}
        public int Login(Users users)
        {
            return iuser.Login(users);
        }
        public Users GetUsersByName(string user_name)
        {
            return iuser.GetUsersByName(user_name);
        }
        public void InsertUsers(Users users)
        {
            iuser.InsertUsers(users);
        }
        public void UpdateUsersInfo(Users user)
        {
            iuser.UpdateUsersInfo(user);
            
        }
        public Users GetUsersByID(int user_id)
        {
            return iuser.GetUsersByID(user_id);
        }
        public int AjaxLogin(string user_name, string user_id)
        {
            return iuser.AjaxLogin(user_name, user_id);
        }
        public List<Users> SelectUsers(string user_name)
        {
            return iuser.SelectUsers(user_name);
        }
    }
}
