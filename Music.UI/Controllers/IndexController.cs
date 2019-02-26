using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.UI.Controllers
{
    public class IndexController : Controller
    {
        musicEntities db = new musicEntities();
        // GET: Index
        public ActionResult Index()
        {

            var articles1 = (from m in db.Articles select m).ToList().Take(5);
            var music1 = (from m in db.Music1 select m).ToList().Take(5);
            //var picture2 = (from p in db.Picture select p).OrderByDescending(p => p.Pic_Point.Count()).ToList().Take(8);
            var news1 = (from p in db.Articles select p).ToList().OrderByDescending(p => p.Articles_Comment.Count()).ToList().Take(10);
            var list1 = (from p in db.List select p).ToList().Take(5);
            var user1 = (from p in db.Users select p).ToList();
            var articles_comment1 = (from p in db.Articles_Comment select p).ToList();
            var index = new Music.UI.ViewModel.IndexViewModel()
            {
                Msuic2 = music1,
                Articles2= articles1,
                Articles1 = news1,
                List=list1,
                
                Users = user1,
                Articles_Comment1 = articles_comment1,
            };
            return View(index);
        }
    }
}