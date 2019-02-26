using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IManager : IBase<Manager>
    {
        int Login(Manager manager);
        Manager GetManagerByName(string mana_name);
        Manager GetManagerByID(int mana_id);
    }
} 
