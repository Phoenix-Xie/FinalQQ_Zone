using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class friends : System.Web.UI.Page
{
    User usr = new User();
    string AccountName, Friend;
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        if (!IsPostBack)
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
                    Session["Friend"] = Session["AccountName"];
                    Response.Redirect("friends.aspx");
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
        }
    }

    protected void Friends_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       
        if(e.CommandName == "Visit")
        {
            Session["Friend"] = e.CommandArgument;
            Response.Redirect("home.aspx");
        }
        if(e.CommandName == "ChangeRemark")
        {
            RemarkFriend.Visible = true;
            NewRemark.Visible = true;
            ChangeRemark.Visible = true;
            CancelChangeRemark.Visible = true;
            Session["Remarkid"] = e.CommandArgument.ToString();
        }
        if(e.CommandName == "DeleteFriend")
        {
            string error = usr.deleteFriend(e.CommandArgument.ToString(), AccountName);
            if(error == null)
            {
                Response.Write("<script>alert('删除成功');location = 'friends.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('" + error + "');location = 'friends.aspx'</script>");
            }
        }
    }

    protected void DataBlindToRepeater(int Page)
    {
        DataTable dt = new DataTable();
        dt = usr.getAllFriend(AccountName);
        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;
        pds.PageSize = 3;           //分页设置

        pds.DataSource = dt.DefaultView;  //设置数据源

        IndexNow.Text = Page.ToString();
        IndexAll.Text = pds.PageCount.ToString();


        pds.CurrentPageIndex = Page - 1;
        Friends.DataSource = pds;
        Friends.DataBind();

    }

    protected void ChangeRemark_Click(object sender, EventArgs e)
    {
        if (NewRemark.Text.Length > 50)
        {
            Response.Write("<script>alert('请勿输入过多字符（50个以内）');location = 'friends.aspx'</script>");
        }
        else
        {
            usr.updataFriendImformation(Session["Remarkid"].ToString(), "Remark", NewRemark.Text);
            RemarkFriend.Visible = false;
            NewRemark.Visible = false;
            ChangeRemark.Visible = false;
            CancelChangeRemark.Visible = false;
            Response.Write("<script>alert('修改成功');location = 'friends.aspx'</script>");
        }
    }

    protected void CancelChangeRemark_Click(object sender, EventArgs e)
    {
        RemarkFriend.Visible = false;
        NewRemark.Visible = false;
        ChangeRemark.Visible = false;
        CancelChangeRemark.Visible = false;
    }

    //翻页
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