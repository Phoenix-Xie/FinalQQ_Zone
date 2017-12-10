using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class home : System.Web.UI.Page
{
    string Friend;
    string AccountName;
    Sql sql = new Sql();
    User usr = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        if(!IsPostBack)
        {
            try
            {
                DataBlindToRepeater(1);
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
                if(AccountName != Friend)
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
        AddNewPassage.Visible = false;
        Session["FriendStatu"] = "true";
    }
    protected void CloseSomedivForOwn()
    {
        Session["FriendStatu"] = "false";
    }

    protected void Passage_ItemDataBound(object sender, RepeaterItemEventArgs e)//数据绑定刷新
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater Comment = (Repeater)e.Item.FindControl("Comment");//repeater类型，可作为参数传入函数中分页处理
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            int Passageid = Convert.ToInt32(rowv["id"]);

            DataTable dt = new DataTable();
            dt = usr.getComment(Passageid);

            PagedDataSource pds = new PagedDataSource();

            pds.AllowPaging = false;
            pds.DataSource = dt.DefaultView;
            Comment.DataSource = pds;
            Comment.DataBind();            
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

    protected void Comment_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "CommentUser")
        {
            Session["Friend"] = e.CommandArgument;
            Response.Redirect("home.aspx");
        }
    }
    protected void Passage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Add")
        {
            Session["Pageid"] = e.CommandArgument;
            Response.Redirect("addcomment.aspx");
        }
        if (e.CommandName == "delete")
        {
            string error = usr.deletePassage(Convert.ToInt32(e.CommandArgument));
            if (error == null)
            {
                Response.Write("<script>alert('删除成功');location = 'home.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('" + error + "')</script>");
            }
        }
        if(e.CommandName == "OpenComment")
        {
            ((Repeater)e.Item.FindControl("Comment")).Visible = true;
            ((LinkButton)e.Item.FindControl("CloseComment")).Visible = true;
            ((LinkButton)e.Item.FindControl("OpenComment")).Visible = false;
        }
        if(e.CommandName == "CloseComment")
        {
            ((Repeater)e.Item.FindControl("Comment")).Visible = false;
            ((LinkButton)e.Item.FindControl("CloseComment")).Visible = false;
            ((LinkButton)e.Item.FindControl("OpenComment")).Visible = true;
        }
    }

    /// <summary>
    /// 数据绑定函数封装
    /// </summary>
    string DataBlindToRepeater(int Page)
    {
        DataTable dt = new DataTable();
        dt = usr.getPassageAndTitle(Friend);//获得文章内容表

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;
        pds.PageSize = 3;           //分页设置
                
        pds.DataSource = dt.DefaultView;  //设置数据源

        IndexNow.Text = Page.ToString();
        IndexAll.Text = pds.PageCount.ToString();


        pds.CurrentPageIndex = Page - 1;
        Passage.DataSource = pds;
        Passage.DataBind();
        return null;          
    }

    //翻页操作
    protected void FormerPage_Click(object sender, EventArgs e)
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

    protected void AddNewPassage_Click(object sender, EventArgs e)
    {
        Response.Redirect("addpassage.aspx");
    }

}