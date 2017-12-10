using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addmessagecomment : System.Web.UI.Page
{
    User usr = new User();
    string AccountName, Friend, Messageid;
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        if (!IsPostBack)
        {
            Comment.InnerText = "在此处书写美好，记得要加上标题哦";
        }
        try
        {
            Messageid = Session["Messageid"].ToString();
        }
        catch
        {
            Response.Write("<script>alert('连接错误');location = 'home.aspx'</script>");
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
                    CloseSomediv();
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
        }
    }
    protected void CloseSomediv()
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string CommentText = Context.Request.Form["Comment"];
        try
        {
            string error = usr.addNewMessageComment(Session["AccountName"].ToString(), CommentText, Session["Messageid"].ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if(error == null)
            {
                Response.Write("<script>alert('新增成功');location='message_box.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('" + error + "');location='message_box.aspx'</script>");
            }
        }
        catch
        {
            Response.Write("<script>alert('连接出错');location='message_box.aspx'</script>");
        }
    }
}