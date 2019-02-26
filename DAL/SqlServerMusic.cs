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
    public class SqlServerMusic:SqlServerBase<Music1>,IMusic
    {
        musicEntities db = new musicEntities();
        public override Expression<Func<Music1, bool>> GetByIdKey(int id)
        {
            return u => u.music_id == id;
        }
        public override Expression<Func<Music1, string>> GetKey()
        {
            return u => u.music_mess;
        }
        //删除
        //public int Remove(int id)
        //{
        //    T model = db.Set<T>().Where(GetByIdKey(id)).FirstOrDefault();
        //    db.Set<T>().Remove(model);
        //    return db.SaveChanges();
        //}
        public int Delete(int id)
        {
            Music1 model = db.Set<Music1>().Where(GetByIdKey(id)).FirstOrDefault();
            IQueryable<List_Music_Keep> iquery = db.Set<List_Music_Keep>().Where(u => u.music_id == id);
            db.Set<List_Music_Keep>().RemoveRange(iquery);
            db.Set<Music1>().Remove(model);
            return db.SaveChanges();
        }
    }
}
