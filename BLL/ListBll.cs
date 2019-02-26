using DALFactory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ListBll : BaseManager<List>
    {
        public override IBase<List> GetDal()
        {
            return DataAccess.CreateList();
        }
    }
}
