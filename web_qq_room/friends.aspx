<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="friends.aspx.cs" Inherits="friends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <a href="searchfriend.aspx">寻找好友</a>
    <a href="friendapply.aspx">好友申请</a><br />
    <asp:Repeater ID="Friends" runat="server" OnItemCommand="Friends_ItemCommand">
        <HeaderTemplate>
            <table >
                <tr>
                    <th> 好友账户 </th>
                    <th>好友昵称</th>
                    <th>头像</th>
                    <th>备注</th>
                    <th> 访问空间 </th>
                    <th>点击修改填入备注</th>
                    <th>删除与该好友的关系</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <th><asp:LinkButton ID="Visit" runat="server" CommandName="Visit" CommandArgument='<%#Eval("Friend") %>' Text='<%#Eval("Friend") %>'></asp:LinkButton></th>
                <th><asp:LinkButton ID="NickName" runat="server" CommandName="Visit" CommandArgument='<%#Eval("Friend") %>' Text='<%#Eval("UserNickName") %>'></asp:LinkButton></th>
                <th><asp:Image ID="ProfileImage" runat="server" ImageUrl='<%#Eval("ProfileImage")%>' Width="75px" Height="75px"/></th>
                <th><asp:Label ID="Remark" runat="server" Text='<%#Eval("Remark")%>'></asp:Label></th>
                <th><asp:LinkButton ID="VisitZone" runat="server" CommandName="Visit" CommandArgument='<%#Eval("Friend") %>' Text="访问" ></asp:LinkButton></th>
                <th><asp:LinkButton ID="ChangeRemark" runat ="server" CommandName="ChangeRemark" CommandArgument = '<%#Eval("id") %>' Text="修改"></asp:LinkButton></th>
                <th><asp:LinkButton ID="DeleteFriend" runat="server" CommandName="DeleteFriend" CommandArgument='<%#Eval("Friend") %>' OnClientClick="return confirm('确定要删除吗？删除后不能恢复！');" Text="删除与该好友关系"></asp:LinkButton></th>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Label ID="RemarkFriend" runat="server" Visible="false" Text="在此输入新的备注名"></asp:Label>
    <asp:TextBox ID="NewRemark" runat="server" Visible="false"></asp:TextBox>
    <asp:Button ID="ChangeRemark" runat="server" Visible ="false" Text="修改！" OnClick="ChangeRemark_Click"/>
    <asp:Button ID="CancelChangeRemark" runat="server" Visible="false" Text="取消修改备注" OnClick="CancelChangeRemark_Click" />

    <asp:Button ID="FormerPage" runat="server" Text="上一页" OnClick="FormerPage_Click" />
    <asp:Button ID="NextPage" runat="server" Text ="下一页" OnClick="NextPage_Click" /> <br />

    <asp:Label ID="IndexNow" runat="server"></asp:Label>/
    <asp:Label ID="IndexAll" runat="server"></asp:Label>
</asp:Content>

