using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class diary : System.Web.UI.Page
{
    string AccountName, Friend;
    User usr = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        if(!IsPostBack)
        {
            try
            {
                DataBlindToDiary(1);
                IndexNow.Text = "1";
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
                    CloseSomedivForVisit();
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
    protected void CloseSomedivForVisit()
    {
        AddNewDiary.Visible = false;
        Session["FriendStatu"] = "true";
    }
    protected void CloseSomedivForOwn()
    {
    }

    protected void Diary_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "ChooseDiary")
        {
            Session["Diaryid"] = e.CommandArgument;
            Response.Redirect("diarycontent.aspx");
        }
        if(e.CommandName == "Delete")
        {
            string error = usr.deleteDiary(Convert.ToInt32(e.CommandArgument));
            if(error == null)
            {
                Response.Write("<script>alert('删除成功');location = 'diary.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('" + error + "')</script>");
            }
        }
    }

    /// <summary>
    /// 显示第Page页的内容
    /// </summary>
    /// <param name="Page"></param>
    protected void DataBlindToDiary(int Page)
    {
        DataTable dt = new DataTable();
        
        dt = usr.getDiaryTitle(Friend);

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;
        pds.PageSize = 3;
        pds.DataSource = dt.DefaultView;

        IndexAll.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = Page - 1;
        Diary.DataSource = pds;
        Diary.DataBind();
    }

    //翻页函数，更新页面信息以及向下翻页
    protected void NextPage_Click(object sender, EventArgs e)
    {
        if(Convert.ToInt32(IndexNow.Text) == Convert.ToInt32(IndexAll.Text))
        {
            Response.Write("<script>alert('已经到了末页')</script>");
        }
        else
        {
            DataBlindToDiary(Convert.ToInt32(IndexNow.Text) + 1);
            IndexNow.Text = Convert.ToString(Convert.ToInt32(IndexNow.Text) + 1);
        }
    }

    protected void FormerPage_Click(object sender, EventArgs e)
    {
        if(Convert.ToInt32(IndexNow.Text) == 1)
        {
            Response.Write("<script>alert('已经到了首页')</script>");
        }
        else
        {
            DataBlindToDiary(Convert.ToInt32(IndexNow.Text) - 1);
            IndexNow.Text = Convert.ToString(Convert.ToInt32(IndexNow.Text) - 1);
        }
    }

    protected void AddNewDiary_Click(object sender, EventArgs e)
    {
        Response.Redirect("adddiary.aspx");
    }

    //好友访问时删除钮隐藏
    protected void Diary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (Session["FriendStatu"].ToString() == "true")
            {
                ((LinkButton)e.Item.FindControl("DeleteDiary")).Visible = false;  //关闭Delete按钮
            }
        }
        catch
        { }
    }
}