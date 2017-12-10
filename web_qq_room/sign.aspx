<%@ Page Title="" Language="C#" MasterPageFile="~/sign_and_login.master" AutoEventWireup="true" CodeFile="sign.aspx.cs" Inherits="sign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    用户注册：<br />
            欢迎来到pp空间<br />

            设置账户：
            <asp:TextBox ID ="AccountName" runat ="server" MaxLength ="15" ></asp:TextBox><br />
            设置密码：
            <asp:TextBox ID ="Pwd" runat ="server" TextMode ="Password" MaxLength ="15"></asp:TextBox><br />
            密码应该五位以上，并且数字大小写字母混合，带有特殊字符 <br />
            再次输入密码：
            <asp:TextBox ID ="Pwd2" runat="server" TextMode ="Password"></asp:TextBox><br />  
            <br /><br />
            设置昵称：
            <asp:TextBox ID="NickName" runat="server" ></asp:TextBox><br />
            密保问题：
            <asp:DropDownList ID="Question" runat="server">
                <asp:ListItem>小时候最喜欢的人的名字</asp:ListItem>
                <asp:ListItem>现在或最近时期班主任名字</asp:ListItem>
                <asp:ListItem>最喜欢的食物</asp:ListItem>
                <asp:ListItem>最喜欢的运动</asp:ListItem>
                <asp:ListItem>父亲的生日</asp:ListItem>
                <asp:ListItem>母亲的生日</asp:ListItem>
            </asp:DropDownList><br />
            
            自主选择密保问题请在以下方框输入：
            <asp:TextBox ID="QuestionSelf" runat="server" Text="" ></asp:TextBox><br />
            设置问题答案<br />
            <asp:TextBox ID="Answer" runat="server" ></asp:TextBox><br />


            验证码：
            <asp:TextBox ID="tbx_yzm" runat="server" Width="70px"></asp:TextBox>
            <asp:ImageButton ID="ibtn_yzm" runat="server" />
             <a href="javascript:changeCode()"style="text-decoration: underline; font-size:10px;">换一张</a>
                    <script type="text/javascript">
                        function changeCode() {
                            document.getElementById('ibtn_yzm').src = document.getElementById('ibtn_yzm').src + '?';
                        }
            </script>
            
        
            <asp:Button ID ="Submit" runat="server" Text ="提交" OnClick="Sign_submit_Click" />
        
</asp:Content>

