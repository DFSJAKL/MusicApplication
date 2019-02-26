using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using System.Linq.Expressions;
using Music.UI.ViewModel;
using PagedList;
using Commom;

namespace Music.UI.Controllers
{
    public class MusicController : Controller
    {
        musicEntities db = new musicEntities();
        MusicBLL mb = new MusicBLL();
        Music_TypeBll mtb = new Music_TypeBll();

        public ActionResult Index1(String musicInfoFrom, string currentFilter, int? page)
        {
            var music1 = (from p in db.Music1 select p).OrderByDescending(p=>p.music_time).Take(6);
            
            var list = (from l in db.List select l).ToList();
            var index = new Music.UI.ViewModel.MusicViewModel()
            {
                Musics = music1,
                List1 = list,
                
            };
            return PartialView("Index1", index);
        }

        public ActionResult Index2(String musicInfoFrom, string currentFilter, int? page)
        {
            var music1 = (from p in db.Music1 select p).OrderByDescending(p => p.music_time).Take(6);

            var list = (from l in db.List select l).ToList();
            var index = new Music.UI.ViewModel.MusicViewModel()
            {
                Musics = music1,
                List1 = list,
            };
            return PartialView("Index2", index);
        }
        // GET: Music
        public ActionResult Music(int ? page)
        {
            var music = from a in db.Music1.OrderByDescending(a => a.music_time)
                        select a;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(music.ToPagedList(pageNumber, pageSize));
        }

        

        #region 音乐上传
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Music1 music1)
        {
            HttpPostedFileBase file = Request.Files["music"];
            HttpPostedFileBase file2 = Request.Files["image"];
            if (music1!=null)
            {
                if(file!=null)
                {
                    string filePath = file.FileName;
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\Music\") + fileName;
                    string relativepath = @"/Music/" + fileName;
                    file.SaveAs(serverpath);
                    music1.music_music= relativepath;
                }
                if (file2 != null)
                {
                    string filePath = file2.FileName;
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\image\music\") + fileName;
                    string relativepath = @"/image/music/" + fileName;
                    file2.SaveAs(serverpath);
                    music1.music_image = relativepath;
                }
                music1.type_id = 1;
                music1.mana_id= Convert.ToInt32(Session["mana_id"].ToString());
                music1.music_time = DateTime.Now;
                mb.Add(music1);
                return Content("<script>alert('创建成功！');window.open('" + Url.Action("List", "Music") + "','_self');</script>");
            }
            return View(music1);
        }

        #endregion

        #region 后台管理
        public ActionResult List(int pageIndex = 1)
        {
            var music = mb.GetAll();
            //var picturetype = ptm.GetAll();
            //var picturemodel = from a in picture
            //                   join b in picturetype on a.Type_ID equals b.Type_ID
            //                   select new PictureViewModel
            //                   {
            //                       Pic_ID = a.Pic_ID,
            //                       User_ID = a.User_ID,
            //                       Pic_Pic = a.Pic_Pic,
            //                       Type_ID = b.Type_ID,
            //                       Pic_Mes = a.Pic_Mes,
            //                       Pic_Time = a.Pic_Time
            //                   };
            PagingHelper<Music1> PicturePaging = new PagingHelper<Music1>(5, music); //初始化分页器以及显示数量
            PicturePaging.PageIndex = pageIndex; // 指定当前页
            return View(PicturePaging);//返回分页器实例到视图
        }
        #endregion

        #region 删除音乐
        public ActionResult Delete(int id)
        {
            var temp = mb.Delete(id);
            if (temp == true)
                return Content("<script>alert('删除成功！');window.open('" + Url.Action("List", "Music") + "','_self');</script>");
            else
                return View();
        }
        #endregion
         
       

        #region 音乐详细
        public ActionResult Details(int id)
        {

            Music1 musics = db.Music1.Find(id);
            //Pic_Point pp = db.Pic_Point.Find(id);
            //var picpoint = from p in db.Pic_Point.Where(p => p.Pic_ID == id)
            //               select p;


            var music1 = from p in db.Music1.OrderByDescending(p => p.music_time)
                            select p;
            var music_comment = from pc in db.Music_Comment.Where(p => p.music_id == id)/*.OrderByDescending(p => p.music_time)*/
                              select pc;
            var index = new Music.UI.ViewModel.MusicViewModel()
            {
                Musics = music1,
                Music2 = musics,
                
                Music_Comment = music_comment,
            };

            return View(index);
        }
        #endregion

        #region 歌曲分页
         

        public ActionResult Music1(int? page)
        {
            var picture = from a in db.Music1.OrderByDescending(a => a.music_time)
                          select a;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(picture.ToPagedList(pageNumber, pageSize));
        }


        #endregion


    }
}