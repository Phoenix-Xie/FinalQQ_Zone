using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class albumlist : System.Web.UI.Page
{
    string AccountName, Friend;
    Sql sql = new Sql();
    User usr = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();     
        if (!IsPostBack)
        {
            try
            {
                DataBlindToRepeater();
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
                    CloseSomedivForFriendVisit();
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
    protected void CloseSomedivForFriendVisit()
    {
        Session["FriendStatu"] = "true";
        AddNewAlbumVisible.Visible = false;
    }
    protected void CloseSomedivForOwn()
    {
    }

    public void DataBlindToRepeater()
    {
        DataTable dt = new DataTable();
        dt = usr.getAlubmList(Friend);

        AlbumList.DataSource = dt.DefaultView;
        AlbumList.DataBind();
    }

    protected void Album_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "Visit")
        {
            Session["Albumid"] = e.CommandArgument;
            Response.Redirect("album.aspx");
        }
    }

    protected void Album_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }

    protected void AddNewAlbumVisible_Click(object sender, EventArgs e)
    {
        CreatNewAlbum.Visible = true;
        NewAlbumName.Visible = true;
    }

    protected void CreatNewAlbum_Click(object sender, EventArgs e)
    {
        string error = usr.addAlbum(AccountName, NewAlbumName.Text);
        if(error == null)
        {
            Response.Write("<script>alert('新增成功');location = 'albumlist.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('" + error + "')</script>");
        }
    }
}