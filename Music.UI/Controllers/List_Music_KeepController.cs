using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.UI.Controllers
{
    public class List_Music_KeepController : Controller
    {
        musicEntities db = new musicEntities();
        // GET: List_Music_Keep
        public ActionResult Index( int id)
        {
            List list = db.List.Find(id);
            var musicss = (from p in db.List_Music_Keep select p).Where(p => p.list_id == id).ToList();
            return View(musicss);
        }

        #region 添加歌曲进歌单
        public ActionResult Add(int music_id)
        {
            int userid = Convert.ToInt32(Session["user_id"].ToString());

            var list = from p in db.List.Where(p => p.user_id == userid)
                        select p;
            var music = db.Music1.Find(music_id);



            var pictureinalbum = new ViewModel.ListViewModel
            {
                List2 = list,
                Music = music,
            };
            return View(pictureinalbum);

        }

        public ActionResult Add2(List_Music_Keep lmk, int listid, int musid)
        {
            if (ModelState.IsValid)
            {
                lmk.list_id  = listid;
                lmk.music_id  = musid;
                db.List_Music_Keep.Add(lmk);
                db.SaveChanges();
                return Content("<script>;alert('添加成功');history.go(-2)</script>");
            }
            return RedirectToAction("Details", "Music");
        }
        #endregion
    }
}