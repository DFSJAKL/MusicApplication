using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
     public interface IArticles
    {
        void InsertArticles(Articles news);
        List<Articles> SelectArticles(string News_Name);
        Articles GetArticlesByID(int News_ID);
        Articles GetArticlesByName(string News_Name);

        IQueryable<Articles> List();
    }
}
