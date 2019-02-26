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
    public class SqlServerMusic_Type : SqlServerBase<Music_Type>, IMusic_Type
    {
        public override Expression<Func<Music_Type, bool>> GetByIdKey(int id)
        {
            return u => u.type_id == id;
        }

        public override Expression<Func<Music_Type, string>> GetKey()
        {
            return u => u.type_id.ToString();
        }
        musicEntities db = new musicEntities();
        public Music_Type SelectID(int id)
        {
            return db.Set<Music_Type>().Where(u => u.type_id == id).FirstOrDefault();
        }
        public int DeleteID(int id)
        {
            Music_Type model = db.Set<Music_Type>().Where(u => u.type_id == id).FirstOrDefault();
            db.Set<Music_Type>().Remove(model);
            return db.SaveChanges();
        }
    }
}