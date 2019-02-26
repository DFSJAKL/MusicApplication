using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlServerArticles_Comment
    {
        musicEntities db = new musicEntities();
        public void InsertAC(Articles_Comment AC)
        {
            db.Articles_Comment.Add(AC);
        }
    }
}
