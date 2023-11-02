using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using Myclass.DAO;
using Myclass.Model;
using ProjectBanHang.Library;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class SuppliersController : Controller
    {
        SuppliersDAO suppliersDAO = new SuppliersDAO();
        // GET: Admin/Suppliers
        //Index
        public ActionResult Index()
        {
            return View(suppliersDAO.getList("Index"));
        }

        // GET: Admin/Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //thông báo thất bại

                TempData["message"] = new XMessage("danger", "Không tồn tại nhà cung cấp");
                return RedirectToAction("Index");
            }
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //thông báo thất bại

                TempData["message"] = new XMessage("danger", "Không tồn tại nhà cung cấp");
                return RedirectToAction("Index");

            }
            return View(suppliers);
        }
        ///////
        // GET: Admin/Suppliers/Create
        public ActionResult Create()
        {
            ViewBag.ListOrder = new SelectList(suppliersDAO.getList("Index"), "Order", "Name");

            return View();
        }
        // POST: Admin/Suppliers/Create/5       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                //xử lý tự động slug,createAt,BY, updateAt,BY,Order

                //Xử lý tự động: CreateAt
                suppliers.CreateAt = DateTime.Now;
                //Xử lý tự động: UpdateAt
                suppliers.UpdateAt = DateTime.Now;

                suppliers.CreateBy = Convert.ToInt32(Session["UserId"]);

                suppliers.UpdateBy = Convert.ToInt32(Session["UserId"]);

                //Xử lý tự động: Order
                if (suppliers.Order == null)
                {
                    suppliers.Order = 1;
                }
                else
                {
                    suppliers.Order += 1;
                }
                //Xử lý tự động: Slug
                suppliers.Slug = XString.Str_Slug(suppliers.Name);

                //xu ly cho phan upload hình ảnh
                var img = Request.Files["img"];//upload hinh
                 string PathDir = "~/Public/img/Suppuliers";//cập nhập hình
                if (img.ContentLength != 0)
                {
                    string[] FileExtentions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                    //kiem tra tap tin co hay khong
                    if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))//lay phan mo rong cua tap tin
                    {
                        string slug = suppliers.Slug;
                        //ten file = Slug + phan mo rong cua tap tin
                        string imgName = slug + suppliers.Id + img.FileName.Substring(img.FileName.LastIndexOf("."));
                        suppliers.Image = imgName;
                       
                        string PathFile = Path.Combine(Server.MapPath(PathDir), imgName);
                        img.SaveAs(PathFile);
                    }

                    ////xử lý cho mục xóa hình ảnh
                    //if (suppliers.Image != null)
                    //{                    
                    //    string DelPath = Path.Combine(Server.MapPath(PathDir), suppliers.Image);
                    //    System.IO.File.Delete(DelPath);
                    //}


                }//ket thuc phan upload hinh anh




                //chèn mẫu tin vào database;
                suppliersDAO.Insert(suppliers);
                //thông báo mẫu tin thành công
                TempData["message"] = new XMessage("success", "Tạo mới nhà cung cấp thành công");
                return RedirectToAction("Index");

            }

            return View(suppliers);
        }

        // GET: Admin/Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {

                //thông báo thất bại

                TempData["message"] = new XMessage("danger", "Không tồn tại nhà cung cấp");
                return RedirectToAction("Index");
            }
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {

                //thông báo thất bại

                TempData["message"] = new XMessage("danger", "Không tồn tại nhà cung cấp");
                return RedirectToAction("Index");
            }
            ViewBag.ListOrder = new SelectList(suppliersDAO.getList("Index"), "Order", "Name");

            return View(suppliers);
        }
        // POST: Admin/Suppliers/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                // xử lý tự động slug,, BY, updateAt, BY, Order


                //Xử lý tự động: UpdateAt
                suppliers.UpdateAt = DateTime.Now;
                //Xử lý tự động: Order
                if (suppliers.Order == null)
                {
                    suppliers.Order = 1;
                }
                else
                {
                    suppliers.Order += 1;
                }
                //Xử lý tự động: Slug
                suppliers.Slug = XString.Str_Slug(suppliers.Name);


                //cập nhập mãu tin vào database
                suppliersDAO.Update(suppliers);
                //thông báo mẫu tin thành công
                TempData["message"] = new XMessage("success", "cập nhập nhà cung cấp thành công");
                return RedirectToAction("Index");
            }
            ViewBag.ListOrder = new SelectList(suppliersDAO.getList("Index"), "Order", "Name");

            return View(suppliers);
        }

        // GET: Admin/Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["message"] = new XMessage("danger", "Không tồn tại nhà cung cấp");
                return RedirectToAction("Index");
            }
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //thông báo thất bại
                TempData["message"] = new XMessage("danger", "Không tồn tại nhà cung cấp");
                return RedirectToAction("Index");
            }
            return View(suppliers);
        }

        // POST: Admin/Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suppliers suppliers = suppliersDAO.getRow(id);
            //xóa mãu tin ra khỏi database
            suppliersDAO.Delete(suppliers);
            //xóa mẫu tin thành công
            TempData["message"] = new XMessage("success", "Xóa nhà cung cấp thành công");

            return RedirectToAction("Index");
        }

        //phát sinh thêm hàm mới: status, Trash,deltrash,undo

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
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //Thông báo cập nhập trạng thái thất bại

                TempData["message"] = new XMessage("danger", "Cập nhập trạng thái thất bại");
                return RedirectToAction("Index");
            }
            else
            {


                //chuyển đổi trạng thái của Status 1<->2
                suppliers.Status = (suppliers.Status == 1) ? 2 : 1;
                //Cập nhập trạng thái
                suppliers.UpdateAt = DateTime.Now;
                //cập nhập lại database
                suppliersDAO.Update(suppliers);

                //Thông báo cập nhập trạng thái thành công
                TempData["message"] = TempData["message"] = new XMessage("success", "Cập nhập trạng thái thành công");
                return RedirectToAction("Index");
            }
        }


        // GET: Admin/Category/DelTrash/5
        public ActionResult DelTrash(int? id)
        {
            if (id == null)
            {
                //Thông báo cập nhập trạng thái thất bại

                TempData["message"] = new XMessage("danger", "Không tìm thấy mẫu tin");
                return RedirectToAction("Index");
            }
            //Truy vấn id
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //Thông báo cập nhập trạng thái thất bại

                TempData["message"] = new XMessage("danger", "Không tìm thấy mẫu tin");
                return RedirectToAction("Index");
            }
            else
            {


                //chuyển đổi trạng thái của Status 1,2<->0 : khong hieu thi o index
                suppliers.Status = 0;
                //Cập nhập trạng thái
                suppliers.UpdateAt = DateTime.Now;
                //cập nhập lại database
                suppliersDAO.Update(suppliers);

                //Thông báo cập nhập trạng thái thành công
                TempData["message"] = TempData["message"] = new XMessage("success", "Xóa mẫu tin thành công");
                return RedirectToAction("Index");
            }
        }

        /// Trash
        // GET: Admin/Category/Recover
        public ActionResult Trash()
        {
            return View(suppliersDAO.getList("Trash"));
        }
        //Recover
        // GET: Admin/Category/Recover/5

        public ActionResult Recover(int? id)
        {
            if (id == null)
            {
                //Thông báo cập nhập trạng thái thất bại

                TempData["message"] = new XMessage("danger", "Phục hồi mẫu tin thất bại");
                return RedirectToAction("Index");
            }
            //Truy vấn id
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //Thông báo cập nhập trạng thái thất bại

                TempData["message"] = new XMessage("danger", "Phục hồi mẫu tin thất bại");
                return RedirectToAction("Index");
            }
            else
            {


                //chuyển đổi trạng thái của Status 0-> 2: không xuất bản
                suppliers.Status = 2;
                //Cập nhập trạng thái
                suppliers.UpdateAt = DateTime.Now;
                //cập nhập lại database
                suppliersDAO.Update(suppliers);

                //Thông báo phục hồi mẫu tin thành công
                TempData["message"] = TempData["message"] = new XMessage("success", "Phục hồi mẫu tin thành công");
                return RedirectToAction("Index");
            }
        }
    }
}
