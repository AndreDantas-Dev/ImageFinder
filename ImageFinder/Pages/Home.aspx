<%@ Page Language="C#" MasterPageFile="Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ImageFinder.Pages.Home" %>

<asp:Content ID="head" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="search" ContentPlaceHolderID="Navbar" runat="server">
    <form runat="server" class="d-flex">
        <asp:TextBox runat="server" ID="inSearch" CssClass="form-control me-2" placeholder="URL"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-outline-success" type="submit" Text="Search" OnClick="btnSearch_Click" onfocus="javascript:this.focus();this.select();"></asp:Button>
    </form>
</asp:Content>

<asp:Content ID="body" ContentPlaceHolderID="PageContent" runat="server">
    <div id="main" runat="server" class="container">
        <asp:DataList runat="server" ID="grdImages" RepeatColumns="5" RepeatDirection="Vertical" CellPadding="10">
            <ItemTemplate>
                <div class="image-div">
                    <asp:Image runat="server" ID="imgSearch" ImageUrl='<%#Eval("src") %>' CssClass="image-display"/>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>