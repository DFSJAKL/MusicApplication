using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Commom;

namespace Music.UI.Controllers
{
    public class Music_TypeController : Controller
    {
        // GET: Music_Type
      
        BLL.Music_TypeBll  ptmanager = new BLL.Music_TypeBll();
        #region 音乐类别分页
        public ActionResult Index(int pageIndex = 1)
        {
            var pt = ptmanager.GetAll();
            PagingHelper<Music_Type> PicturePaging = new PagingHelper<Music_Type>(3, pt); //初始化分页器
            PicturePaging.PageIndex = pageIndex; //指定当前页
            return View(PicturePaging); //返回分页器实例到视图
        }
        #endregion

        #region 添加
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Music_Type pt)
        {
            if (ModelState.IsValid)
            {
                Music_Type @type = new Music_Type
                {
                    name = pt.name
                };
                var temp = ptmanager.Add(@type);
                if (temp == true)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(pt);
        }
        #endregion

        #region 修改
        public ActionResult Edit(int id)
        {
            Music_Type pt = ptmanager.SelectID(id);
            return View(pt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Music_Type pt)
        {
            ptmanager.Edit(pt);
            return RedirectToAction("Index");
        }
        #endregion

        #region 删除
        public ActionResult Delete(int id)
        {
            ptmanager.DeleteID(id);
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("Index", "Music_Type") + "','_self');</script>");
        }
        #endregion
    }
}