<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="Shoe.Views.User.DangKy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2" style="text-align:center">Đăng ký tài khoản</td>
        </tr>
        <tr>
            <td>Tên đăng nhập</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Mật khẩu</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Tên khách hàng</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Giới tính</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" RepeatDirection="Horizontal" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="1">Nam</asp:ListItem>
                    <asp:ListItem Value="2">Nữ</asp:ListItem>
                    <asp:ListItem Value="3">Khác</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>Ngày sinh</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Số điện thoại</td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox6" runat="server" TextMode="Phone"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" TextMode="Email"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Địa chỉ</td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="Button1" runat="server" Text="Đăng ký" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
