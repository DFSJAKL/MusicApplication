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
    }
}
