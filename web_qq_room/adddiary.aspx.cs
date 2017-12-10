using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adddiary : System.Web.UI.Page
{
    string AccountName, Friend;
    User usr = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
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
                    Response.Write("<script>alert('非本人无法添加');location = 'login.aspx'</script>");
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
        string DiaryText = Context.Request.Form["Diary"];
        if (DiaryTitle.Text == "")
        {
            Response.Write("<script>alert('请写上标题')</script>");
        }
        else if (DiaryTitle.Text.Length > 20)
        {
            Response.Write("<script>alert('字数不能超过20')</script>");
        }
        else
        {
            string error = usr.addDiary(AccountName, DiaryTitle.Text, DiaryText, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (error == null)
            {
                Response.Write("<script>alert('添加成功');location = 'diary.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('" + error + "');location = 'login.aspx'</script>");
            }
        }
    }
}