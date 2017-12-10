using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data.SqlClient;
using System.Data;

public partial class album : System.Web.UI.Page
{
    string AccountName, Friend;
    Sql sql = new Sql();
    User usr = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        FileUploadButton.Attributes["onclick"] = "return checkform();";
        if(!IsPostBack)
        {
            try
            {
                DataBlindToRepeater(1);
            }
            catch
            {
                Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
            }
        }        
    }
    protected void Test_username()
    {
        try
        {
            Friend = Session["Friend"].ToString();
            AccountName = Session["AccountName"].ToString();
            if (AccountName == null)
            {
                Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
            }
            else
            {
                if (AccountName != Friend)
                {
                    CloseSomedivForFriendVisit();
                }
                else
                {
                    CloseSomedivForOwn();
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
        }
    }
    protected void CloseSomedivForFriendVisit()
    {
        FileUploadTextBox.Visible = false;
        ImageName.Visible = false;
        FileUploadButton.Visible = false;
        Session["FriendStatu"] = "true";
    }
    protected void CloseSomedivForOwn()
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (FileUploadTextBox.HasFile)
        {
            string upPath = "\\album\\";  //上传文件路径
            int upLength = 10;        //上传文件大小
            string upFileType = "|image/bmp|image/x-png|image/pjpeg|image/gif|image/png|image/jpeg|";

            string fileContentType = FileUploadTextBox.PostedFile.ContentType;    //文件类型

            if (upFileType.IndexOf(fileContentType.ToLower()) > 0)
            {
                string name = FileUploadTextBox.PostedFile.FileName;                  // 客户端文件路径

                FileInfo file = new FileInfo(name);

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff")+AccountName+ file.Extension; // 文件名称，当前时间（yyyyMMddhhmmssfff)加上用户名称
                string webFilePath = Server.MapPath(upPath) + fileName;        // 服务器端文件路径

                string FilePath = upPath + fileName;   //页面中使用的路径

                try
                {
                    usr.addImage(FilePath, ImageName.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),Session["Albumid"].ToString());  //向数据库写入数据
                }
                catch
                {
                    Response.Write("<script>alert('请选择相册进入');location = 'albumlist.aspx'</script>");
                }
                if (!File.Exists(webFilePath))
                {
                    if ((FileUploadTextBox.FileBytes.Length / (1024 * 1024)) > upLength)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('大小超出 " + upLength + " M的限制，请处理后再上传！');", true);
                        return;
                    }

                    try
                    {
                        FileUploadTextBox.SaveAs(webFilePath);                                // 使用 SaveAs 方法保存文件


                        ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件上传成功');", true);
                        Response.Redirect("album.aspx");
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件上传失败" + ex.Message + "');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件已经存在，请重命名后上传');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件类型不符');", true);
            }
        }

    }


    protected void Image_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "delete")
        {
            string error = usr.deleteImage(e.CommandArgument.ToString());
            if(error == null)
            {
                Response.Write("<script>alert('删除成功');location = 'album.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('" + error + "')</script>");
            }
        }
        if(e.CommandName == "ChangeCover")
        {
            try
            {
                string Albumid = Session["Albumid"].ToString();
                string error = usr.updataAlbumCover(Albumid, e.CommandArgument.ToString());
                if(error == null)
                {
                    Response.Write("<script>alert('设置成功');location = 'album.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('" + error + "')</script>");
                }
            }
            catch
            {
            Response.Write("<script>alert('请选择相册登入');location = 'albumlist.aspx'</script>");
            }
        }
    }

    protected void DataBlindToRepeater(int Page)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = usr.getImage(Session["Albumid"].ToString());
        }
        catch
        {
            Response.Write("<script>alert('请选择相册登入');location = 'albumlist.aspx'</script>");
        }
        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;
        pds.PageSize = 3;
        pds.DataSource = dt.DefaultView;

        IndexAll.Text = pds.PageCount.ToString();
        IndexNow.Text = Page.ToString();

        pds.CurrentPageIndex = Page - 1;
        Image.DataSource = pds;
        Image.DataBind();
    }

    public void FormerPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(IndexNow.Text.ToString()) - 1 <= 0)
        {
            Response.Write("<script>alert('已经到了首页')</script>");
        }
        else
        {
            DataBlindToRepeater(Convert.ToInt32(IndexNow.Text.ToString()) - 1);            
        }
    }
    protected void NextPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(IndexNow.Text.ToString()) + 1 > Convert.ToInt32(IndexAll.Text))
        {
            Response.Write("<script>alert('已经到了末页')</script>");
        }
        else
        {
            DataBlindToRepeater(Convert.ToInt32(IndexNow.Text.ToString()) + 1);        
        }
    }

    protected void Image_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (Session["FriendStatu"].ToString() == "true")
            {
                ((LinkButton)e.Item.FindControl("Delete")).Visible = false;  //关闭Delete按钮
                ((LinkButton)e.Item.FindControl("ChangeCover")).Visible = false;//关闭设为封面按钮
            }
        }
        catch
        { }
    }
}