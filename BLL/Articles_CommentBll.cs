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
    public class Articles_CommentBll
    {
        private IArticles_Comment iarticles_comment = DataAccess.CreateArticles_Comment();
        public void InsertAC(Articles_Comment AC)
        {
            iarticles_comment.InsertAC(AC);
        }
    }
}
