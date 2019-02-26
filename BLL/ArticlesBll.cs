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
    public class ArticlesBll
    {
        private IArticles iarticles = DataAccess.CreateArticles();
        public void InsertArticles(Articles articles)
        {
            iarticles.InsertArticles(articles);
        }
        public List<Articles> SelectArticles(string art_name)
        {
            return iarticles.SelectArticles(art_name);
        }
        public Articles GetArticlesByID(int art_id)
        {
            return iarticles.GetArticlesByID(art_id);
        }
        public Articles GetArticlesByName(string art_name)
        {
            return iarticles.GetArticlesByName(art_name);
        }

        public IQueryable<Articles> List()
        {
            return iarticles.List();
        }
    }
}
