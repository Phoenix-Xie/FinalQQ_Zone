<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="self.aspx.cs" Inherits="self"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
个人档<br />
    账户：<br />
    <asp:Label ID ="AccountNameTextBox" runat="server"></asp:Label><br />
    昵称：<br />
    <asp:TextBox ID ="UserNickName" runat="server"></asp:TextBox><br />
    头像：<br />
    <asp:Image ID="ProfileImage" runat="server" Width="100px" Height="100px" /><br />
    年龄：<br />
    <asp:Label ID="Age" runat="server" ></asp:Label><br />
    性别：<br />
    <asp:DropDownList ID="Sex" runat="server">
        <asp:ListItem>男</asp:ListItem>
        <asp:ListItem>女</asp:ListItem>
    </asp:DropDownList><br />
    省份:<br />
    <asp:DropDownList ID="Province" runat="server"></asp:DropDownList><br />
    出生年份：<br />
    <asp:DropDownList ID="BornYear" runat="server"></asp:DropDownList><br />
    出生月份：<br />
    <asp:DropDownList ID="BornMonth" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
    </asp:DropDownList><br />
    出生日：<br />
   <asp:DropDownList ID="BornDay" runat="server"></asp:DropDownList> <br />
    职业：<br />
    <asp:TextBox ID ="Profession" runat="server"></asp:TextBox><br />
    <asp:Button ID ="ChangeImformation" runat ="server" Text="修改" OnClick="ChangeImformation_Click" /><br />
    <asp:Button ID="UploadVisible" runat="server" Text="上传头像" OnClick="UploadVisible_Click" /><br />
    <asp:Button ID="ChangeQuestionVisible" runat="server" Text="修改密保问题" OnClick="ChangeQuestionVisible_Click" /><br />
    
    <asp:Label ID="UploadText" runat="server" Text="上传头像：" Visible="false"></asp:Label>
    <asp:FileUpload ID="ProfileUploadBox" runat="server" Visible="false" /><br />
    <asp:Button ID="Upload" runat="server" OnClick="Upload_Click" Text="上传" Visible="false"/>

    
    <asp:Label ID="QuestionText" runat="server" Text="密保问题：" Visible="false"></asp:Label><br />
    <asp:DropDownList ID="Question" runat="server" Visible="false">
        <asp:ListItem>小时候最喜欢的人的名字</asp:ListItem>
        <asp:ListItem>现在或最近时期班主任名字</asp:ListItem>
        <asp:ListItem>最喜欢的食物</asp:ListItem>
        <asp:ListItem>最喜欢的运动</asp:ListItem>
        <asp:ListItem>父亲的生日</asp:ListItem>
        <asp:ListItem>母亲的生日</asp:ListItem>
    </asp:DropDownList><br />
            
    <asp:Label ID="QuestionText2" runat="server" Text="自主选择密保问题在此输入:" Visible="false"></asp:Label><br />
    <asp:TextBox ID="QuestionSelf" runat="server" Text="" Visible ="false" ></asp:TextBox><br />
    <asp:Label ID="AnswerText" runat="server" Text="设置问题答案:" Visible="false"></asp:Label><br />
    <asp:TextBox ID="Answer" runat="server" Visible="false" ></asp:TextBox><br />
    <asp:Button ID="ChangeQuestion" runat="server" Text="提交" OnClick="ChangeQuestion_Click" Visible="false" />
    

</asp:Content>

