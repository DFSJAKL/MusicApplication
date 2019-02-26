using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.UI.Controllers
{
    public class List_KeepController : Controller
    {
        musicEntities db = new musicEntities();
        // GET: List_Keep
        public ActionResult Index()
        {
            return View();
        }
        #region 删除相册收藏
        public ActionResult Delete(int id)
        {
            int user_id = Convert.ToInt32(Session["user_id"].ToString());
            var chk_member = db.List_Keep.Where(o => o.user_id == user_id).Where(o => o.list_id == id).FirstOrDefault();
            List_Keep  album_save = db.List_Keep.Remove(chk_member);
            db.SaveChanges();
            return Content("<script>;alert('删除收藏成功！');history.go(-1)</script>");
        }
        #endregion 
    }
}