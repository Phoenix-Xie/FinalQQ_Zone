using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addcomment : System.Web.UI.Page
{
    User usr = new User();
    string AccountName, Friend, Pageid;
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        if (!IsPostBack)
        {
            Comment.InnerText = "在此处书写美好，记得要加上标题哦";
        }
        try
        {
            Pageid = Session["Pageid"].ToString();
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
                    CloseSomedivforVisit();
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
        }
    }
    public void CloseSomedivforVisit()
    {

    }
   

    protected void Submit_Click(object sender, EventArgs e)
    {
        string CommentText = Context.Request.Form["Comment"];

        usr.addNewComment(Convert.ToInt32(Pageid), CommentText, AccountName);
        Response.Write("<script>alert('新增成功');location='home.aspx'</script>");

    }
}