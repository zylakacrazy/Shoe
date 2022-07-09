using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoe.Views.Admin
{
    public partial class SanPham : System.Web.UI.Page
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
            GridView1.DataSource = sv.HienThiSanPham();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string msp, tsp, hinh, mota;
            int soluong, idlsp, idhsx;
            float gia;
            try
            {
                FileUpload fileName = Hinhanh;
                if (Hinhanh.HasFile)
                {
                    msp = Masanpham.Text;
                    tsp = Tensanpham.Text;
                    hinh = "~/Images/SanPham/" + fileName.FileName;
                    string filePath = MapPath(hinh);
                    fileName.SaveAs(filePath);
                    mota = Mota.Text;
                    soluong = int.Parse(Soluong.Text);
                    idlsp = int.Parse(DropDownList1.SelectedValue);
                    idhsx = int.Parse(DropDownList2.SelectedValue);
                    gia = float.Parse(Giasanpham.Text);
                    if(sv.ThemSanPham(msp, tsp, gia, hinh, mota, soluong, idlsp, idhsx))
                    {
                        Response.Write("<script>alert('Thêm thành công');</script>");
                        hienthi();
                    }
                    else
                    {
                        Response.Write("<script>alert('Thêm thất bại');</script>");
                    }
                }
                
            }
            catch
            {
                Response.Write("<script>alert('Thêm thất bại');</script>");
            }
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a = (int)GridView1.DataKeys[e.RowIndex].Values["Id"];
            sv.XoaSanPham(a);
            hienthi();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Masanpham.Text = row.Cells[0].Text;
            Tensanpham.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
            Giasanpham.Text = row.Cells[2].Text;
            Soluong.Text = row.Cells[4].Text;
            Mota.Text = row.Cells[5].Text;
            Id.Text = row.Cells[6].Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string msp, tsp, hinh, mota;
            int soluong, idlsp, idhsx, id;
            float gia;
            FileUpload fileName = Hinhanh;
            if (Hinhanh.HasFile)
            {
                id = int.Parse(Id.Text);
                msp = Masanpham.Text;
                tsp = Tensanpham.Text;
                hinh = "~/Images/SanPham/" + fileName.FileName;
                string filePath = MapPath(hinh);
                fileName.SaveAs(filePath);
                mota = Mota.Text;
                soluong = int.Parse(Soluong.Text);
                idlsp = int.Parse(DropDownList1.SelectedValue);
                idhsx = int.Parse(DropDownList2.SelectedValue);
                gia = float.Parse(Giasanpham.Text);

                if (sv.SuaSanPham(id, msp, tsp, gia, hinh, mota, soluong, idlsp, idhsx))
                {
                    Response.Write("<script>alert('Sửa thành công');</script>");
                    hienthi();
                }
                else
                {
                    Response.Write("<script>alert('Sửa thất bại');</script>");
                }
            }
        }
    }
}