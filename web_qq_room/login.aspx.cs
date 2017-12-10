using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    User usr = new User();
    Sql sql = new Sql();
    Safe safe = new Safe();
    
    HttpCookie cookie = new HttpCookie("Login");
    HttpCookie cookieAccountName = new HttpCookie("LoginAccountName");
    protected void Page_Load(object sender, EventArgs e)
    {
        string key = safe.MD5Encode(DateTime.Now.ToString("yyyyMMdd")).Substring(0, 8);
        ibtn_yzm.ImageUrl = "ImageCode.aspx";
        try
        {
            string LoginKey = HttpContext.Current.Request.Cookies["Login"].Value;
            string LoginAccountName = HttpContext.Current.Request.Cookies["LoginAccountName"].Value;
            if (safe.DecryptDES(LoginKey, key) == LoginAccountName)
            {
                Session["AccountName"] = LoginAccountName;
                Session["Friend"] = LoginAccountName;
                Session["FriendStatu"] = "false";
                Response.Write("<script>alert('成功登入，欢迎回来！" + LoginAccountName + "先生（女士）');location = 'home.aspx'</script>");
            }
        }
        catch
        {

        }
    }
    protected void Login_button_Click(object sender, EventArgs e)
    {
        try
        {

            if (AccountName.Text == "")
            {
                Response.Write("<script>alert('用户名不能为空')</script>");
            }
            else if (Pwd.Text == "")
            {
                Response.Write("<script>alert('密码不能为空')</script>");
            }
            else
            {
                string code = tbx_yzm.Text;
                HttpCookie htco = Request.Cookies["ImageV"];
                string scode = htco.Value.ToString();
                if (code.ToLower() != scode.ToLower())
                {
                    Response.Write("<script>alert('验证码输入不正确！')</script>");
                }
                else
                {
                    int judgement1 = usr.TestImformation("AccountName", AccountName.Text);
                    int judgement2 = usr.TestPwd(AccountName.Text,safe.MD5Encode(Pwd.Text));
                    if (judgement1 == -1 || judgement2 == -1)
                    {
                        Response.Write("<script>alert('数据库连接失败')</script>");
                    }
                    else if (judgement1 == 0 || judgement2 == 0)
                    {
                        Response.Write("<script>alert('账户或密码错误')</script>");
                    }
                    else
                    {
                        string key = safe.MD5Encode(DateTime.Now.ToString("yyyyMMdd")).Substring(0, 8);
                        if (LoginRemenber.Checked == true)
                        {
                            cookie.Value = safe.EncryptDES(AccountName.Text, key);
                            cookieAccountName.Value = AccountName.Text;
                            HttpContext.Current.Response.Cookies.Add(cookie);
                            HttpContext.Current.Response.Cookies.Add(cookieAccountName);
                            cookie.Expires = DateTime.Now.AddDays(1);
                             cookieAccountName.Expires = DateTime.Now.AddDays(1);
                        }
                        Session["AccountName"] = AccountName.Text.ToString();
                        Session["Friend"] = AccountName.Text.ToString();
                         Response.Write("<script>alert('成功登入，欢迎回来！" + AccountName.Text.ToString() + "先生（女士）');location = 'home.aspx'</script>");
                    }
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('请勿输入非法字符！')</script>");
        }
    }
}