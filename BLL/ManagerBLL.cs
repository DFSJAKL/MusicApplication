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
    public class ManagerBLL:BaseManager<Manager>
    {
        private IManager imanager = DataAccess.CreateManager();
        public override IBase<Manager> GetDal()
        {
            return DataAccess.CreateManager();
        }
        public int Login(Manager manager)
        {
            return imanager.Login(manager);
        }
        public Manager GetManagerByName(string mana_name)
        {
            return imanager.GetManagerByName(mana_name);
        }
        public Manager GetManagerByID(int mana_id)
        {
            return imanager.GetManagerByID(mana_id);
        }
    }
}
