using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlServerList_Comment : SqlServerBase<List_Comment>
    {
        public override Expression<Func<List_Comment, bool>> GetByIdKey(int id)
        {
            return u => u.lc_id == id;
        }
        public override Expression<Func<List_Comment, string>> GetKey()
        {
            return u => u.lc_mess;
        }
    }
}
