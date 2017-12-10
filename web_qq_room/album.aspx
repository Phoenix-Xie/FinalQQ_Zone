<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="album.aspx.cs" Inherits="album" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function checkform() {
            var strs = document.getElementById("FileUpload1").value;
            if (strs == "") {
                alert("请选择要上传的图片!");
                return false;
            }

            var n1 = strs.lastIndexOf('.') + 1;
            var fileExt = strs.substring(n1, n1 + 3).toLowerCase()
            if (fileExt != "jpg" && fileExt != "bmp" && fileExt != "png") {
                alert('目前系统仅支持jpg、bmp、png后缀图片上传!');
                return false;
            }
        }
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:FileUpload ID="FileUploadTextBox" runat="server" Width="220px" /><br />
    <asp:TextBox ID="ImageName" runat="server"></asp:TextBox>
    <asp:Button ID="FileUploadButton" runat="server" OnClick="Button1_Click" Text="上传" /><br />
    <a href="albumlist.aspx" >返回相册列表</a><br />
    <asp:Repeater ID="Image" runat="server" OnItemCommand="Image_ItemCommand" OnItemDataBound="Image_ItemDataBound">        
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Label ID="Name" runat="server" Text='<%#Eval("ImageName")%>'></asp:Label><br />
            <asp:Image ID="image" runat="server" ImageUrl='<%#Eval("ImagePath")%>'  Width="150px" Height="150px" /><br />
            上传时间:<asp:Label ID="UploadTime" runat="server" Text='<%#Eval("Time") %>'></asp:Label><br />
            <asp:LinkButton ID="Delete" runat="server" CommandName="delete" CommandArgument='<%#Eval("id")%>' Text="删除"></asp:LinkButton><br />
            <asp:LinkButton ID="ChangeCover" runat="server" CommandName="ChangeCover" CommandArgument='<%#Eval("id") %>' Text="设为封面"></asp:LinkButton><br />
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

