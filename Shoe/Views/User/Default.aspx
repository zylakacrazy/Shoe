<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shoe.Views.User.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--hiển thị sản phẩm--%>
    <h5 style="margin-left:30px;color:brown"><asp:Label ID="Label3" runat="server" ></asp:Label></h5>
    <div class="container-fluid" style="text-align:center;">
        <asp:Repeater ID="Repeater1" runat="server" >
            <ItemTemplate>
                <div class="hvr-float-shadow">
                    <div class="products card">
                         <div class="product card-body">
                             <asp:Label ID="idSP" Visible="false" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                             <asp:ImageButton CssClass="card-img-top" Height="200px" Width="200px" ImageUrl='<%# Eval("Images") %>' OnClick="ImageButton1_Click" ID="ImageButton1" runat="server" />
                             <asp:Label ID="Label1" runat="server" CssClass="product-Name" Text='<%# Eval("TenSanPham") %>'></asp:Label>
                             <br />
                             <asp:Label ID="Label2" runat="server" CssClass="product-Price" Text='<%# Eval("GiaSanPham","{0:0,0}")+" VNĐ" %>'></asp:Label>
                         </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <%--hiển thị sản phẩm--%>
</asp:Content>
