using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using Commom;
using PagedList;
using Music.UI.ViewModel;
using System.Net;
using System.Data.Entity;


namespace Music.UI.Controllers
{
    public class ListController : Controller
    {
        ListBll listt = new ListBll();

        musicEntities db = new musicEntities();

        #region 歌单主页
        // GET: List
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int ? page)
        {
            var list = from a in db.List.OrderByDescending(a => a.list_time)
                        select a;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 歌单创建
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(List list)
        {
            HttpPostedFileBase file = Request.Files["listimage"];
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filePath = file.FileName;
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\image\list\") + fileName;
                    string relativepath = @"/image/list/" + fileName;
                    file.SaveAs(serverpath);
                    list.list_image = relativepath;
                }
                

                list.list_time = DateTime.Now;
                listt.Add(list);

                return Content("<script>alert('添加成功！');window.open('" + Url.Action("Index2", "Music") + "','_self');</script>");
            }
            return View(list);
        }
        #endregion


        

        #region 歌单评论
        [HttpPost]
        public ActionResult Details(List_Comment list_comment)
        {
            string acmes = Request["acmes"];
            int alb_id = Convert.ToInt32(Request["albid"]);

            if (ModelState.IsValid)
            {

                list_comment.list_id = alb_id;
                list_comment.user_id = Convert.ToInt32(Session["user_id"].ToString());
                list_comment.lc_mess = acmes;
                list_comment.lc_time = System.DateTime.Now;
                db.List_Comment.Add(list_comment);
                db.SaveChanges();
                return Content("<script>;alert('评论成功');history.go(-1)</script>");
            }
            return RedirectToAction("Details", "List");
        }
        #endregion

        #region 歌单收藏
        public ActionResult Save(List_Keep albsave, int list_id)
        {
            var album = db.List.Find(list_id);
            int albid = list_id;
            if (ModelState.IsValid)
            {
                albsave.list_id = albid;
                albsave.user_id = Convert.ToInt32(Session["user_id"].ToString());
                albsave.lk_time = DateTime.Now;
                db.List_Keep.Add(albsave);
                db.SaveChanges();
                return Content("<script>;alert('成功!');history.go(-1)</script>");
            }
            return Redirect("Details");
        }
        #endregion

        #region 删除歌单
        public ActionResult Delete(int id)
        {
            var temp = listt.Delete(id);
            if (temp == true)
                return Content("<script>alert('删除成功！');window.open('" + Url.Action("List1", "List") + "','_self');</script>");
            else
                return View();
        }
        #endregion

        #region 后台管理
        public ActionResult List1(int pageIndex = 1)
        {
            //var album = db.Album.Include(n => n.Album_Point).Include(n=>n.Album_Save).ToList();
            var album = listt.GetAll();
            PagingHelper<List> AlbumPaging = new PagingHelper<List>(5, album);
            AlbumPaging.PageIndex = pageIndex;
            return View(AlbumPaging);
        }
        #endregion

        #region 歌单详细
        public ActionResult Details(int id)
        {
            List lists = db.List.Find(id);

            var list_music_keep = from p in db.List_Music_Keep.Where(p => p.list_id == id)
                                  select p;
            //var pictures = (from p in db.Picture_In_Album select p).Where(p => p.Alb_ID == id).ToList();

            var list1 = from a in db.List.OrderByDescending(p => p.list_time)
                        select a;
            var music1 = (from p in db.Music1 select p).OrderByDescending(p => p.music_time).Take(5);

            var list = (from l in db.List select l).ToList().Take(5);
            var list_comment = from m in db.List_Comment.Where(p => p.list_id == id).OrderByDescending(p => p.lc_time)
                               select m;
            var list_keep = from m in db.List_Keep.Where(p => p.list_id == id)
                            select m;
            var index = new Music.UI.ViewModel.ListViewModel()
            {
                List1 = lists,
                List2 = list1,
                List_Comment = list_comment,
                //List3 = list,
                List_Keep = list_keep,
                List_Music_Keep = list_music_keep,
            };
            return View(index);
        }
        #endregion


    }
}