using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TechMarket.Services;

namespace Shoe
{
    /// <summary>
    /// Summary description for ServiceShoe
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceShoe : System.Web.Services.WebService
    {
        //Khai báo csdl
        DbShoeDataContext db = new DbShoeDataContext();
        // Đăng ký tài khoản/ Thêm khách hàng
        [WebMethod]
        public bool DangKy(string TenKH, int GioiTinh, string SDT, 
            DateTime NgaySinh, string DiaChi, string Email, string TenDangNhap, string Matkhau)
        {
            try
            {
                KhachHang kh = new KhachHang
                {
                    TenKhachHang = TenKH,
                    GioiTinh = GioiTinh,
                    SoDienThoai = SDT,
                    DiaChi = DiaChi,
                    NgaySinh = NgaySinh,
                    Email = Email,
                    TenDangNhap = TenDangNhap,
                    MatKhau = CreateMD5.EncodePassword(Matkhau)
                };
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Sửa Khách hàng
        [WebMethod]
        public bool SuaKhachHang(int id, string TenKH, int GioiTinh, string SDT,
            DateTime NgaySinh, string DiaChi, string Email, string TenDangNhap, string Matkhau)
        {
            try
            {
                KhachHang kh = db.KhachHangs.Single(x => x.Id == id);
                kh.TenKhachHang = TenKH;
                kh.GioiTinh = GioiTinh;
                kh.SoDienThoai = SDT;
                kh.Email = Email;
                kh.DiaChi = DiaChi;
                kh.NgaySinh = NgaySinh;
                kh.TenDangNhap = TenDangNhap;
                kh.MatKhau = CreateMD5.EncodePassword(Matkhau);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Xóa Khách hàng
        [WebMethod]
        public bool XoaKhachHang(int id)
        {
            try
            {
                KhachHang kh = db.KhachHangs.Single(x=>x.Id == id);
                db.KhachHangs.DeleteOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        //Đăng nhập
        [WebMethod] 
        public bool DangNhap(string tdn, string mk)
        {
            string giaima = CreateMD5.EncodePassword(mk);
            try
            {
                var us = db.KhachHangs.FirstOrDefault(x => x.TenDangNhap == tdn && x.MatKhau == giaima);
                if(us != null)
                {
                    Session["ID"] = us.Id;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        // Hiển Thị Sản Phẩm
        [WebMethod]
        public List<SanPham> HienThiSanPham()
        {
            return db.SanPhams.ToList();
        }
        //Thêm sản phẩm
        [WebMethod]
        public bool ThemSanPham(string MaSP, string TenSP, float GiaSP, string Hinh, 
            string Mota, int SoLuong, int id_LoaiSanPham, int id_HangSanXuat)
        {
            try
            {
                SanPham sp = new SanPham
                {
                    MaSanPham = MaSP,
                    TenSanPham = TenSP,
                    GiaSanPham = GiaSP,
                    Images = Hinh,
                    MoTa = Mota,
                    SoLuong = SoLuong,
                    Id_LoaiSanPham = id_LoaiSanPham,
                    Id_HangSanXuat = id_HangSanXuat
                };
                db.SanPhams.InsertOnSubmit(sp);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Sửa sản phẩm
        [WebMethod]
        public bool SuaSanPham(int idsp, string MaSP, string TenSP, float GiaSP, string Hinh,
            string Mota, int SoLuong, int id_LoaiSanPham, int id_HangSanXuat)
        {
            try
            {
                SanPham sp = db.SanPhams.Single(x => x.Id == idsp);
                sp.MaSanPham = MaSP;
                sp.TenSanPham = TenSP;
                sp.GiaSanPham = GiaSP;
                sp.Images = Hinh;
                sp.MoTa = Mota;
                sp.SoLuong = SoLuong;
                sp.Id_LoaiSanPham = id_LoaiSanPham;
                sp.Id_HangSanXuat = id_HangSanXuat;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Xóa sản phẩm
        [WebMethod]
        public bool XoaSanPham(int idsp)
        {
            try
            {
                SanPham sp = db.SanPhams.Single(x => x.Id == idsp);
                db.SanPhams.DeleteOnSubmit(sp);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Tìm kiếm sản phẩm
        [WebMethod]
        public List<SanPham> TimKiemSanPham(int id)
        {
            var result = from sp in db.SanPhams
                         where sp.Id == id
                         select sp;
            return result.ToList();
        }
        // Hiển thị hãng sản xuất
        [WebMethod]
        public List<HangSanXuat> HienThiHangSanXuat()
        {
            return db.HangSanXuats.ToList();
        }
        // Thêm hãng sản xuất
        [WebMethod]
        public bool ThemHangSanXuat(string MaHSX, string TenHSX, string hinhanh, string mota)
        {
            try
            {
                HangSanXuat hsx = new HangSanXuat
                {
                    MaHSX = MaHSX,
                    TenHSX = TenHSX,
                    HinhAnh = hinhanh,
                    MoTa = mota
                };
                db.HangSanXuats.InsertOnSubmit(hsx);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Sửa hãng sản xuất
        [WebMethod]
        public bool SuaHangSanXuat(int idhsx, string MaHSX, string TenHSX, string hinhanh, string mota)
        {
            try
            {
                HangSanXuat hsx = db.HangSanXuats.Single(x => x.Id == idhsx);
                hsx.MaHSX = MaHSX;
                hsx.TenHSX = TenHSX;
                hsx.HinhAnh= hinhanh;
                hsx.MoTa = mota;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Xóa hãng sản xuất
        [WebMethod]
        public bool XoaHangSanXuat(int id)
        {
            try
            {
                HangSanXuat hsx = db.HangSanXuats.Single(x => x.Id == id);
                db.HangSanXuats.DeleteOnSubmit(hsx);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Hiển thị loại sản phẩm
        [WebMethod]
        public List<LoaiSanPham> HienThiLoaiSanPham()
        {
            return db.LoaiSanPhams.ToList();
        }
        // Thêm loại sản phẩm
        [WebMethod]
        public bool ThemLoaiSanPham(string malsp, string tenlsp, string mota, string hinhanh)
        {
            LoaiSanPham loaiSanPham = new LoaiSanPham
            {
                MaLSP = malsp,
                TenLSP = tenlsp,
                MoTa = mota,
                HinhAnh = hinhanh
            };
            try
            {
                db.LoaiSanPhams.InsertOnSubmit(loaiSanPham);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Sửa loại sản phẩm
        [WebMethod]
        public bool SuaLoaiSanPham(int id, string malsp, string tenlsp, string mota, string hinhanh)
        {
            try
            {
                LoaiSanPham lsp = db.LoaiSanPhams.Single(x => x.Id == id);
                lsp.MaLSP = malsp;
                lsp.TenLSP = tenlsp;
                lsp.MoTa = mota;
                lsp.HinhAnh = hinhanh;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Xóa loại sản phẩm
        [WebMethod]
        public bool XoaLoaiSanPham(int id)
        {
            try
            {
                LoaiSanPham lsp = db.LoaiSanPhams.Single(x=>x.Id == id);
                db.LoaiSanPhams.DeleteOnSubmit(lsp);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Hiển thị nhân viên
        [WebMethod]
        public List<NhanVien> HienThiNhanVien()
        {
            return db.NhanViens.ToList();
        }
        // Thêm nhân viên
        [WebMethod]
        public bool ThemNhanVien(string tennhanvien, int gioitinh, string cccd,
            string email, DateTime ngaysinh, string diachi, string tendangnhap,
            string matkhau)
        {
            try
            {
                NhanVien nv = new NhanVien 
                {
                    TenNhanVien= tennhanvien,
                    GioiTinh= gioitinh,
                    CCCD= cccd,
                    Email= email,
                    NgaySinh= ngaysinh,
                    DiaChi= diachi,
                    TenDangNhapNV= tendangnhap,
                    MatKhauNV= matkhau
                };
                db.NhanViens.InsertOnSubmit(nv);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Sửa nhân viên
        [WebMethod]
        public bool SuaNhanVien(int id, string tennhanvien, int gioitinh, string cccd,
            string email, DateTime ngaysinh, string diachi, string tendangnhap,
            string matkhau)
        {
            try
            {
                NhanVien nv = db.NhanViens.Single(x => x.Id == id);
                nv.TenNhanVien = tennhanvien;
                nv.GioiTinh = gioitinh;
                nv.CCCD = cccd;
                nv.Email = email;
                nv.NgaySinh = ngaysinh;
                nv.DiaChi = diachi;
                nv.TenDangNhapNV = tendangnhap;
                nv.MatKhauNV = matkhau;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Xóa nhân viên
        [WebMethod]
        public bool XoaNhanVien(int id)
        {
            try
            {
                NhanVien nv = db.NhanViens.Single(x => x.Id == id);
                db.NhanViens.DeleteOnSubmit(nv);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Thêm bình luận
        [WebMethod]
        public bool ThemBinhLuan(string noidung, int idsp, int idkh, DateTime thoigian)
        {
            try
            {
                BinhLuan bl = new BinhLuan
                {
                    NoiDung = noidung,
                    Id_SanPham = idsp,
                    Id_KhachHang = idkh,
                    ThoiGian = thoigian,
                    LikeCmt = 0,
                    DisLikeCmt = 0
                };
                db.BinhLuans.InsertOnSubmit(bl);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Sửa bình luận
        [WebMethod]
        public bool SuaBinhLuan(int id, string noidung)
        {
            try
            {
                BinhLuan bl = db.BinhLuans.Single(x => x.Id == id);
                bl.NoiDung = noidung;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        //Xóa bình luận
        [WebMethod]
        public bool XoaBinhLuan(int id)
        {
            try
            {
                BinhLuan bl = db.BinhLuans.Single(x => x.Id == id);
                db.BinhLuans.DeleteOnSubmit(bl);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Like cmt
        [WebMethod]
        public bool LikeBinhLuan(int id, int likecmt)
        {
            try
            {
                BinhLuan bl = db.BinhLuans.Single(x => x.Id == id);
                bl.LikeCmt = likecmt;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // DisLike cmt
        [WebMethod]
        public bool DisLikeBinhLuan(int id, int dislikecmt)
        {
            try
            {
                BinhLuan bl = db.BinhLuans.Single(x => x.Id == id);
                bl.DisLikeCmt = dislikecmt;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Thêm Phản hồi
        [WebMethod]
        public bool ThemPhanHoi(string noidung, int idsp, int idkh, 
            int idbl, DateTime thoigian)
        {
            try
            {
                PhanHoi bl = new PhanHoi
                {
                    NoiDung = noidung,
                    Id_SanPham = idsp,
                    Id_KhachHang = idkh,
                    Id_BinhLuan = idbl,
                    ThoiGian = thoigian,
                    LikeCmt = 0,
                    DisLikeCmt = 0
                };
                db.PhanHois.InsertOnSubmit(bl);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Sửa Phản hồi
        [WebMethod]
        public bool SuaPhanHoi(string noidung, int id)
        {
            try
            {
                PhanHoi bl = db.PhanHois.Single(x => x.Id == id);
                bl.NoiDung = noidung;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Like phản hồi
        [WebMethod]
        public bool LikePhanHoi(int id, int likecmt)
        {
            try
            {
                PhanHoi bl = db.PhanHois.Single(x => x.Id == id);
                bl.LikeCmt = likecmt;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        //Dislike phản hồi
        [WebMethod]
        public bool DisLikePhanHoi(int id, int dislikecmt)
        {
            try
            {
                PhanHoi bl = db.PhanHois.Single(x => x.Id == id);
                bl.DisLikeCmt = dislikecmt;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        // Duyệt hóa đơn
        [WebMethod]
        public bool DuyetHoaDon(int id, int id_NV)
        {
            HoaDon ds = db.HoaDons.Single(x => x.Id == id);
            ds.Id_NhanVien = id_NV;
            ds.TrangThai = 1;
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        //hiển thị hóa đơn
        [WebMethod]
        public List<HoaDon> HienThiHoaDon()
        {
            return db.HoaDons.ToList();
        }
        //hiển thị chi tiết hóa đơn
        [WebMethod]
        public List<HT_CTHD> htCTHD(int id)
        {
            var result = from ct in db.ChiTietHoaDons
                         from sp in db.SanPhams
                         where ct.Id_HoaDon == id && ct.Id_SanPham == sp.Id
                         select new HT_CTHD
                         {
                             id = ct.Id,
                             tensp = sp.TenSanPham,
                             soluong = ct.SoLuong,
                             tongtien = ct.TongTien
                         };
            return result.ToList();
        }
    }
}
