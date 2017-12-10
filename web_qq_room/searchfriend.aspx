<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchfriend.aspx.cs" Inherits="searchfriend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    信息类型：
    <asp:DropDownList ID="ImformationType" runat="server">
        <asp:ListItem Value ="AccountName">账户</asp:ListItem>
        <asp:ListItem Value="UserNickName">昵称</asp:ListItem>
    </asp:DropDownList><br />
    信息内容：
    <asp:TextBox ID="Imformation" runat="server"></asp:TextBox><br />
    性别：
    <asp:DropDownList ID="SexImformation" runat="server">
        <asp:ListItem>全部</asp:ListItem>
        <asp:ListItem>男</asp:ListItem>
        <asp:ListItem>女</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Search" runat="server" Text="搜索" OnClick="Search_Click"/><br />
    <asp:Repeater ID="SearchList" runat="server" OnItemCommand="SearchList_ItemCommand">
        <HeaderTemplate>
            <table>
                <h2>
                <tr>
                    <th>账户名</th>
                    <th>昵称</th>
                    <th>性别</th>
                    <th>申请添加</th>
                 </tr>
                </h2>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("AccountName")%> </td>
                <td><%#Eval("UserNickName") %></td>
                <td><%#Eval("Sex") %></td>
                <td><asp:LinkButton ID="addNewFriend" runat="server" CommandName="Add" CommandArgument='<%#Eval("AccountName")%>' Text="申请添加"></asp:LinkButton></td><br />
          </tr>
         </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button ID="FormerPage" runat="server" Text="上一页" OnClick="FormerPage_Click" />
            <asp:Button ID="NextPage" runat="server" Text ="下一页" OnClick="NextPage_Click" /> <br />

    <asp:Label ID="IndexNow" runat="server" ></asp:Label>/
    <asp:Label ID="IndexAll" runat="server"></asp:Label>
</asp:Content>

