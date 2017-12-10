using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class changepwd : System.Web.UI.Page
{
    User usr = new User();
    Safe safe = new Safe();
    string AccountNameText;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        if (usr.testAnswer(AccountName.Text, Answer.Text))
        {
            Hint.Visible = true;
            Hint2.Visible = true;
            NewPwd.Visible = true;
            NewPwdTwice.Visible = true;
            Change.Visible = true;
        }
        else
        {
            Response.Write("<script>alert('答案错误')</script>");
        }
    }

    protected void QuestionVisible_Click(object sender, EventArgs e)
    {
        AccountNameText = AccountName.Text;
        int judge = usr.TestImformation(AccountNameText, AccountNameText);
        if(judge == -1)
        {
            Response.Write("<script>alert('连接失败')</script>");
        }
        else if(judge == 0)
        {
            Response.Write("<script>alert('不存在该用户')</script>");
        }
        else
        {
            Question.Text = usr.getQuestion(AccountNameText);
        }
    }

    protected void Change_Click(object sender, EventArgs e)
    {
        string error = safe.Test_pwd_safe(NewPwd.Text,NewPwdTwice.Text);
        if(error == null)
        {
            usr.updataAccountImformation(AccountName.Text, "AccountPwd", safe.MD5Encode(NewPwd.Text));
            Response.Write("<script>alert('修改成功');location = 'login.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('" + error + "')</script>");
        }
        
    }
}