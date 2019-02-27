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
        private IList ilist = DataAccess.CreateList();
        public override IBase<List> GetDal()
        {
            return DataAccess.CreateList();
        }
        public bool Delete(int id)
        {
            return ilist.Delete(id) > 0;
        }
    }
}
