using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoe.Views.Admin
{
    public partial class HangSanXuat : System.Web.UI.Page
    {
        ServiceShoe sv = new ServiceShoe();
        protected void Page_Load(object sender, EventArgs e)
        {
            hienthi();
        }
        public void hienthi()
        {
            GridView1.DataSource = sv.HienThiHangSanXuat();
            GridView1.DataBind();
        }
        protected void BtnThem_Click(object sender, EventArgs e)
        {
            if (sv.ThemHangSanXuat(Mahsx.Text, Tenhsx.Text, "", Mota.Text))
            {
                Response.Write("<script>alert('Thêm thành công');</script>");
            }
            else
            {
                Response.Write("<script>alert('Thêm không thành công');</script>");
            }
            hienthi();
        }

        protected void btnSuahsx_Click(object sender, EventArgs e)
        {
            int id=0;
            if(sv.SuaHangSanXuat(id, Mahsx.Text, Tenhsx.Text, "", Mota.Text))
            {
                Response.Write("<script>alert('Sửa thành công');</script>");
            }
            else
            {
                Response.Write("<script>alert('Sửa không thành công');</script>");
            }
        }
    }
}