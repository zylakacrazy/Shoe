<%@ Page Title="" Language="C#" MasterPageFile="~/Views/TemplateManage.Master" AutoEventWireup="true" CodeBehind="HangSanXuat.aspx.cs" Inherits="Shoe.Views.Admin.HangSanXuat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Mã hãng sản xuất</td>
            <td>
                <asp:TextBox ID="Mahsx" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Tên hãng sản xuất</td>
            <td>
                <asp:TextBox ID="Tenhsx" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Mô tả</td>
            <td>
                <asp:TextBox ID="Mota" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" OnClick="BtnThem_Click" ID="BtnThem" Text="Thêm hãng sản xuất" />
                <asp:Button ID="btnSuahsx" runat="server" OnClick="btnSuahsx_Click" Text="Sửa hãng sản xuất" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="MaHSX" HeaderText="Mã hãng sản xuất" />
            <asp:BoundField DataField="TenHSX" HeaderText="Tên hãng sản xuất" />
            <asp:BoundField DataField="MoTa" HeaderText="Mô tả" />
        </Columns>

    </asp:GridView>
</asp:Content>
