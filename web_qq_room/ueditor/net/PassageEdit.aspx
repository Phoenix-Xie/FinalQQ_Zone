<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PassageEdit.aspx.cs" Inherits="utf8_net_net_PassageEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>编辑器实例</title>  <!--下面的几个js和css引用顺序不要变。变得话可能导致编辑器显示不出来-->
      <script type="text/javascript" src="utf8-net/ueditor.config.js"></script>
      <script type="text/javascript" src="utf8-net/ueditor.all.js"></script>
      <link rel="stylesheet" href="editor/themes/default/dialogbase.css" />
     <style type="text/css">
         #myEditor
         {
             width: 700px; 
             height: 700px;
         }
     </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <textarea id="myEditor" name="myEditor" runat="server" onblur="setUeditor()"></textarea>                 
            <script type="text/javascript">
            var editor = new baidu.editor.ui.Editor();
            editor.render("myEditor");
            </script>
        <div id="myButton" runat="server">
        </div>       
    </div>
              <script type="text/javascript">
    function setUeditor() {
    var myEditor = document.getElementById("myEditor");
        myEditor.value = editor.getContent();

    }
          </script>
</asp:Content>

