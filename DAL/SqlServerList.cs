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
        musicEntities db = new musicEntities();
        public override Expression<Func<List, bool>> GetByIdKey(int id)
        {
            return u => u.list_id == id;
        }
        public override Expression<Func<List, string>> GetKey()
        {
            return u => u.list_mess;
        }
        public int Delete(int id)
        {
            List model = db.Set<List>().Where(GetByIdKey(id)).FirstOrDefault();
            IQueryable<List_Keep> list = db.Set<List_Keep>().Where(u => u.list_id == id);
            IQueryable<List_Comment> iquer = db.Set<List_Comment>().Where(u => u.list_id == id);
            IQueryable<List_Music_Keep> iquery = db.Set<List_Music_Keep>().Where(u => u.list_id == id);
            db.Set<List_Comment>().RemoveRange(iquer);
            db.Set<List_Music_Keep>().RemoveRange(iquery);
            db.Set<List_Keep>().RemoveRange(list);
            db.Set<List>().Remove(model);
            return db.SaveChanges();
        }
    }
}
