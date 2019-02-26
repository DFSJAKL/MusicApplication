using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlServerMusic_Comment:IMusic_Comment
    {
        musicEntities db = new musicEntities();
        public IEnumerable<Music_Comment> GetPC(int mcid)
        {
            var data = (from p in db.Music_Comment
                        where p.mc_id  == mcid
                        select p).OrderBy(p => p.mc_time);
            return data;
        }
        public void InsertPC(Music_Comment mcmes)
        {
            db.Music_Comment.Add(mcmes);
            db.SaveChanges();
        }
        public int Music_CommentCount(int mcid)
        {
            var data = (from p in db.Music_Comment
                        where p.mc_id == mcid
                        select p).Count();
            return data;
        }
    }
}
