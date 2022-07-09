using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoe.Views.User
{
    public partial class Default : System.Web.UI.Page
    {
        ServiceShoe sv = new ServiceShoe();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hienthi();
            }
        }
        public void hienthi()
        {
            Repeater1.DataSource = sv.HienThiSanPham();
            Repeater1.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton AnDeBanOi = (ImageButton)sender;
            RepeaterItem item = (RepeaterItem)AnDeBanOi.NamingContainer;
            Label ma = (Label)item.FindControl("idSP");
            Session["idSP"] = ma.Text;
            Response.Redirect("ChiTietSanPham.aspx");
        }
    }
}