<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="AddNewPassage" runat="server" OnClick="AddNewPassage_Click" Text="新增动态" />
        <asp:Repeater ID="Passage" runat="server" OnItemDataBound="Passage_ItemDataBound" OnItemCommand="Passage_ItemCommand">
            <ItemTemplate>
                <h2>
                    标题：<%#Eval("Title") %>
                </h2>
                <%#Eval("Passage") %><br />
                时间：<%#Eval("Time") %><br />
                <asp:LinkButton ID="Delete" runat="server" CommandName="delete" CommandArgument='<%#Eval("id")%>' Text="删除该动态"></asp:LinkButton> <br />               
                <h3> 评论</h3>
                <asp:LinkButton runat="server" ID="OpenComment" CommandName="OpenComment" CommandArgument="" Text="查看评论" ></asp:LinkButton>
                <asp:LinkButton runat="server" ID="CloseComment" CommandName="CloseComment" CommandArgument="" Text="收起评论" Visible="false"></asp:LinkButton>
                <asp:Repeater ID="Comment" runat="server" OnItemCommand="Comment_ItemCommand" Visible ="false">
                    <ItemTemplate>                  
                        评论：<asp:Label  runat="server" ID="CommentText" Text='<%#Eval("Comment") %>'></asp:Label>     <br />
                       评论者：<asp:LinkButton ID="CommentUser" CommandName="CommentUser" runat="server" CommandArgument='<%#Eval("CommentUser") %>' Text='<%#Eval("CommentUser") %>'></asp:LinkButton> <br />
                        备注：<asp:LinkButton ID="Remark" CommandName="CommentUser" runat="server" CommandArgument='<%#Eval("CommentUser") %>' Text='<%#Eval("Remark") %>'></asp:LinkButton> <br />
                        昵称：<asp:LinkButton ID="UserNickName" CommandName="CommentUser" runat="server" CommandArgument='<%#Eval("CommentUser") %>' Text='<%#Eval("UserNickName") %>'></asp:LinkButton> <br />
                        评论时间：<%#Eval("Time") %><br /><br />                       
                    </ItemTemplate>
                </asp:Repeater>
                <asp:LinkButton ID="AddNewComment" runat="server" CommandName="Add" CommandArgument='<%#Eval("id")%>' Text ="新增评论"></asp:LinkButton><br />
            </ItemTemplate>
        </asp:Repeater>
    <br />
            <asp:Button ID="FormerPage" runat="server" Text="上一页" OnClick="FormerPage_Click" />
            <asp:Button ID="NextPage" runat="server" Text ="下一页" OnClick="NextPage_Click" /> <br />
            <asp:Label ID="IndexNow" runat="server"></asp:Label>/
            <asp:Label ID="IndexAll" runat="server"></asp:Label>
</asp:Content>

