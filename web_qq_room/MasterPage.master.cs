using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    string AccountName, Friend;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            AccountName = Session["AccountName"].ToString();
            Friend = Session["Friend"].ToString();
            if(AccountName == Friend)
            {
                ReturnOwnHome.Visible = false;
            }
        }
        catch
        {
            Response.Write("<script>alert('请先登入');location = 'login.aspx'</script>");
        }
    }

    public string Name()
    {
        try
        {
            string Friend = Session["Friend"].ToString();
            return Friend;
        }
        catch
        {
            return "";
        }
    }

    protected void Quit_Click(object sender, EventArgs e)
    {
        Session["AccountName"] = null;
        Session["Friend"] = null;

        HttpCookie cookie = Request.Cookies["Login"];
        HttpCookie cookieAccountName = Request.Cookies["LoginAccountName"];
        if(cookie != null || cookieAccountName != null)
        {
            cookie.Expires = DateTime.Now.AddDays(-2);
            cookieAccountName.Expires = DateTime.Now.AddDays(-2);
            Response.Cookies.Set(cookie);
            Response.Cookies.Set(cookieAccountName);
        }

        Response.Redirect("login.aspx");
    }

    protected void ReturnOwnHome_Click(object sender, EventArgs e)
    {
        Session["FriendStatu"] = "false";
        Session["Friend"] = Session["AccountName"];
        Response.Redirect("home.aspx");
    }
}
