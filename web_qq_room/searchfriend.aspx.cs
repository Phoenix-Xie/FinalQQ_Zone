using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class searchfriend : System.Web.UI.Page
{
    string Friend, AccountName, Name;
    User usr = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
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
    

    protected void Search_Click(object sender, EventArgs e)
    {
        if(Imformation.Text.Length > 15)
        {
            Response.Write("<script>alert('请输入小于十五位字符')</script>");
        }
        else
        {
            Name = Imformation.Text.ToString();
            DataBlindToRepeater(1);
        }
    }

    protected void SearchList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "Add")
        {
            int Judge = usr.testFriendRelation(AccountName, e.CommandArgument.ToString());
            if (Judge != 0)
            {
                Response.Write("<script>alert('已经是好友了')</script>");
            }
            else if(usr.testFriendApply(e.CommandArgument.ToString(), AccountName))
            {
                Response.Write("<script>alert('申请已发出')</script>");
            }
            else if(e.CommandArgument.ToString() == AccountName)
            {
                Response.Write("<script>alert('对不起，无法向自己发出申请')</script>");
            }
            else
            {
                string error = usr.addFriendApply(e.CommandArgument.ToString(), AccountName);
                if (error == null)
                {
                    Response.Write("<script>alert('申请成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('" + error + "')</script>");
                }
            }
        }
    }

    protected void DataBlindToRepeater(int page)
    {
        DataTable dt = new DataTable();
        if(SexImformation.Text == "全部")
        {
            dt = usr.getFriendImformation(Imformation.Text, ImformationType.SelectedValue.ToString());
        }
        else
        {
            dt = usr.getFriendImfomationWithSex(Imformation.Text, ImformationType.SelectedValue.ToString(), SexImformation.Text);
        }       
        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;
        pds.PageSize = 3;

        pds.DataSource = dt.DefaultView;

        IndexNow.Text = page.ToString();
        IndexAll.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = page - 1;
        SearchList.DataSource = pds;
        SearchList.DataBind();
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