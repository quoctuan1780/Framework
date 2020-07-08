using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace CHAdmin.Areas.Client.Dao
{
    
    public class DetailDao
    {
        private CoffeeHouseDbContext context=new CoffeeHouseDbContext();
        //private CoffeeHouseDbContext context = new CoffeeHouseDbContext();
        public sanpham getDetail(int id)
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                sanpham sp = (sanpham)ctx.sanphams.FirstOrDefault(x => x.masp == id);
                return sp;
            }
            //    sanpham sp = (sanpham)context.sanphams.FirstOrDefault(x => x.masp == id);
            //return sp;
        }

        public int getMaloaisanpham(int masp)
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                sanpham sp = ctx.sanphams.Where(x => x.masp == masp).FirstOrDefault();
                return (int)sp.maloaisp;
            }
            //    sanpham sp = context.sanphams.Where(x => x.masp == masp).FirstOrDefault();
            //return (int)sp.maloaisp;
        }
        public List<sanpham> getTuongTu(int maLoaiSP)
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                return ctx.sanphams.Where(x => x.maloaisp == maLoaiSP).Take(6).ToList();
            }
                //return context.sanphams.Where(x => x.maloaisp == maLoaiSP).ToList();
        }

        public IEnumerable<sanpham> getBanChay()
        {
                IQueryable<sanpham> query = (from sp in context.sanphams
                                              join ct in context.ctdhs
                                              on sp.masp equals ct.masp
                                              group ct by ct.masp into dem
                                              orderby dem.Sum(x => x.soluong)
                                              select new
                                              {
                                                  masp = dem.Key,
                                                  sp = dem.Select(x => x.sanpham)
                                              }).Take(3).ToList() as IQueryable<sanpham>;
                return query;
            //}
        }
    }
}