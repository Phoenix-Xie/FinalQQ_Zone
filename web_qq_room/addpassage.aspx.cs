using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addpassage : System.Web.UI.Page
{
    User usr = new User();
    string AccountName, Friend;
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        if (!IsPostBack)
        {          
            Passage.InnerText = "在此处书写美好，记得要加上标题哦";
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
                    CloseSomediv();
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
        string PassageText = Context.Request.Form["Passage"];
        string TitleText = PassageTitle.Text.ToString();
        if(TitleText.Length >= 50)
        {
            Response.Write("<script>alert('标题请少于20个字')</script>");
        }
        else if (TitleText == "")
        {
            Passage.InnerText = PassageText;
            Response.Write("<script>alert('请写入标题')</script>");
        }
        else if(TitleText.Length > 20)
        {
            Response.Write("<script>alert('标题字数不能超过20')</script>");
        }
        else
        {
            usr.AddPassage(AccountName, PassageText, TitleText);
            Response.Write("<script>alert('新增成功');location = 'home.aspx'</script>");
        }
    }
}