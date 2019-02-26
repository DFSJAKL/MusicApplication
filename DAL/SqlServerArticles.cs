using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlServerArticles:IArticles
    {
        musicEntities db = new musicEntities();
        public void InsertArticles(Articles articles)
        {
            db.Articles.Add(articles);
            db.SaveChanges();
        }
        public List<Articles> SelectArticles(string art_name)
        {
            var articles = (from u in db.Articles
                        where u.art_name == art_name
                        select u).ToList();
            return articles;
        }
        public Articles GetArticlesByID(int art_id)
        {
            Articles articles = (from u in db.Articles
                         where u.art_id == art_id
                         select u).FirstOrDefault();
            return articles;
        }
        public Articles GetArticlesByName(string art_name)
        {
            Articles articles = (from u in db.Articles
                             where u.art_name == art_name
                         select u).FirstOrDefault();
            return articles;
        }


        public IQueryable<Articles> List()
        {
            return db.Set<Articles>();
        }
    }
}
