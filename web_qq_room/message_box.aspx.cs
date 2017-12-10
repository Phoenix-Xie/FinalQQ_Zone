using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class message_box : System.Web.UI.Page
{
    User usr = new User();
    string AccountName, Friend;
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
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
        Session["FriendStatu"] = "true";
    }
    protected void CloseSomedivForOwn()
    {
    }

    protected void DataBlindToRepeater(int Page)
    {
        DataTable dt = new DataTable();
        dt = usr.getAllMessage(Friend);
        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;
        pds.PageSize = 3;           //分页设置

        pds.DataSource = dt.DefaultView;  //设置数据源

        IndexAll.Text = pds.PageCount.ToString();
        IndexNow.Text = Page.ToString();

        pds.CurrentPageIndex = Page - 1;
        Message.DataSource = pds;
        Message.DataBind();
    }

    //翻页函数，更新页面信息以及向下翻页
    protected void NextPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(IndexNow.Text) == Convert.ToInt32(IndexAll.Text))
        {
            Response.Write("<script>alert('已经到了末页')</script>");
        }
        else
        {
            DataBlindToRepeater(Convert.ToInt32(IndexNow.Text) + 1);
        }
    }

    protected void FormerPage_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(IndexNow.Text) == 1)
        {
            Response.Write("<script>alert('已经到了首页')</script>");
        }
        else
        {
            DataBlindToRepeater(Convert.ToInt32(IndexNow.Text) - 1);
        }
    }

    protected void Message_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "delete")
        {
            string error = usr.deleteMessage(Convert.ToInt32(e.CommandArgument));
            if(error == null)
            {
                Response.Write("<script>alert('删除成功');location = 'message_box.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('" + error + "')</script>");
            }
        }
        if (e.CommandName == "AddComment")
        {
            Session["Messageid"] = e.CommandArgument;
            Response.Redirect("addmessagecomment.aspx");
        }
        if (e.CommandName == "OpenComment")
        {
            ((Repeater)e.Item.FindControl("Return")).Visible = true;
            ((LinkButton)e.Item.FindControl("CloseComment")).Visible = true;
            ((LinkButton)e.Item.FindControl("OpenComment")).Visible = false;
        }
        if (e.CommandName == "CloseComment")
        {
            ((Repeater)e.Item.FindControl("Return")).Visible = false;
            ((LinkButton)e.Item.FindControl("CloseComment")).Visible = false;
            ((LinkButton)e.Item.FindControl("OpenComment")).Visible = true;
        }
    }

    protected void Message_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater Return = (Repeater)e.Item.FindControl("Return");
            DataRowView rowv = (DataRowView)e.Item.DataItem; // 获取上一层repeater的数据
  
            int Messageid = Convert.ToInt32(rowv["id"]);  //绑定评论id

            DataTable dt = new DataTable();
            dt = usr.getAllMessageComment(Messageid);

            PagedDataSource pds = new PagedDataSource();

            pds.AllowPaging = false; //评论下的回复不进行分页
            pds.DataSource = dt.DefaultView;
            Return.DataSource = pds;
            Return.DataBind();
        }
        try
        {
            if (Session["FriendStatu"].ToString() == "true")
            {
                ((LinkButton)e.Item.FindControl("Delete")).Visible = false;  //关闭Delete按钮
            }
        }
        catch
        { }
    }

    protected void AddNewMessage_Click(object sender, EventArgs e)
    {
        Response.Redirect("addmessage.aspx");
    }

    protected void Return_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       
    }



}