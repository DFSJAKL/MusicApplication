using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Music.UI.Controllers
{
    public class Music_CommentController : Controller
    {
        musicEntities db = new musicEntities();
        Music_CommentBll music_commentbll = new Music_CommentBll();
        // GET: Pic_Comment
        public ActionResult Index()
        {
            var mc = db.Music_Comment.Include(n => n.Users).Include(n => n.Music1);
            return View(mc.ToList());

        }


        #region 发表歌曲评论
        [HttpPost] 
        public ActionResult Comments(Music_Comment mccomment)
        {
            string textarea = Request["textarea"];
            int music_id = Convert.ToInt32(Request["music_id"]);
            if (ModelState.IsValid)
            { 
                mccomment.user_id = Convert.ToInt32(Session["user_id"].ToString());
                mccomment.mc_mess = textarea;
                mccomment.mc_time = DateTime.Now;
                db.Music_Comment.Add(mccomment);
                db.SaveChanges();
                return Content("<script>alert('评论成功！');window.open('" + Url.Action("Details", "Music", new { id = music_id }) + "','_self');</script>");

            }
            return RedirectToAction("Details", "Music");
        }
        #endregion

        #region 歌曲评论删除
        public ActionResult Delete(int id)
        {
            Music_Comment mc = db.Music_Comment.Find(id);
            db.Music_Comment.Remove(mc);
            db.SaveChanges();
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("Index", "Music_Comment") + "','_self');</script>");
        }
        #endregion
    }
}