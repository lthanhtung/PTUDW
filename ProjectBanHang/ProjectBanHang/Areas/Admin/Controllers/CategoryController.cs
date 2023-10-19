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
using ProjectBanHang.Library;

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
            ViewBag.ListCat = new SelectList(categoriesDAO.getList("Index"), "Id", "Name");
            ViewBag.ListOrder = new SelectList(categoriesDAO.getList("Index"), "Order", "Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Catelogies catelogies)
        {
            if (ModelState.IsValid)
            {
                //Xử lý tự động: CreateAt
                catelogies.CreateAt = DateTime.Now;
                //Xử lý tự động: UpdateAt
                catelogies.UpdateAt = DateTime.Now;
                //Xử lý tự động: ParentID
                if (catelogies.ParentId == null)
                {
                    catelogies.ParentId = 0;
                }
                //Xử lý tự động: Order
                if (catelogies.Order == null)
                {
                    catelogies.Order = 1;
                }
                else
                {
                    catelogies.Order += 1;
                }
                //Xử lý tự động: Slug
                catelogies.Slug = XString.Str_Slug(catelogies.Name);



                //Chèn thêm dòng cho database
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

        /// ///////////////////////////////////////////////////
        /// Thùng rác - Trash
        // GET: Admin/Category/Status/5
        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                //Thông báo cập nhập trạng thái thất bại

                TempData["message"] = new XMessage("danger", "Cập nhập trạng thái thất bại");
                return RedirectToAction("Index");
            }
            //Truy vấn id
            Catelogies catelogies = categoriesDAO.getRow(id);
            //chuyển đổi trạng thái của Status 1<->2
            catelogies.Status = (catelogies.Status == 1) ? 2 :1;
            //Cập nhập trạng thái
            catelogies.UpdateAt = DateTime.Now;             
            //cập nhập lại database
            categoriesDAO.Update(catelogies);

            //Thông báo cập nhập trạng thái thành công
            TempData["message"] = TempData["message"] = new XMessage("danger", "Cập nhập trạng thái thành công");
            return RedirectToAction("Index");

        }
    }
}
