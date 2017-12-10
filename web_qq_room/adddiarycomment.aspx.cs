using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adddiarycomment : System.Web.UI.Page
{
    User usr = new User();
    string AccountName, Friend, Diaryid;
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        if (!IsPostBack)
        {
            Comment.InnerText = "在此处书写美好，记得要加上标题哦";
        }
        try
        {
            Diaryid = Session["Diaryid"].ToString();
        }
        catch
        {
            Response.Write("<script>alert('连接错误');location = 'diarycontent.aspx'</script>");
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
            }
        }
        catch
        {
            Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
        }
    }
    protected void CloseSomedivForFriendVisit()
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string CommentText = Context.Request.Form["Comment"];

        usr.addDiaryComment(AccountName, CommentText, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),Session["Diaryid"].ToString());
        Response.Write("<script>alert('新增成功');location='diarycontent.aspx'</script>");
    }
}