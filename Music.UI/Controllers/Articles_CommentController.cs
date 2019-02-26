using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Music.UI.Controllers
{
    public class Articles_CommentController : Controller
    {
        private musicEntities db = new musicEntities();
        // GET: Articles_Comment
        public ActionResult Index()
        {

            var articlescomment = db.Articles_Comment.Include(n => n.Users).Include(n => n.Articles);
            return View(articlescomment.ToList());
        }

        #region 文章评论详细
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles_Comment articlescomment = db.Articles_Comment.Find(id);
            if (articlescomment == null)
            {
                return HttpNotFound();
            }
            return View(articlescomment);
        }
        #endregion

        #region 新闻评论删除 
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles_Comment articlescomment = db.Articles_Comment.Find(id);
            if (articlescomment == null)
            {
                return HttpNotFound();
            }
            return View(articlescomment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articles_Comment articlescomment = db.Articles_Comment.Find(id);
            db.Articles_Comment.Remove(articlescomment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}