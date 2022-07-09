using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoe.Views.User
{
    public partial class DangNhap : System.Web.UI.Page
    {
        ServiceShoe sv = new ServiceShoe();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string tdn, mk;
            tdn = TextBox1.Text;
            mk = TextBox2.Text;
            if(string.IsNullOrEmpty(tdn) || string.IsNullOrEmpty(mk))
            {
                Response.Write("<script>alert('Tên đăng nhập và mật khẩu không được để trống!');</script>");
            }
            else
            {
                try
                {

                    if (sv.DangNhap(tdn, mk))
                    {
                        Response.Write("<script>alert('Đăng nhập thành công');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Đăng nhập không thành công');</script>");
                    }
                }
                catch
                {
                    Response.Write("<script>alert('Đăng nhập thất bại');<script>");
                }
            }
        }
    }
}