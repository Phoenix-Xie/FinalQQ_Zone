<%@ Page Title="" Language="C#" MasterPageFile="~/sign_and_login.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            登入：<br />
            用户名：
            <asp:TextBox ID ="AccountName" runat ="server"></asp:TextBox><br />
            密码：
            <asp:TextBox ID ="Pwd" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID ="Login_button" runat="server" Text="登入" OnClick="Login_button_Click" />  <br /> 
        
            验证码：
            <asp:TextBox ID="tbx_yzm" runat="server" Width="70px"></asp:TextBox>
            <asp:ImageButton ID="ibtn_yzm" runat="server" />

            <a href="javascript:changeCode()"style="text-decoration: underline; font-size:10px;">换一张</a><br />
            <asp:CheckBox ID="LoginRemenber" runat="server" Checked="false" Text="自动登入(一天)" /><br />
            <asp:Button ID="FindPwd" runat="server" Text="忘记密码" />


            <script type="text/javascript">
                
            function changeCode() 
            {
             document.getElementById('ibtn_yzm').src = document.getElementById('ibtn_yzm').src + '?';
             }
            </script>                
</asp:Content>

