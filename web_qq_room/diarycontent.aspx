<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="diarycontent.aspx.cs" Inherits="diarycontent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>标题：<asp:Label ID="DiaryTitle" runat="server"></asp:Label><br /></h1>
    正文： <br />
   

     <p><asp:Label ID="DiaryContext" runat="server"></asp:Label></p><br />
     <p>发表时间：<asp:Label ID="DiaryTime" runat="server"></asp:Label></p><br />

    <asp:Button ID="AddComment" runat="server" OnClick="AddComment_Click" Text="新增评论" /><br />
    评论：<br />
    <asp:Repeater ID="Comment" runat="server" OnItemCommand="Comment_ItemCommand" OnItemDataBound="Comment_ItemDataBound">        
        <ItemTemplate>            
            <asp:Label ID="Comment" runat="server" Text='<%#Eval("Comment")%>'></asp:Label><br />
            评论者：<%#Eval("CommentUser") %><br />
            昵称：<%#Eval("UserNickName") %><br />
            备注：<%#Eval("Remark") %><br />
            时间：<%#Eval("Time") %><br />            
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

