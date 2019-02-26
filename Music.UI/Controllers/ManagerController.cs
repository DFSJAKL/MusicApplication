﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Commom;
using Model;

namespace Music.UI.Controllers
{
    public class ManagerController : Controller
    {
        private musicEntities db = new musicEntities();
        ManagerBLL mb = new ManagerBLL();
        // GET: Manager
        public ActionResult Index(int pageIndex = 1)
        {
            var pt = mb.GetAll();
            PagingHelper<Manager> ManagerPaging = new PagingHelper<Manager>(10, pt);
            ManagerPaging.PageIndex = pageIndex;
            return View(ManagerPaging);
            //var managers = db.Manager;
            //return View(managers.ToList());
        }
        public ActionResult Index1(int pageIndex = 1)
        {
            var pt = mb.GetAll();
            PagingHelper<Manager> ManagerPaging = new PagingHelper<Manager>(10, pt);
            ManagerPaging.PageIndex = pageIndex;
            return View(ManagerPaging);
            //var managers = db.Manager;
            //return View(managers.ToList());
        }

        #region 管理员添加
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Manager manager)
        {
            if(ModelState.IsValid)
            {
                manager.mana_time = DateTime.Now;
                mb.Add(manager);
                return Content("<script>alert('添加成功！');window.open('" + Url.Action("Index1", "Manager") + "','_self');</script>");
            }
            return View(manager);
        }
        #endregion

        #region 管理员登录
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Manager manager,string returnUrl)
        {
            int u = mb.Login(manager);
            if(u>0)
            {
                Session["mana_name"] =manager.mana_name;
                Manager managers = mb.GetManagerByName(Session["mana_name"].ToString());
                Session["mana_id"] = managers.mana_id;
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Content("<script>alert('登录成功！');window.open('" + Url.Action("Index1", "Manager") + "','_self');</script>");
                }
            }
            else
            {
                return Content("<script>alert('用户名或密码错误！');window.open('" + Url.Content("~/Manager/Login") + "', '_self')</script>");
            }
        }
        #endregion

        #region 管理员退出登录
        public ActionResult LogOff()
        {
            Session["mana_name"] = null;
            Session["mana_id"] = null;
            return RedirectToAction("Index", "Index");
        }
        #endregion

        #region 删除管理员
        public ActionResult Delete(int? id)
        {
            Manager manager = db.Manager.Find(id);
            db.Manager.Remove(manager);
            db.SaveChanges();
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("Index1", "Manager") + "','_self');</script>");

        }

        #endregion

        #region 修改管理员
        public ActionResult Edit(int id)
        {
            Manager manager = mb.GetManagerByID(id);
            return View(manager);
        }
        [HttpPost]
        public ActionResult Edit(Manager manager)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    manager.mana_time = DateTime.Now;
                    db.Entry(manager).State = EntityState.Modified;
                    db.SaveChanges();
                    return Content("<script>alert('修改成功！');window.open('" + Url.Action("Index1", "Manager") + "','_self');</script>");
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
            return View(manager);
        }
        #endregion
    }
}