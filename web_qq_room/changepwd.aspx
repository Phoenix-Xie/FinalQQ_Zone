<%@ Page Title="" Language="C#" MasterPageFile="~/sign_and_login.master" AutoEventWireup="true" CodeFile="changepwd.aspx.cs" Inherits="changepwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     找回密码<br />
    用户名：
    <asp:TextBox ID="AccountName" runat="server"></asp:TextBox><br />
    请回答以下问题：<br />
    <asp:Button ID="QuestionVisible" runat="server" Text="显示相应问题" OnClick="QuestionVisible_Click"/>
            
    <asp:TextBox ID="Question" runat="server" Text=""  ReadOnly="true"></asp:TextBox> <br />
    你的答案：
    <asp:TextBox ID="Answer" runat="server" ></asp:TextBox> <br />
    <asp:Button ID ="Submit" runat="server" Text="找回" OnClick="Submit_Click"/> <br />
    <asp:Label ID="Hint" runat="server" Text="新密码：" Visible="false"></asp:Label>
    <asp:TextBox ID="NewPwd" runat="server" Visible="false" TextMode="Password"></asp:TextBox><br />
    <asp:Label ID="Hint2" runat="server" Text="再次输入" Visible="false"></asp:Label>
    <asp:TextBox ID="NewPwdTwice" runat="server" Visible="false" TextMode="Password"></asp:TextBox><br />
    <asp:Button ID="Change" runat="server" Visible="false" Text="提交" OnClick="Change_Click" />
</asp:Content>

