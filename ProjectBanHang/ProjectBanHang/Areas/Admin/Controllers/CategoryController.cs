using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Myclass.DAO;
using Myclass.Model;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesDAO categoriesDAO = new CategoriesDAO();
        /// <summary>
        /// ///////////////////////////////////////////////////
        /// Index
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(categoriesDAO.getList("Index"));
        }

        /// ///////////////////////////////////////////////////
        /// Details
        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catelogies catelogies = categoriesDAO.getRow(id);

            if (catelogies == null)
            {
                return HttpNotFound();
            }
            return View(catelogies);
        }

        /// ///////////////////////////////////////////////////
        /// Create
        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Catelogies catelogies)
        {
            if (ModelState.IsValid)
            {
                categoriesDAO.Insert(catelogies);
                return RedirectToAction("Index");
            }
            return View(catelogies);
        }

        /// ///////////////////////////////////////////////////
        /// Edit
        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catelogies catelogies = categoriesDAO.getRow(id);
            if (catelogies == null)
            {
                return HttpNotFound();
            }
            return View(catelogies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Catelogies catelogies)
        {
            if (ModelState.IsValid)
            {
               categoriesDAO.Update(catelogies);
                return RedirectToAction("Index");
            }
            return View(catelogies);

        }

        /// ///////////////////////////////////////////////////
        /// Delete
        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catelogies catelogies = categoriesDAO.getRow(id);
            if (catelogies == null)
            {
                return HttpNotFound();
            }
            return View(catelogies);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catelogies catelogies = categoriesDAO.getRow(id);
            categoriesDAO.Delete(catelogies);
            
            return RedirectToAction("Index");
        }

    }
}
