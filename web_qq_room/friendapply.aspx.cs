using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class friendapply : System.Web.UI.Page
{
    User usr = new User();
    string AccountName, Friend;
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        if(!IsPostBack)
        {
            DataBlindToRepeater(1);
        }      
    }
    //此处 函数 与别的页面不同，保证登入者为本人
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
                    Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
        }
    }

    protected void FriendApply_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "Agree")
        {
            string str = e.CommandArgument.ToString();
            string[] Arguments = str.Split('$');
            string error1 = usr.addFriend(AccountName, Arguments[0]);
            string error2 = usr.deleteApplyFriend(Convert.ToInt32(Arguments[1]));
            if (error1 != null)
            {
                Response.Write("<script>alert('" + error1 + "');location = 'friend.aspx'</script>");
            }
            else if(error2 != null)
            {
                Response.Write("<script>alert('" + error2 + "');location = 'friend.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('添加成功');location = 'friendapply.aspx'</script>");
            }
        }
        if(e.CommandName == "Disagree")
        {
            string error = usr.deleteApplyFriend(Convert.ToInt32(e.CommandArgument));
            if (error == null)
            {
                Response.Write("<script>alert('申请删除成功');location = 'friendapply.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('" + error + "')</script>");
            }
        }
        if(e.CommandName == "ApplyFriend")
        {
            Session["Friend"] = e.CommandArgument;
            Response.Redirect("home.aspx");
        }
    }

    protected void DataBlindToRepeater(int page)
    {
        DataTable dt = new DataTable();
        dt = usr.getApplyFriend(AccountName);

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;
        pds.PageSize = 3;

        pds.DataSource = dt.DefaultView;

        IndexNow.Text = page.ToString();
        IndexAll.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = page - 1;
        ApplyFriendList.DataSource = pds;
        ApplyFriendList.DataBind();
    }

    //翻页操作
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

}