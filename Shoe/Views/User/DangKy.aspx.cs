using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoe.Views.User
{
    public partial class DangKy : System.Web.UI.Page
    {
        ServiceShoe sv = new ServiceShoe();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string tdn, mk, tkh, email, diachi, sdt;
            int gioitinh;
            DateTime ngaysinh;

            try
            {
                gioitinh = int.Parse(RadioButtonList1.SelectedValue);
                tdn = TextBox1.Text;
                mk = TextBox2.Text;
                tkh = TextBox3.Text;
                ngaysinh = DateTime.Parse(TextBox5.Text);
                sdt = TextBox6.Text;
                email = TextBox7.Text;
                diachi = TextBox8.Text;
                sv.DangKy(tkh, gioitinh, sdt, ngaysinh, diachi, email, tdn, mk);
                Response.Write("<script>alert('Đăng ký thành công');</script>");
            }
            catch
            {
                Response.Write("<script>alert('Đăng ký thất bại');</script>");
            }
        }
    }
}