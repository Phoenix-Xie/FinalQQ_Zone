<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="diary.aspx.cs" Inherits="diary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="AddNewDiary" runat="server" OnClick="AddNewDiary_Click" Text="新增日志" /><br />
日志列表<br />
    <asp:Repeater ID="Diary" runat="server" OnItemCommand="Diary_ItemCommand" OnItemDataBound="Diary_ItemDataBound">
        <HeaderTemplate>
            <table>
            <tr>
                <th>文章标题</th>
                <th>查看</th>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("DiaryTitle") %></td>
                <td><%# Eval("Time") %></td>
                <td><asp:LinkButton ID="ChooseDiary" runat="server" CommandName="ChooseDiary" CommandArgument='<%#Eval("id") %>' Text="查看"></asp:LinkButton></td>
                <td><asp:LinkButton ID="DeleteDiary" runat="server" CommandName="Delete" CommandArgument='<%#Eval("id") %>' Text="删除"></asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    当前页数：<asp:Label ID="IndexNow" runat="server" ReadOnly="true"></asp:Label><br />
    总页数：<asp:Label ID="IndexAll" runat="server" ReadOnly="true"></asp:Label><br />
    <asp:Button ID="FormerPage" runat="server" OnClick="FormerPage_Click" Text="上一页" />
    <asp:Button ID="NextPage" runat="server" OnClick="NextPage_Click" Text="下一页"/>
</asp:Content>

