<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="albumlist.aspx.cs" Inherits="albumlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Button ID="AddNewAlbumVisible" runat="server" OnClick="AddNewAlbumVisible_Click" Text="新建相册"/><br />
    
    <asp:TextBox ID="NewAlbumName" runat="server" Visible="false" Text="在此输入名称"></asp:TextBox><br />
    <asp:Button ID="CreatNewAlbum" runat="server" OnClick="CreatNewAlbum_Click" Text="创建" Visible="false" /><br />
    <asp:Repeater ID="AlbumList" runat="server" OnItemCommand="Album_ItemCommand" OnItemDataBound="Album_ItemDataBound">
        <ItemTemplate>
            <asp:Image ID="AlbumCover" ImageUrl='<%#Eval("CoverPath")%>' runat="server" Width="150px" Height="150px" /><br />
            <asp:Label ID="AlbumName" runat="server" Text='<%#Eval("AlbumName") %>'></asp:Label>
            <asp:LinkButton ID="Visit" runat="server" CommandName="Visit" CommandArgument='<%#Eval("id") %>' Text="查看"></asp:LinkButton><br />
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

