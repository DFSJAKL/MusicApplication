using BLL;
using Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Music.UI.Controllers
{
    
    public class ArticlesController : Controller
    {
        
        private musicEntities db = new musicEntities();
        ArticlesBll articlesbll = new ArticlesBll();
        // GET: Articles
        public ActionResult Index()
        {
            var articles1 = (from m in db.Articles select m).ToList().Take(5);
            var music1 = (from m in db.Music1 select m).ToList().Take(5);
            var list1 = (from p in db.List select p).ToList().Take(5);
            var index = new Music.UI.ViewModel.ArticlesViewModel()
            {
                Msuic2 = music1,
                Articles2 = articles1,
                List = list1,

               
            };
            return View(index);
        }

        #region 文章添加
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Articles articles)
        {
            HttpPostedFileBase file = Request.Files["articlesimage"];
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filePath = file.FileName;
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\image\articles\") + fileName;
                    string relativepath = @"/image/articles/" + fileName;
                    file.SaveAs(serverpath);
                    articles.art_image = relativepath;

                }
                articles.mana_id = Convert.ToInt32(Session["mana_id"].ToString());
                articles.art_time = DateTime.Now;
                articlesbll.InsertArticles(articles);
                return Content("<script>alert('添加成功！');window.open('" + Url.Action("Index", "User") + "','_self');</script>");
            }
            return View(articles);
        }
        #endregion

        #region 文章List
        public ActionResult List()
        {
            return View(articlesbll.List());
        }
        #endregion

        #region 文章删除
        public ActionResult Delete(int id)
        {
            Articles articles = db.Articles.Find(id);
            db.Articles.Remove(articles);
            db.SaveChanges();
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("List", "Articles") + "','_self');</script>");
        }
        #endregion

        #region 文章修改
        public ActionResult Edit(int id)
        {
            Articles articles = articlesbll.GetArticlesByID(id);
            return View(articles);
        }
        [HttpPost]
        public ActionResult Edit(Articles articles)
        {
            HttpPostedFileBase file = Request.Files["articlesimage"];
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        string filePath = file.FileName;
                        string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                        string serverpath = Server.MapPath(@"\image\articles\") + fileName;
                        string relativepath = @"/image/articles/" + fileName;
                        file.SaveAs(serverpath);
                        articles.art_image = relativepath;

                    }

                    articles.mana_id = Convert.ToInt32(Session["mana_id"].ToString());
                    articles.art_time = DateTime.Now;
                    db.Entry(articles).State = EntityState.Modified;
                    db.SaveChanges();

                    return Content("<script>alert('修改成功！');window.open('" + Url.Action("List", "Articles") + "','_self');</script>");

                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
            return View(articles);
        }
        #endregion

        #region 文章主页实现分页
        public ActionResult Articles(int? page)
        {
            var articles = from m in db.Articles.OrderByDescending(p => p.art_time)
                       select m;
            int pageSize = 1;
            int pageNumber = (page ?? 1);
            return View(articles.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 文章详细
        public ActionResult Details(int id)
        {
            Articles articles = db.Articles.Find(id);
            var articles1 = from m in db.Articles.OrderByDescending(p => p.art_time) select m;
            var articles_comment = from m in db.Articles_Comment.Where(p => p.art_id == id).OrderByDescending(p => p.ac_time) select m;
            var index = new Music.UI.ViewModel.ArticlesViewModel()
            {
                Articles1 = articles,
                Articles2 = articles1,
                Articles_Comment = articles_comment,
            };
            return View(index);
        }
        #endregion

        #region 文章评论
        [HttpPost]
        public ActionResult NC_Add(Articles_Comment articles_comment)
        {
            if(Session["user_id"] != null)
            {
                string mcmes = Request["mcmes"];
                int mu_id = Convert.ToInt32(Request["mcid"]);

                if (ModelState.IsValid)
                {
                    articles_comment.art_id = mu_id;
                    articles_comment.user_id = Convert.ToInt32(Session["user_id"].ToString());
                    articles_comment.ac_mess = mcmes;
                    articles_comment.ac_time = System.DateTime.Now;
                    db.Articles_Comment.Add(articles_comment);
                    db.SaveChanges();
                    return Content("<script>;alert('评论成功');history.go(-1)</script>");
                }
                return RedirectToAction("Details", "Articles");
            }
            else
            {
                return Content("<script>;alert('你还没有登录哦');history.go(-1)</script>");
            }
        }
        #endregion

        #region 管理员查看文章详细
        public ActionResult Details2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles  articles = db.Articles.Find(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }
        #endregion

    }

}