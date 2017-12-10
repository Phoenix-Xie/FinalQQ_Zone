using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addmessage : System.Web.UI.Page
{
    User usr = new User();
    string AccountName, Friend;
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
    }
    //非本人无法进入
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
                    CloseSomediveForOwn();
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
        }
    }
    protected void CloseSomediveForOwn()
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string MessageText = Context.Request.Form["Message"];
        string error = usr.addNewMessage(Friend, AccountName, MessageText,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        if(error == null)
        {
            Response.Write("<script>alert('添加成功！');location = 'message_box.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('" + error + "');location = 'message_box.aspx'</script>");
        }
    }
}