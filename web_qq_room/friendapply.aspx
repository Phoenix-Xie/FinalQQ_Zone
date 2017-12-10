<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="friendapply.aspx.cs" Inherits="friendapply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="ApplyFriendList" runat="server" OnItemCommand="FriendApply_ItemCommand">
        <HeaderTemplate>
            <table>
                <h3>
                    <tr>
                      <th>申请者名称</th>
                       <th>同意</th>
                    <th>丑拒</th>
                        </tr>
                </h3>
                <br />
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
            <th><asp:LinkButton ID="ApplyFriend" runat="server" CommandName="ApplyFriend" CommandArgument='<%#Eval("ApplyFriend")%>' Text='<%#Eval("ApplyFriend")%>'></asp:LinkButton> <br /></th>
            <th><asp:LinkButton ID="Agree" runat="server" CommandName="Agree" CommandArgument='<%#Eval("ApplyFriend")+"$"+Eval("id") %>' Text="同意"></asp:LinkButton><br /></th>
            <th><asp:LinkButton ID="Disagree" runat="server" CommandName="Disagree" CommandArgument='<%#Eval("id")%>' Text="拒绝"></asp:LinkButton><br /></th>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button ID="FormerPage" runat="server" Text="上一页" OnClick="FormerPage_Click" />
    <asp:Button ID="NextPage" runat="server" Text ="下一页" OnClick="NextPage_Click" /> <br />
    <asp:Label ID="IndexNow" runat="server"></asp:Label>/
    <asp:Label ID="IndexAll" runat="server"></asp:Label>
</asp:Content>

