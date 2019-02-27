using System;
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
    public class UserController : Controller
    {
        musicEntities db = new musicEntities();
        UserBLL ub = new UserBLL();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        #region 用户添加
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Users users)
        {
            if(users!=null)
            {
                users.user_time = DateTime.Now;
                db.Users.Add(users);
                db.SaveChanges();
                return Content("<script>alert('添加成功！');window.open('" + Url.Action("Index", "User") + "','_self');</script>");
            }
            return View(users);
        }
        #endregion

        #region 用户登录
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users users,string returnUrl)
        {
            int u = ub.Login(users);
            if(u>0)
            {
                Session["user_name"] = users.user_name;
                Users userss = ub.GetUsersByName(Session["user_name"].ToString());
                Session["user_id"] = userss.user_id;
                
                if(returnUrl!=null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Content("<script>alert('登录成功！');window.open('" + Url.Action("Index", "Index") + "','_self');</script>");
                }

            }
            else
            {
                return Content("<script>alert('用户名或密码错误！');window.open('" + Url.Content("~/User/Login") + "', '_self')</script>");
            }
        }
        #endregion

        #region 用户名检测

        [HttpPost]
        public string CheckUser(string user_name)
        {
            var result = ub.SelectUsers(user_name);
            if (result.Count() > 0)
            {
                return "用户名已存在，请重新输入!!";
            }
            else
            {
                return "该用户名未被注册，可以使用！";
            }
        }
        #endregion

        #region 用户异步登录
        public string AjaxLogin(string user_name, string user_pwd)
        {
            int result = ub.AjaxLogin(user_name, user_pwd);
            if (result > 0)
            {
                Users user = ub.GetUsersByName(user_name);
                Session["user_name"] = user_name;
                Session["user_id"] = user.user_id;
                return "登录成功.";
            }
            else
            {
                return "用户名或密码错误!";
            }
        }
        #endregion

        #region 退出登录
        public ActionResult LoginOut()
        {
            Session["user_name"] = null;
            return Content("<script>alert('账号退出成功');window.location.href = document.referrer;</script>");
        }
        #endregion

        #region 用户修改个人信息
        public ActionResult Edit(int id)
        {
            Users user = ub.GetUsersByID(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(Users user)
        {
            HttpPostedFileBase file = Request.Files["image"];
            if (ModelState.IsValid)
            {
                try
                {
                    //if (file != null)
                    //{
                    //    string filePath = file.FileName;
                    //    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    //    string serverpath = Server.MapPath(@"\images\users\") + fileName;
                    //    string relativepath = @"/images/users/" + fileName;
                    //    file.SaveAs(serverpath);
                    //    user.User_Img = relativepath;

                    //}


                    user.user_time = DateTime.Now;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return Content("<script>alert('修改成功！');window.open('" + Url.Action("UserCenter", "User") + "','_self');</script>");

                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
            return View(user);
        }
        #endregion

        #region 用户List
        public ActionResult List()
        {
            var users = db.Users.ToList();
            return View(users);
        }
        #endregion

        #region 删除用户
        public ActionResult Delete(int id)
        {
            Users user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("List", "User") + "','_self');</script>");
        }
        #endregion

        #region 用户中心
        public ActionResult UserCenter()
        {
            int user_id = Convert.ToInt32(Session["user_id"].ToString());
            Users user = db.Users.Find(user_id);
            return View(user);
        }
        #endregion

        #region 用户注册
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users user)
        {


            HttpPostedFileBase file = Request.Files["image1"];
            if (ModelState.IsValid)
            {
                //if (file != null)
                //{
                //    string filePath = file.FileName;
                //    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                //    string serverpath = Server.MapPath(@"\image\users\") + fileName;
                //    string relativepath = @"/image/users/" + fileName;
                //    file.SaveAs(serverpath);
                //    user.User_Img = relativepath;
                //}
                user.user_time = DateTime.Now;

                ub.InsertUsers(user);
                Session["user_name"] = user.user_name;
                Users users = ub.GetUsersByName(user.user_name);
                Session["user_id"] = users.user_id.ToString();
                return Content("<script>alert('注册成功！');window.open('" + Url.Action("Index", "Index") + "','_self');</script>");
            }
            //else
            //{
            //    return Content("<script>alert('验证信息出错，注册失败！');window.open('" + Url.Action("Register", "User") + "','_self');</script>");
            //}
            return View(user);


        }
        #endregion

        #region 用户主页
        public ActionResult UserIndex(int user_id)
        {
            //int User_ID = Convert.ToInt32(Session["User_ID"].ToString());
            Users user1 = db.Users.Find(user_id);
            //var music1 = (from p in db.Music1 select p).OrderByDescending(p => p.music_time).Where(p => p.Users.user_id == user_id).ToList().Take(10);
            //var list1 = (from p in db.List select p).OrderByDescending(p => p.list_time).Where(p => p.user_id == user_id).ToList().Take(8);
            var list_keep1 = (from p in db.List_Keep select p).OrderByDescending(p => p.lk_time).Where(p => p.user_id == user_id).ToList().Take(8);
            //var attention1 = (from p in db.Attention select p).OrderBy(p => p.Att_Time).Where(p => p.User_ID == User_ID).ToList();

            var index = new Music.UI.ViewModel.UserViewModel
            {
                User1 = user1,
                //Music2 = music1,
                //List1 = list1,
                List_Keep1 = list_keep1,
                //Attention1 = attention1,

            };
            return View(index);
        }

        //public ActionResult UserAttention1(int user_id)
        //{
        //    User user1 = db.User.Find(User_ID);
        //    var attention = (from p in db.Attention select p).OrderBy(p => p.Att_Time).Where(p => p.User_ID == User_ID).ToList();
        //    var index = new SEEWeb.ViewModel.UserViewModel
        //    {
        //        User1 = user1,
        //        Attention1 = attention,
        //    };
        //    return View(index);
        //}

        //public ActionResult UserAttention(int User_ID)
        //{
        //    User user1 = db.User.Find(User_ID);
        //    var attention = (from p in db.Attention select p).OrderBy(p => p.Att_Time).Where(p => p.To_User_ID == User_ID).ToList();
        //    var index = new SEEWeb.ViewModel.UserViewModel
        //    {
        //        User1 = user1,
        //        Attention2 = attention,
        //    };
        //    return View(index);
        //}
        #endregion

        //#region 用户歌单
        //public ActionResult List2()
        //{
        //    int user_id = Convert.ToInt32(Session["user_id"].ToString());
        //    Users user = db.Users.Find(user_id);
        //    var list = (from p in db.List select p).Where(p => p.user_id == user_id).ToList();
        //    return View(list);
        //}
        //#endregion

        #region 用户音乐
        public ActionResult  Music()
        {
            int user_id = Convert.ToInt32(Session["user_id"].ToString());
            var music = (from p in db.Music1  select p).OrderByDescending(p => p.music_time).Where(p => p.music_id == user_id).ToList();
            return View(music);
        }
        #endregion

        #region 用户收藏歌单
        public ActionResult Save()
        {
            int user_id = Convert.ToInt32(Session["user_id"].ToString());
            var list_keep = (from p in db.List_Keep select p).OrderByDescending(p => p.lk_time).Where(p => p.user_id == user_id).ToList();
            return View(list_keep);
        }
        #endregion

        #region 用户退出登录
        public ActionResult LogOff()
        {
            Session["user_name"] = null;
            Session["user_id"] = null;
            Session["user_image"] = null;
            return Content("<script>alert('退出成功！');window.open('" + Url.Action("Index", "Index") + "','_self');</script>");
        }
        #endregion
    }
}