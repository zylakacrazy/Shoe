<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Template.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="Shoe.Views.User.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2">Đăng nhập</td>
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
                <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Đăng nhập" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
