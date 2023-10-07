using Myclass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myclass.DAO
{
    public class CategoriesDAO
    {
        private MyDBContext db = new MyDBContext();

        //SELECT * FROM ...
        
        public List<Catelogies> getList()
        {
            return db.Catelogies.ToList();
        } 
        //cho index chi voi Status 1,2
        //Select * From ...
        public List<Catelogies> getList(string status ="ALL")//status 0,1,2
        {
            List<Catelogies> list = null;
            switch(status)
            {
                case "Index": //1,2
                    {
                        list = db.Catelogies.Where(m => m.Status !=0 ).ToList();
                        break;
                    }
                case "Trash": //0
                    {
                        list = db.Catelogies.Where(m => m.Status == 0).ToList();
                        break;
                    }
                    default:
                    {
                        list = db.Catelogies.ToList();
                        break;
                    }

            }
            return list;
        }

        //Details
        public Catelogies getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Catelogies.Find(id);

            }

        }

        //Tạo mới mẫu tin
        public int Insert(Catelogies row) 
        {
            db.Catelogies.Add(row);
            return db.SaveChanges();
        }

        //Cập nhập mẫu tin
        public int Update(Catelogies row) 
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //Xóa mẫu tin
        public int Delete(Catelogies row)
        {
            db.Catelogies.Remove(row);
            return db.SaveChanges();
        }
    }
}
