using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DAL
{
    public class SqlServerUser:SqlServerBase<Users>,IUser
    {
        musicEntities db = new musicEntities();
        public void InsertUsers(Users users)
        {
            db.Users.Add(users);
            db.SaveChanges();
        }
        public override Expression<Func<Users, bool>> GetByIdKey(int id)
        {
            return u => u.user_id == id;
        }
        public override Expression<Func<Users, string>> GetKey()
        {
            return u => u.user_pwd;
        }
        public int Login(Users users)
        {
            var userss = from u in db.Users
                           where u.user_name == users.user_name && u.user_pwd == users.user_pwd
                           select u;
            int result = userss.Count();
            return result;
        }

        public Users GetUsersByName(string user_name)
        {
            Users userss = (from u in db.Users
                                where u.user_name == user_name
                                select u).FirstOrDefault();
            return userss;
        }
        public List<Users> SelectUsers(string user_name)
        {
            var users = (from u in db.Users
                         where u.user_name == user_name
                         select u).ToList();
            return users;
        }
        //AJSX登录方法？
        public int AjaxLogin(string user_name, string user_pwd)
        {
            var users = from u in db.Users
                        where u.user_name == user_name && u.user_pwd == user_pwd
                        select u;
            return users.Count();
        }
        //通过ID获取用户
        public Users GetUsersByID(int user_id)
        {
            Users users = (from u in db.Users
                          where u.user_id == user_id
                          select u).FirstOrDefault();
            return users;
        }
      
        //更新用户数据
        public void UpdateUserInfo(Users user)
        {
            db.Configuration.ValidateOnSaveEnabled = false;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public void UpdateUsersInfo(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
