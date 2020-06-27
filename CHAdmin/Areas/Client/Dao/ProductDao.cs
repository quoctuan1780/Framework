using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace CHAdmin.Areas.Client.Dao
{
    public class ProductDao
    {
        private CoffeeHouseDbContext context = new CoffeeHouseDbContext();
        public List<sanpham> getCungLoai(int maLoaiSP)
        {
            return new DetailDao().getTuongTu(maLoaiSP);
        }
    }
}