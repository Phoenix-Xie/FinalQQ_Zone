using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class self : System.Web.UI.Page
{
    User usr = new User();
    string AccountName,Friend;
    string[] Day = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
    string[] ProvinceItems = {"河北","山西","辽宁","吉林","黑龙江", "江苏","浙江","安徽","福建","江西","山东","河南","湖北","湖南",
"广东","海南","四川", "贵州", "云南", "陕西", "甘肃", "青海","台湾","北京","天津","上海","重庆","广西","内蒙","西藏","宁夏","新疆"};

    protected void Page_Load(object sender, EventArgs e)
    {
        Test_username();
        if (!IsPostBack)
        {
            try
            {
                BornDay.DataSource = Day;
                BornDay.DataBind();
                Province.DataSource = ProvinceItems;
                Province.DataBind();
                string[] Years;
                Years = new string[150];
                int NowYear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                for (int i = 0; i < 150; i++)
                {
                    Years[i] = ((NowYear - 150) + i).ToString();
                }
                BornYear.DataSource = Years;
                BornYear.DataBind();
                BlindImformation(Friend);
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
        ChangeImformation.Visible = false;
        UploadVisible.Visible = false;
        UploadText.Visible = false;
        ChangeQuestionVisible.Visible = false;
        Session["FriendStatu"] = "true";
    }
    protected void CloseSomedivForOwn()
    {
    }

    protected void ChangeImformation_Click(object sender, EventArgs e)
    {
        if (UserNickName.Text.Length > 30)
        {
            Response.Write("<script>alert('昵称不能超过30字符')</script>");
        }
        else if (Profession.Text.Length > 50)
        {
            Response.Write("<script>alert('职业名称不能超过50个字符')</script>");
        }
        else
        {
            usr.updataAccountImformation(AccountName, "UserNickName", UserNickName.Text);
            usr.updataAccountImformation(AccountName, "Sex", Sex.Text);
            usr.updataAccountImformation(AccountName, "BornYear", BornYear.Text);
            usr.updataAccountImformation(AccountName, "BornMonth", BornMonth.Text);
            usr.updataAccountImformation(AccountName, "BornDay", BornDay.Text);
            usr.updataAccountImformation(AccountName, "Profession", Profession.Text);
            if (BornYear.Text != null)
            {
                usr.updataAccountImformation(AccountName, "Age", (Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(BornYear.Text)).ToString());
            }
            Response.Write("<script>alert('修改成功');location = 'self.aspx'</script>");
        }
    }

    protected void BlindImformation(string AccountName)
    {
        DataTable dt = new DataTable();       
        dt = usr.getUserImformation(AccountName);
        AccountNameTextBox.Text = AccountName;
        UserNickName.Text = dt.Rows[0][1].ToString();
        Age.Text = dt.Rows[0][2].ToString();
        Sex.Text = dt.Rows[0][3].ToString();
        BornYear.Text = dt.Rows[0][4].ToString();
        BornMonth.Text = dt.Rows[0][5].ToString();
        BornDay.Text = dt.Rows[0][6].ToString();
        Profession.Text = dt.Rows[0][7].ToString();
        ProfileImage.ImageUrl = dt.Rows[0][8].ToString();
    }

    protected void Upload_Click(object sender, EventArgs e)
    {
        if (ProfileUploadBox.HasFile)
        {
            string upPath = "\\album\\";  //上传文件路径
            int upLength = 10;        //上传文件大小
            string upFileType = "|image/bmp|image/x-png|image/pjpeg|image/gif|image/png|image/jpeg|";

            string fileContentType = ProfileUploadBox.PostedFile.ContentType;    //文件类型

            if (upFileType.IndexOf(fileContentType.ToLower()) > 0)
            {
                string name = ProfileUploadBox.PostedFile.FileName;                  // 客户端文件路径

                FileInfo file = new FileInfo(name);

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff")+"Profile"+ AccountName + file.Extension; // 文件名称，当前时间（yyyyMMddhhmmssfff)加上用户名称
                string webFilePath = Server.MapPath(upPath) + fileName;        // 服务器端文件路径

                string FilePath = upPath + fileName;   //页面中使用的路径

                //删除原有头像
                string DeleteFile = System.Web.HttpContext.Current.Server.MapPath(usr.getUserImformation(AccountName).Rows[0][8].ToString());
                if (System.IO.File.Exists(DeleteFile))
                {
                    System.IO.File.Delete(DeleteFile);
                }
                //更新数据库信息
                usr.updataAccountImformation(AccountName, "ProfileImage", FilePath);


                if (!File.Exists(webFilePath))
                {
                    if ((ProfileUploadBox.FileBytes.Length / (1024 * 1024)) > upLength)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('大小超出 " + upLength + " M的限制，请处理后再上传！');", true);
                        return;
                    }

                    try
                    {
                        ProfileUploadBox.SaveAs(webFilePath);                                // 使用 SaveAs 方法保存文件


                        ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件上传成功');", true);
                        Response.Redirect("self.aspx");
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件上传失败" + ex.Message + "');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件已经存在，请重命名后上传');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件类型不符');", true);
            }
        }
    }

    protected void UploadVisible_Click(object sender, EventArgs e)
    {
        ProfileUploadBox.Visible = true;
        Upload.Visible = true;
        UploadVisible.Visible = false;
        UploadText.Visible = true;
    }

    protected void ChangeQuestion_Click(object sender, EventArgs e)
    {
        if (Answer.Text == "")
        {
            Response.Write("<script>alert('答案不能为空')</script>");
        }
        else if (Answer.Text.Length > 100)
        {
            Response.Write("<script>alert('不能超过100个字符')</script>");
        }
        else
        {
            if (QuestionSelf.Text == "")
            {
                usr.updataAccountImformation(AccountName,"Question", Question.Text);
                usr.updataAccountImformation(AccountName, "Answer", Answer.Text);
                Response.Write("<script>alert('修改成功'); location = 'self.aspx'</script>");
            }
            else
            {
                if(QuestionSelf.Text.Length > 100)
                {
                    Response.Write("<script>alert('不能超过100个字符')</script>");
                }
                else
                {
                    usr.updataAccountImformation(AccountName, "Question", QuestionSelf.Text);
                    usr.updataAccountImformation(AccountName, "Answer", Answer.Text);
                    Response.Write("<script>alert('修改成功'); location = 'self.aspx'</script>");
                }
                
            }
        }
       
    }

    protected void ChangeQuestionVisible_Click(object sender, EventArgs e)
    {
        Question.Visible = true;
        QuestionSelf.Visible = true;
        QuestionText.Visible = true;
        QuestionText2.Visible = true;
        AnswerText.Visible = true;
        Answer.Visible = true;
        ChangeQuestion.Visible = true;
    }
}