using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Commom;

namespace Music.UI.Controllers
{
    public class List_CommentController : Controller
    {
        musicEntities db = new musicEntities();
        List_CommentBll lc = new List_CommentBll();
        // GET: Album_Comment
        public ActionResult Index(int pageIndex = 1)
        {
            var ac = db.List_Comment.Include(n => n.Users).Include(n => n.List).ToList();
            PagingHelper<List_Comment> ABPaging = new PagingHelper<List_Comment>(10, ac);
            ABPaging.PageIndex = pageIndex;
            return View(ABPaging);

        }

        #region 歌单评论删除
        public ActionResult Delete(int id)
        {
            List_Comment ac = db.List_Comment.Find(id);
            db.List_Comment.Remove(ac);
            db.SaveChanges();
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("Index", "List_Comment") + "','_self');</script>");
        }
        #endregion
    }
}