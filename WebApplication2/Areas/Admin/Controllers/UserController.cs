using KetNoiCSDL.DAO;
using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Common;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        private UserDao _userDao;
        public UserController()
        {
            _userDao = new UserDao();
        }
        public ActionResult Index(string searchString,int page = 1, int pageSize = 5)
        {
            var dao = new UserDao();
            //var users = dao.List();
            var users = _userDao.ListAllPaging(searchString, page, pageSize);
            ViewBag.users = users;

            ViewBag.ChuoiTimKiem = searchString;
            return View(users);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            var user = _userDao.user(id);
            return View(user);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public ActionResult Create(User user )
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new UserDao();
                    long id = dao.Insert(user);

                    if (id > 0)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm user không thành công.");
                    }
                }

            }
            catch
            {
                ModelState.AddModelError("", "Thêm user không thành công.");
            }
            return View("Create");
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _userDao.ViewDetail(id);
            return View(user);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        var MhMd5 = MaHoaMd5.MD5Hash(user.Password);
                        user.Password = MhMd5;

                    }
                    var res = _userDao.Update(user);

                    if (res)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật không thành công.");
                    }
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/User/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var user = _userDao.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Admin/User/Delete/5
        [HttpPost]

        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
