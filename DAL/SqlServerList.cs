using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlServerList : SqlServerBase<List>, IList
    {
        public override Expression<Func<List, bool>> GetByIdKey(int id)
        {
            return u => u.list_id == id;
        }
        public override Expression<Func<List, string>> GetKey()
        {
            return u => u.list_mess;
        }
    }
}
