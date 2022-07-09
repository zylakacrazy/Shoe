<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="Shoe.Views.User.GioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate>
            <tr style="">
                 <%--<td runat="server">--%>
                     <asp:Label ID="idSP" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                 <%--</td>--%>
                 <td runat="server">
                     <asp:Label ID="tenSP" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                 </td>
                 <td runat="server">
                     <asp:Label ID="giaHD" Visible="false" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                     <asp:Image ID="Image1" ImageUrl='<%# Eval("Images") %>' Height="100px" runat="server" />
                 </td>
                 <%--<td runat="server">
                     
                 </td>--%>
                 <td runat="server">
                     <asp:TextBox ID="SoLuong" Width="60px" AutoPostBack="true" runat="server" TextMode="Number" Text='<%# Eval("Quantity") %>' Min="1" />
                 </td>
                <td>
                    <h5 style="color:red;"<asp:Label ID="tongGia" Text='<%# Eval("Price","{0:0,0}")+"đ" %>' runat="server"></asp:Label></h5>
                    <asp:Label ID="tongtien1" Visible="false" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton5" runat="server" CommandName='Delete' ><i class="fas fa-trash-alt"></i></asp:LinkButton>
                </td>
                
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server" style="width:70%;margin:40px auto;" class="table table-borderless">
                <tr runat="server">
                    <td runat="server">
                    <asp:ScriptManager runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <table id="itemPlaceholderContainer" class="table table-bordered" runat="server" border="0" style="width:90%;margin:20px auto;">
                            <tr runat="server" style="">
                                <%--<th runat="server">ID</th>--%>
                                <th runat="server">Tên sản phẩm</th>
                                <th runat="server">Hình ảnh</th>
                                <%--<th runat="server">Giá sản phẩm</th>--%>
                                <th runat="server">Số lượng</th>
                                <th runat="server">Giá</th>
                                <th runat="server"></th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="float:right">
                        <table>
                            <tr>
                                <td><h5 style="color:red">Tổng: <asp:Label ID="tongHD" Text="0" runat="server"></asp:Label> VNĐ</h5></td>
                                <td><asp:LinkButton CssClass="btn btn-outline-dark" ID="LinkButton1" runat="server">Cập nhật</asp:LinkButton></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="float:right;">
                        <div style="float:right">
                           <asp:Button ID="Button1" CssClass="btn btn-outline-danger" runat="server" Text="Đặt hàng" />
                        </div>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
