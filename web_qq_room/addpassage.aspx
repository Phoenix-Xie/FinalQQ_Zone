<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="addpassage.aspx.cs" Inherits="addpassage" %>


<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Document</title>
</head>
<body runat="server">
    <form id="form1" runat="server">
   <!--<div style="height: 800px; padding-left:200px;padding-top:100px;font-size:30px;color: black;FILTER: progid:DXImageTransform.Microsoft.Gradient(gradientType=0,startColorStr=#a8edea,endColorStr=#fed6e3); /*IE*/ 
background:-moz-linear-gradient(top,#a8edea,#fed6e3);/*火狐*/ 
background:-webkit-gradient(linear, 0% 0%, 0% 100%,from(#a8edea), to(#fed6e3));/*谷歌*/ 
background-image: -webkit-gradient(linear,left bottom,left top,color-start(0, #a8edea),color-stop(1, #fed6e3));">-->
    <div class = "gaoxiao" style="position:absolute;z-index:2;">
        <a href="home.aspx">个人主页</a>
        <a href="self.aspx" style="color: black;">个人档</a>
        <a href="diary.aspx" style="color: black;">日志</a>
        <a href="message_box.aspx" style="color: black;">留言板</a>
        <a href="album.aspx" style="color: black;">相册</a>
        <a href="friends.aspx" style="color: black;">好友</a><br />
    

       文章标题： <asp:TextBox ID="PassageTitle" runat="server"></asp:TextBox>
   <!-- 配置文件 -->
    <script type="text/javascript" src="/ueditor/ueditor.config.js"></script>
    <!-- 编辑器源码文件 -->
    <script type="text/javascript" src="/ueditor/ueditor.all.js"></script>
        <!--编辑器配置-->
    <script type="text/javascript" >
        var ue = UE.getEditor('container', {
            toolbars: [[                
                'undo', //撤销
                'redo', //重做
                '|',
                'bold', 'italic', 'underline', 'fontborder', 'strikethrough', 'superscript', 'subscript', 'removeformat',
                '|',
                'justifyleft', //居左对齐
                'justifycenter', //居中对齐
                'justifyright', //居右对齐
                'justifyjustify', //两端对齐
                '|',
                'indent', //首行缩进
                'insertorderedlist', //有序列表
                'insertunorderedlist', //无序列表
                '|',
                'touppercase', 'tolowercase', 'emotion',
                '|',
                'forecolor', //字体颜色
                'backcolor', //背景色               
                '|',
                'cleardoc', //清空文档
                '|',
                'fontfamily', //字体
                'fontsize', //字号
                'fullscreen', //全屏
            ]],
            initialFrameWidth: 800, // 编辑器宽度
            initialFrameHeight: 250  // 编辑器高度
        });
        ue.render("<%=Passage.ClientID%>")
    </script>
    <textarea id="Passage" name="Passage" runat="server"></textarea>
    <asp:Button ID="Submit" runat="server" Text="提交" OnClick="Submit_Click" />
        </div>
    </form>
</body>
</html>


