<%@ Page Title="" Language="C#" MasterPageFile="~/Views/TemplateManage.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="Shoe.Views.Admin.SanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2">Thêm sản phẩm</td>
        </tr>
        <tr>
            <td>Mã sản phẩm</td>
            <td>
                <asp:Label Text="text" ID="Id" Visible="false" runat="server" />
                <asp:TextBox ID="Masanpham" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Tên sản phẩm</td>
            <td>
                <asp:TextBox ID="Tensanpham" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Giá sản phẩm</td>
            <td>
                <asp:TextBox ID="Giasanpham" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Hình ảnh</td>
            <td>
                <asp:FileUpload ID="Hinhanh" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Số lượng</td>
            <td>
                <asp:TextBox ID="Soluong" Text="1" min="1" TextMode="Number" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Mô tả</td>
            <td>
                <asp:TextBox ID="Mota" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Loại sản phẩm</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSourceLSP" DataTextField="TenLSP" DataValueField="Id"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceLSP" runat="server" ConnectionString="<%$ ConnectionStrings:ShoeConnectionString2 %>" SelectCommand="SELECT [Id], [TenLSP] FROM [LoaiSanPham]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>Hãng sản xuất</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSourceHSX" DataTextField="TenHSX" DataValueField="Id"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceHSX" runat="server" ConnectionString="<%$ ConnectionStrings:ShoeConnectionString3 %>" SelectCommand="SELECT [Id], [TenHSX] FROM [HangSanXuat]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Thêm sản phẩm" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Sửa sản phẩm" />
            </td>
        </tr>
    </table>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" DataKeyNames="Id"
        OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="MaSanPham" HeaderText="Mã sản phẩm" />
            <asp:BoundField DataField="TenSanPham" HeaderText="Tên sản phẩm" />
            <asp:BoundField DataField="GiaSanPham" HeaderText="Giá sản phẩm" />
            <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
            <asp:BoundField DataField="MoTa" HeaderText="Mô tả" />
            <asp:ImageField AlternateText="" ControlStyle-Height="200" ControlStyle-Width="200"
                DataImageUrlField="Images" HeaderText="Hình ảnh">
<ControlStyle Height="200px" Width="200px"></ControlStyle>
            </asp:ImageField>
            <asp:BoundField DataField="Id_LoaiSanPham" HeaderText="Loại sản phẩm" />
            <asp:BoundField DataField="Id_HangSanXuat" HeaderText="Hãng sản xuất" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" OnClientClick="return confirm('Chắc chưa?');" CommandName="Delete" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" Visible="False" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="Gray" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br />
</asp:Content>
