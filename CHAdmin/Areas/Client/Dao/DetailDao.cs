using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace CHAdmin.Areas.Client.Dao
{
    public class DetailDao
    {
        private CoffeeHouseDbContext context = new CoffeeHouseDbContext();
        public sanpham getDetail(int id)
        {
            sanpham sp = (sanpham)context.sanphams.FirstOrDefault(x => x.masp == id);
            return sp;
        }

        public int getMaloaisanpham(int masp)
        {
            sanpham sp = context.sanphams.Where(x => x.masp == masp).FirstOrDefault();
            return (int)sp.maloaisp;
        }
        public List<sanpham> getTuongTu(int maLoaiSP)
        {
            return context.sanphams.Where(x => x.maloaisp == maLoaiSP).ToList();
        }
    }
}