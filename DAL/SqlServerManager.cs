using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using System.Linq.Expressions;

namespace DAL
{
    public class SqlServerManager:SqlServerBase<Manager>,IManager
    {
        musicEntities db = new musicEntities();
        public override Expression<Func<Manager,bool>> GetByIdKey(int id)
        {
            return u => u.mana_id == id;
        }
        public override Expression<Func<Manager,string>> GetKey()
        {
            return u => u.mana_pwd;
        }
        public int Login(Manager manager)
        {
            var managers = from u in db.Manager
                           where u.mana_name == manager.mana_name && u.mana_pwd == manager.mana_pwd
                           select u;
            int result = managers.Count();
            return result;
        }

        public Manager GetManagerByName(string mana_name)
        {
            Manager managers = (from u in db.Manager
                                where u.mana_name == mana_name
                                select u).FirstOrDefault();
            return managers;
        }
        public Manager GetManagerByID(int mana_id)
        {
            Manager managers = (from u in db.Manager
                                where u.mana_id == mana_id
                                select u).FirstOrDefault();
            return managers;
        }
    }
}
