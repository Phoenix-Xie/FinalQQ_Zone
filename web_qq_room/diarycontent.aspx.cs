using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class diarycontent : System.Web.UI.Page
{
    string AccountName, Friend;
    int id;
    User usr = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        try
        {
            id = Convert.ToInt32(Session["Diaryid"]);
            DataTable dt = new DataTable();
            dt = usr.getDiary(id);
            DiaryTitle.Text = dt.Rows[0][0].ToString();
            DiaryContext.Text = dt.Rows[0][1].ToString();
            DiaryTime.Text = dt.Rows[0][2].ToString();
            DataBlindToRepeater(id);
        }
        catch
        {
            Response.Write("<script>alert('连接错误');location = 'diary.aspx'</script>");
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
                    CloseSomedivForVisit();
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
        }
    }
    protected void CloseSomedivForVisit()
    {

    }

    protected void DataBlindToRepeater(int id)
    {
        DataTable dt = new DataTable();
        dt = usr.getDiaryComment(id);

        Comment.DataSource = dt; //设置数据源
        Comment.DataBind();

    }

    protected void AddComment_Click(object sender, EventArgs e)
    {
        Response.Redirect("adddiarycomment.aspx");
    }

    protected void Comment_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       
    }

    protected void Comment_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            id = Convert.ToInt32(Session["Diaryid"]);
        }
        catch
        {
            Response.Write("<script>alert('连接错误');location = 'diary.aspx'</script>");
        }        
    }
}