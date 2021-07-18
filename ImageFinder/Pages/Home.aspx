<%@ Page Language="C#" MasterPageFile="Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ImageFinder.Pages.Home" %>

<asp:Content ID="head" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="search" ContentPlaceHolderID="Navbar" runat="server">
    <div class="d-flex">
        <asp:TextBox runat="server" ID="inSearch" CssClass="form-control me-2" placeholder="URL" onfocus="javascript:this.focus();this.select();"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-outline-success" type="submit" Text="Search" OnClick="btnSearch_Click"></asp:Button>
    </div>
</asp:Content>

<asp:Content ID="body" ContentPlaceHolderID="PageContent" runat="server">
    <div id="main" runat="server" class="container">
        <h1 class="text-center p-4" runat="server">Top Words</h1>
        <div class="row">
            <div class="col-lg-12">
                <asp:GridView runat="server" ID="grdWords" AutoGenerateColumns="false" Width="100%" CssClass="GridViewStyle">
                    <HeaderStyle CssClass="HeaderStyle" />
                    <RowStyle CssClass="RowStyle" />
                    <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                    <Columns>
                        <asp:BoundField DataField="Key" HeaderText="Word" HeaderStyle-Width="50%" />
                        <asp:BoundField DataField="Value" HeaderText="Occurrences" HeaderStyle-Width="50%" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <h1 class="text-center p-4">Images Found</h1>
        <asp:DataList runat="server" ID="grdImages" RepeatColumns="5" RepeatDirection="Vertical" CellPadding="10">
            <ItemTemplate>
                <div class="image-div">
                    <asp:Image runat="server" ID="imgSearch" ImageUrl='<%#Eval("src")%>' CssClass="image-display" />
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>