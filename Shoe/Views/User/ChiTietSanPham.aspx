<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="Shoe.Views.User.ChiTietSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluild">
        <div class="row">
            <div class="col-md-3 card">
                <ul class="nav flex-column s13" style="margin:20px auto">
                    <li class="navbar-brand underline">
                        Những điều cần biết
                    </li>
                    <li class="nav-item hvr-underline-from-left underline">
                        <a class="nav-link" href="#">Hướng dẫn mua hàng</a>
                    </li>
                    <li class="nav-item hvr-underline-from-left underline">
                        <a class="nav-link" href="#">Các tài khoản giao dịch</a>
                    </li>
                    <li class="nav-item hvr-underline-from-left underline">
                        <a class="nav-link" href="#">Mượn vợt đánh thử</a>
                    </li>
                    <li class="nav-item hvr-underline-from-left underline">
                        <a class="nav-link" href="#">Chính sách đổi trả và hoàn tiền</a>
                    </li>
                    <li class="nav-item hvr-underline-from-left underline">
                        <a class="nav-link" href="#">Chính sách bảo hành</a>
                    </li>
                    <li class="nav-item hvr-underline-from-left underline">
                        <a class="nav-link" href="#">Quy định bảo hành vợt tennis từ nhà sản xuất</a>
                    </li>
                    <li class="nav-item hvr-underline-from-left underline">
                        <a class="nav-link" href="#">Cam kết bảo mật thông tin khách hàng</a>
                    </li>
                    <li class="nav-item hvr-underline-from-left underline">
                        <a class="nav-link" href="#">Điều khoản sử dụng trang web</a>
                    </li>
                    <li class="nav-item hvr-underline-from-left underline">
                        <a class="nav-link" href="#">Giới thiệu</a>
                    </li>
                    <li class="nav-item hvr-underline-from-left underline">
                        <a class="nav-link" href="#">Liên hệ</a>
                    </li>
                    <li class="nav-item hvr-underline-from-left underline">
                        <a class="nav-link" href="#">Tìm kiếm</a>
                    </li>
                </ul> 
            </div>
            <%-----row -col-sm -9----%>
            <div class="col-md-9">
                <div class="row" style="margin:50px">
                    <div class="col-sm-6">
                        <div id="carouselControls" class="carousel slide" style="margin-bottom:0px;" data-bs-ride="carousel">
                            <div class="carousel-inner">
                            <div class="carousel-item active">
                                <asp:Image Height="380" ID="Image1" runat="server" />
                            </div>
                          </div>
                          <button class="carousel-control-prev" type="button" data-bs-target="#carouselControls" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                          </button>
                          <button class="carousel-control-next" type="button" data-bs-target="#carouselControls" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                          </button>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <h2><asp:Label ID="lblTenSP" runat="server" Text='<%# Eval("TenSanPham") %>'></asp:Label></h2>
                        <p style="color:red;"><asp:Label ID="lblGiaSP" runat="server" Text='<%# Eval("GiaSanPham", "{0:0,0}") +" VNĐ" %>'></asp:Label></p>
                        <asp:Label ID="lblMaSP" Text="" runat="server" />
                        <br />
                        <p style="text-align:justify;">
                            <asp:Label ID="lblMoTa" runat="server" Text='<%# Eval("MoTa") %>'></asp:Label>
                        </p>
                        <asp:Label ID="lblidSP" Visible="false" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        <div class="input-group mb-3">
                            <asp:TextBox CssClass="auto-style1" Min="1" Text="1" Width="68px" aria-describedby="button-addon2" TextMode="Number" ID="txtSoLuong" runat="server"></asp:TextBox>
                            <asp:Button ID="Button1" CssClass="btn btn-outline-danger" runat="server" Text="Thêm vào giỏ hàng" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
</asp:Content>