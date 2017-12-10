<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="message_box.aspx.cs" Inherits="message_box" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="AddNewMessage" runat="server"  Text="新增留言" OnClick="AddNewMessage_Click"/><br />
    <asp:Repeater ID="Message" runat="server" OnItemCommand="Message_ItemCommand" OnItemDataBound="Message_ItemDataBound">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            
            <%#Eval("MessageUser") %>的留言：<br />
            <%#Eval("Message")%><br />
           时间： <%#Eval("Time") %><br />
                
            <asp:LinkButton id="Delete" CommandName="delete" runat="server" CommandArgument='<%#Eval("id") %>' Text="删除" ></asp:LinkButton><br />
            <asp:LinkButton runat="server" ID="OpenComment" CommandName="OpenComment" CommandArgument="" Text="查看回复" ></asp:LinkButton>
            <asp:LinkButton runat="server" ID="CloseComment" CommandName="CloseComment" CommandArgument="" Text="收起回复" Visible="false"></asp:LinkButton><br />
                
            <asp:Repeater ID="Return" runat="server"  OnItemCommand="Return_ItemCommand" Visible="false" >                
                <ItemTemplate>                  
                <%#Eval("MessageCommentUser") %>的回复：<br />
                <%#Eval("MessageComment")%></th><br />    
                  时间：  <%#Eval("Time") %><br />
                 </ItemTemplate>
            </asp:Repeater><br />
            <asp:LinkButton ID="AddMessageComment" runat="server" CommandName="AddComment" CommandArgument='<%#Eval("id") %>' Text="新增回复"></asp:LinkButton><br />
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <asp:Button ID="FormerPage" runat="server" Text="上一页" OnClick="FormerPage_Click"/>
    <asp:Button ID="NextPage" runat="server" Text ="下一页" OnClick="NextPage_Click" /> <br />
    <asp:Label ID="IndexNow" runat="server"></asp:Label>/
    <asp:Label ID="IndexAll" runat="server"></asp:Label>

</asp:Content>

