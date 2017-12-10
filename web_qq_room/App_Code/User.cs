using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// 各类对用户的操作，包括各个页面对用户信息的引用修改或添加
/// </summary>
public class User
{
    Safe safe = new Safe();
    Sql sql = new Sql();

    string database_global, table_global;

    /// <summary>
    /// User的初始化
    /// </summary>
    public User(string database_get = "pp_zone", string table_get = "users")
    {
        database_global = database_get;
        table_global = table_get;
    }

    /// <summary>
    /// 新增用户并填入必要信息
    /// </summary>
    /// <param name="AccountName"></param>
    /// <param name="AccountPwd"></param>
    /// <param name="UserNickName"></param>
    /// <param name="Question"></param>
    /// <param name="Answer"></param>
    /// <param name="database"></param>
    /// <returns></returns>
    public string addNewAccount(string AccountName, string AccountPwd, string UserNickName, string Question, string Answer, string database = "pp_zone")
    {
        string sqlstr = "insert into users values (@AccountName,@AccountPwd,@UserNickName,@Question,@Answer,'','','','','')";
        string error = sql.Sql_deal_with(sqlstr, "AccountName", AccountName, "AccountPwd", safe.MD5Encode(AccountPwd), "UserNickName", UserNickName, "Question", Question, "Answer", Answer);
        return error;
    }
    
    //self
    /// <summary>
    /// 返回用户个人信息，包括（按序）0账户，1昵称，2年龄，3性别,4出生年，5出生月，6出生日，7职业，8头像路径
    /// </summary>
    /// <param name="AccountName"></param>
    /// <returns></returns>
    public DataTable getUserImformation(string AccountName)
    {
        string sqlstr = "select AccountName,UserNickName,Age,Sex,BornYear,BornMonth,BornDay,Profession,ProfileImage from users where AccountName = @AccountName";
        return sql.Sql_Get_Datatable(sqlstr, "AccountName", AccountName);
    }
    /// <summary>
    /// 更新某个账户中的某条信息
    /// </summary>
    /// <param name="AccountName"></param>
    /// <param name="Location"></param>
    /// <param name="Imformation"></param>
    /// <param name="database"></param>
    /// <returns></returns>
    ///
    public string updataAccountImformation(string AccountName, string Location, string Imformation)
    {
        string sqlstr = "update users set " + Location + " = @Imformation where AccountName = @AccountName";
        string error = sql.Sql_deal_with(sqlstr, "Imformation", Imformation, "AccountName", AccountName);
        return error;
    }


    //passage
    /// <summary>
    /// 获得相关动态文章内容，标题，作者和id
    /// </summary>
    /// <param name="AccountName"></param>
    /// <param name="database"></param>
    /// <returns></returns>
    public DataTable getPassageAndTitle(string AccountName, string database = "pp_zone")
    {
        string sqlstr = "select * from passages where AccountName = @AccountName order by Time desc";
        DataTable dt = sql.Sql_Get_Datatable(sqlstr, "AccountName", AccountName);
        return dt;
    }
    /// <summary>
    /// 获得相关文章的评论
    /// </summary>
    /// <param name="Pageid"></param>
    /// <param name="database"></param>
    /// <returns></returns>
    public DataTable getComment(int Pageid, string database = "pp_zone")
    {
        string sqlstr = "select Comment,CommentUser,Time,Remark,Pageid,UserNickName from comments,friends,users where Pageid = " + Pageid + " and CommentUser = Friend and CommentUser=users.AccountName order by Time desc";
        return sql.SqlGetTableBasic(sqlstr);
    }
    /// <summary>
    /// 删除文章
    /// </summary>
    /// <param name="Pageid"></param>
    /// <returns></returns>
    public string deletePassage(int Pageid)
    {
        string sqlstr = "delete from passages where id = " + Pageid;
        return sql.SqlDealBasic(sqlstr);
    }   
    /// <summary>
    /// 新增评论
    /// </summary>
    /// <param name="Pageid"></param>
    /// <param name="Comment"></param>
    /// <param name="CommentUser"></param>
    /// <param name="database"></param>
    /// <returns></returns>
    public string addNewComment(int Pageid, string Comment, string CommentUser, string database = "pp_zone")
    {
        /// 功能介绍
        string str = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        //Integrated Security 综合安全，集成安全
        //try
        //{
        //sqlstring = "select * from users where AccountName = '@here'";

        string sqlstring = "insert into comments (Comment,CommentUser,Pageid,Time) values (@Comment,@CommentUser,@Pageid,'"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
        string ConnectionString = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        SqlConnection conn = new SqlConnection(ConnectionString);
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = sqlstring;

        cmd.Parameters.Add("@Comment", SqlDbType.NVarChar);
        cmd.Parameters["@Comment"].Value = Comment;
        cmd.Parameters.Add("@CommentUser", SqlDbType.NVarChar);
        cmd.Parameters["@CommentUser"].Value = CommentUser;
        cmd.Parameters.Add("@Pageid", SqlDbType.NVarChar);
        cmd.Parameters["@Pageid"].Value = Pageid;

        cmd.ExecuteNonQuery();
        return null;
        //}
        //catch
        //{
        //return "数据库连接失败";
        //}
    }
    public string AddPassage(string AccountName, string Passage, string Title)
    {
        string sqlstr = "insert into passages (AccountName,Passage,Title,Time) values (@AccountName,@Passage,@Title,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
        string error = sql.Sql_deal_with(sqlstr, "AccountName", AccountName, "Passage", Passage, "Title", Title);
        return error;
    }

   
    //login
    /// <summary>
    /// 查询相关用户信息是否存在，返回0为不存在，返回1为存在，返回-1为数据连接出现故障
    /// </summary>
    public int TestImformation(string imformationType, string AccountName)
    {
        string sqlstr = "select @imformationType from users where AccountName = @imformation";
        DataTable dt = sql.Sql_Get_Datatable(sqlstr, "imformationType", imformationType, "imformation", AccountName);
        if (dt == null)
        {
            return -1;
        }
        else if (dt.Rows.Count == 0)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    /// <summary>
    /// 检测密码正确性，若密码正确则返回1，若错误返回0，若未知返回-1
    /// </summary>
    public int TestPwd(string AccountName, string AccountPwd)
    {
        string sqlstr = "select AccountName from users where AccountName = @AccountName and AccountPwd = @AccountPwd";
        DataTable dt = sql.Sql_Get_Datatable(sqlstr, "AccountName", AccountName, "AccountPwd", AccountPwd);
        if (dt == null)
        {
            return -1;
        }
        else if (dt.Rows.Count == 0)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    


    //message_box
    /// <summary>
    /// 新增评论
    /// </summary>
    /// <param name="AccountName"></param>
    /// <param name="MessageUser"></param>
    /// <param name="Message"></param>
    /// <returns></returns>
    public string addNewMessage(string AccountName, string MessageUser, string Message, string Time)
    {
        string sqlstr = "insert into message (AccountName,MessageUser,Message,Time) values (N'" + AccountName + "',N'" + MessageUser + "',@Message,'" + Time + "')";
        return sql.Sql_deal_with(sqlstr, "Message", Message);
    }
    /// <summary>
    /// 获得该账户所有留言（包括用户名，评论，评论者及其id）
    /// </summary>
    /// <param name="AccountName"></param>
    /// <returns></returns>
    public DataTable getAllMessage(string AccountName)
    {
        string sqlstr = "select * from message where AccountName = @AccountName order by Time desc";
        return sql.Sql_Get_Datatable(sqlstr, "AccountName", AccountName);
    }
    /// <summary>
    /// 删除相应id的留言
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string deleteMessage(int id)
    {
        string sqlstr = "delete from message where id = " + id + "";
        return sql.SqlDealBasic(sqlstr);
    }
    /// <summary>
    /// 根据id获取相关的留言评论
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public DataTable getAllMessageComment(int id)
    {
        string sqlstr = "select * from messagecomment where Messageid =" + id.ToString()+" order by Time desc";
        return sql.SqlGetTableBasic(sqlstr);
    }
    /// <summary>
    /// 新增留言的评论
    /// </summary>
    /// <param name="MessageCommentUser"></param>
    /// <param name="MessageComment"></param>
    /// <returns></returns>
    public string addNewMessageComment(string MessageCommentUser,string MessageComment,string Messageid,string Time)
    {
        string sqlstr = "insert into messagecomment (MessageCommentUser,MessageComment,Messageid,Time) values (@MessageCommentUser,@MessageComment," + Messageid + ",@Time)";
        return sql.Sql_deal_with(sqlstr, "MessageCommentUser", MessageCommentUser, "MessageComment", MessageComment, "Time", Time);
    }


    /*friend*/
    /// <summary>
    /// 获取带有性别区分的账户信息（账户与昵称）
    /// </summary>
    /// <param name="Imformation"></param>
    /// <param name="Imformationtype"></param>
    /// <param name="Sex"></param>
    /// <returns></returns>
    public DataTable getFriendImfomationWithSex(string Imformation, string Imformationtype, string Sex)
    {
        string sqlstr = "select AccountName,UserNickName,Sex from users where " + Imformationtype + " like @Imformation and Sex = N'" + Sex + "'";
        return sql.Sql_Get_Datatable(sqlstr, "Imformationtype", Imformationtype, "Imformation", "%" + Imformation + "%");
    }
    /// <summary>
    /// 获取带无性别区分的账户信息（账户与昵称）
    /// </summary>
    /// <param name="Imformation"></param>
    /// <param name="Imformationtype"></param>
    /// <returns></returns>
    public DataTable getFriendImformation(string Imformation, string Imformationtype)
    {
        string sqlstr = "select AccountName,UserNickName,Sex from users where " + Imformationtype + " like @Imformation";
        return sql.Sql_Get_Datatable(sqlstr,"Imformationtype",Imformationtype,"Imformation", "%" + Imformation + "%");
    }
    /// <summary>
    /// 添加好友申请，其中AccountName为收到申请者，ApplyFriend为申请者
    /// </summary>
    /// <param name="AccountName"></param>
    /// <param name="ApplyFriend"></param>
    /// <returns></returns>
    public string addFriendApply(string AccountName, string ApplyFriend)
    {
        string sqlstr = "insert into applyfriends (AccountName,ApplyFriend) values (@AccountName,@ApplyFriend)";
        return sql.Sql_deal_with(sqlstr, "AccountName", AccountName, "ApplyFriend", ApplyFriend);
    }
    /// <summary>
    /// 获得所有提交申请的人列表
    /// </summary>
    /// <param name="AccountName"></param>
    /// <returns></returns>
    public DataTable getApplyFriend(string AccountName)
    {
        string sqlstr = "select * from applyfriends where AccountName = @AccountName";
        return sql.Sql_Get_Datatable(sqlstr, "AccountName", AccountName);
    }
    /// <summary>
    /// 删除相应id的申请
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string deleteApplyFriend(int id)
    {
        string sqlstr = "delete from applyfriends where id = " + id;
        return sql.SqlDealBasic(sqlstr);
    }
    /// <summary>
    /// 为两个人之间添加关系（包括你与我，我与你两条信息）
    /// </summary>
    /// <param name="AccountName1"></param>
    /// <param name="AccountName2"></param>
    /// <returns></returns>
    public string addFriend(string AccountName1, string AccountName2)
    {
        string sqlstr = "insert into friends (AccountName,Friend) values (@AccountName,@Friend)";
        string error1 = sql.Sql_deal_with(sqlstr, "AccountName", AccountName1, "Friend", AccountName2);
        string error2 = sql.Sql_deal_with(sqlstr, "AccountName", AccountName2, "Friend", AccountName1);
        if (error1 != null)
        {
            return error1;
        }
        else if (error2 != null)
        {
            return error2;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 修改friend表中数据
    /// </summary>
    /// <param name="AccountName"></param>
    /// <param name="Location"></param>
    /// <param name="Imformation"></param>
    /// <returns></returns>
    public string updataFriendImformation(string id, string Location, string Imformation)
    {
        string sqlstr = "update friends set " + Location + " = @Imformation where id = " + id;
        string error = sql.Sql_deal_with(sqlstr, "Imformation", Imformation);
        return error;
    }
    /// <summary>
    /// 获取所有朋友0账户名,1备注,2id,3头像路径，4昵称的表
    /// </summary>
    /// <param name="AccountName"></param>
    /// <returns></returns>
    public DataTable getAllFriend(string AccountName)
    {
        string sqlstr = "select Friend,Remark,id,ProfileImage,UserNickName from friends,users where friends.AccountName = @AccountName and friends.Friend = users.AccountName";
        return sql.Sql_Get_Datatable(sqlstr, "AccountName", AccountName);
    }
    /// <summary>
    /// 删除与某好友的关系
    /// </summary>
    /// <param name="AccountName1"></param>
    /// <param name="AccountName2"></param>
    /// <returns></returns>
    public string deleteFriend(string AccountName1, string AccountName2)
    {
        string sqlstr = "delete from friends where AccountName = @AccountName1 and Friend = @AccountName2";
        string error1 = sql.Sql_deal_with(sqlstr, "AccountName1", AccountName1, "AccountName2", AccountName2);
        string error2 = sql.Sql_deal_with(sqlstr, "AccountName1", AccountName2, "AccountName2", AccountName1);
        if(error1 != null)
        {
            return error1;
        }
        else if(error2 != null)
        {
            return error2;
        }
        else
        {
            return null;
        }
    }
    /// <summary>
    /// 返回如果不为零则存在朋友关系
    /// </summary>
    /// <param name="AccountName"></param>
    /// <param name="Friend"></param>
    /// <returns></returns>
    public int testFriendRelation(string AccountName,string Friend)
    {
        string sqlstr = "select * from friends where AccountName=@AccountName and Friend =@Friend";
        return sql.Sql_Get_Datatable(sqlstr, "AccountName", AccountName, "Friend", Friend).Rows.Count;
    }
    /// <summary>
    /// 检测是否已经申请过（AccountName参数为收到申请的人，ApplyFriend为发出申请的人）是返回真
    /// </summary>
    /// <param name="AccountName"></param>
    /// <param name="ApplyFriend"></param>
    /// <returns></returns>
    public bool testFriendApply(string AccountName,string ApplyFriend)
    {
        string sqlstr = "select * from applyfriends where AccountName=@AccountName and ApplyFriend=@ApplyFriend";
        int Result = sql.Sql_Get_Datatable(sqlstr, "AccountName", AccountName, "ApplyFriend", ApplyFriend).Rows.Count;
        if(Result == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }



    //diary
    /// <summary>
    /// 新增日志
    /// </summary>
    /// <param name="AccountName"></param>
    /// <param name="DiaryTitle"></param>
    /// <param name="Diary"></param>
    /// <returns></returns>
    public string addDiary(string AccountName, string DiaryTitle, string Diary,string Time)
    {
        string sqlstr = "insert into diary (AccountName,DiaryTitle,Diary,Time) values (@AccountName,@DiaryTitle,@Diary,@Time)";
        return sql.Sql_deal_with(sqlstr, "AccountName", AccountName, "DiaryTitle", DiaryTitle, "Diary", Diary, "Time", Time);
    }
    /// <summary>
    /// 删除相应id的日志
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string deleteDiary( int id)
    {
        string sqlstr = "delete from diary where id = " + id;
        return sql.SqlDealBasic(sqlstr);
    }
    /// <summary>
    /// 获得某一用户所有日志名称
    /// </summary>
    /// <param name="AccountName"></param>
    /// <returns></returns>
    public DataTable getDiaryTitle(string AccountName)
    {
        string sqlstr = "select DiaryTitle,id,Time from diary where AccountName = @AccountName order by Time desc";
        DataTable dt = sql.Sql_Get_Datatable(sqlstr, "AccountName", AccountName);
        return dt;
    }
    /// <summary>
    /// 获取相应日志名称与内容
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public DataTable getDiary(int id)
    {
        string sqlstr = "select DiaryTitle,Diary,Time from diary where id =" + id;
        return sql.SqlGetTableBasic(sqlstr);
    }
    /// <summary>
    /// 获取id为Diaryid 的日志的评论（包括0评论，1评论者，2时间，3评论者昵称，4备注）
    /// </summary>
    /// <param name="Diaryid"></param>
    /// <returns></returns>
    public DataTable getDiaryComment(int Diaryid)
    {
        string sqlstr = "select Comment,CommentUser,Time,UserNickName,Remark from diarycomment,users,friends where Diaryid  = " + Diaryid + " and CommentUser = Friend and CommentUser = users.AccountName order by Time desc";
        return sql.SqlGetTableBasic(sqlstr);
    }
    /// <summary>
    /// 新增日志下评论
    /// </summary>
    /// <param name="CommentUser"></param>
    /// <param name="Comment"></param>
    /// <param name="Time"></param>
    /// <param name="Diaryid"></param>
    /// <returns></returns>
    public string addDiaryComment(string CommentUser, string Comment, string Time, string Diaryid)
    {
        string sqlstr = "insert into diarycomment (Diaryid,Comment,CommentUser,Time) values (" + Diaryid + ",@Comment,@CommentUser,'" + Time + "')";
        return sql.Sql_deal_with(sqlstr, "Comment", Comment, "CommentUser", CommentUser);
    }
  
    //ChangePwd
    /// <summary>
    /// 获取用户密保问题
    /// </summary>
    /// <param name="AccountName"></param>
    /// <returns></returns>
    public string getQuestion(string AccountName)
    {
        string sqlstr = "select Question from users where AccountName = @AccountName";
        return sql.Sql_Get_Datatable(sqlstr, "AccountName", AccountName).Rows[0][0].ToString();
    }
    /// <summary>
    /// 检测该用户名下的答案与输入答案是否一致
    /// </summary>
    /// <param name="AccountName"></param>
    /// <param name="Answer"></param>
    /// <returns></returns>
    public bool testAnswer(string AccountName, string Answer)
    {
        string sqlstr = "select Answer from users where AccountName = @AccountName";
        string RealAnswer = sql.Sql_Get_Datatable(sqlstr, "AccountName", AccountName).Rows[0][0].ToString();
        if (Answer == RealAnswer)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    //albumlist
    /// <summary>
    /// 获得该账户下的所有相册的 0id， 1AccountName， 2AlbumName， 3封面路径(按相册名排序)
    /// </summary>
    /// <param name="AccountName"></param>
    /// <returns></returns>
    public DataTable getAlubmList(string AccountName)
    {
        string sqlstr = "select * from albumlist where AccountName = @AccountName  order by AlbumName ";
        return sql.Sql_Get_Datatable(sqlstr, "AccountName", AccountName);
    }
    /// <summary>
    /// 新增相册
    /// </summary>
    /// <param name="AccountName"></param>
    /// <param name="AlbumName"></param>
    /// <returns></returns>
    public string addAlbum(string AccountName, string AlbumName)
    {
        string sqlstr = "insert into albumlist values (@AccountName,@AlbumName,'album/Cover.jpg')";
        return sql.Sql_deal_with(sqlstr, "AccountName", AccountName, "AlbumName", AlbumName);
    }
    /// <summary>
    /// 更新相册封面
    /// </summary>
    /// <param name="Albumid"></param>
    /// <param name="NewCoverPath"></param>
    /// <returns></returns>
    public string updataAlbumCover(string Albumid, string Imageid)
    {
        try
        {
            string sqlstr1 = "select ImagePath from album where id = " + Imageid;
            string sqlstr2 = "select CoverPath from albumlist where id = " + Albumid;
            string ImagePath = sql.SqlGetTableBasic(sqlstr1).Rows[0][0].ToString();
            string OldImagePath = sql.SqlGetTableBasic(sqlstr2).Rows[0][0].ToString();

            string sqlstr = "select IsCoverOrNot,id from album where ImagePath = '" + OldImagePath+"'";
            DataTable dt = sql.SqlGetTableBasic(sqlstr);
            if (dt.Rows.Count != 0)
            {
                sqlstr = "update album set IsCoverOrNot = null where ImagePath = '" + dt.Rows[0][1].ToString() + "'";
                sql.SqlDealBasic(sqlstr);
            }

            sqlstr = "update albumlist set CoverPath = @NewCoverPath where id = " + Albumid;
            sql.Sql_deal_with(sqlstr, "NewCoverPath", ImagePath);
            sqlstr = "update album set IsCoverOrNot = 1 where id" + Albumid;
            sql.SqlDealBasic(sqlstr);
            return null;
    }
        catch
        {
            return "更新失败";
        }
    }

    //album
    /// <summary>
    /// 新增相册图片
    /// </summary>
    /// <param name="AccountName"></param>
    /// <param name="ImagePath"></param>
    /// <param name="ImageName"></param>
    /// <param name="Time"></param>
    /// <returns></returns>
    public string addImage(string ImagePath, string ImageName, string Time,string Albumid)
    {
        string sqlstr = "insert into album (ImagePath,ImageName,Time,Albumid) values (@ImagePath,@ImageName,@Time," + Albumid + ")";
        return sql.Sql_deal_with(sqlstr,"ImagePath", ImagePath, "ImageName", ImageName, "Time", Time);
    }
    /// <summary>
    /// 获取某个账户下所有图片的信息（包括0id,1AccountName,2ImagePath,3ImageName,4Time)
    /// </summary>
    /// <param name="AccountName"></param>
    /// <returns></returns>
    public DataTable getImage(string Albumid)
    {
        string sqlstr = "select * from album where Albumid = " + Albumid + " order by Time desc";
        return sql.SqlGetTableBasic(sqlstr);
    }
    /// <summary>
    /// 删除id为id 的图片
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string deleteImage(string id)
    {
        try
        {
            string error1 = null, error2;
            string sqlstr = "select IsCoverOrNot from album where id = " + id;
            string mark = sql.SqlGetTableBasic(sqlstr).Rows[0][0].ToString();
            if (mark != null)
            {
                sqlstr = "select Albumid from album where id = " + id;
                string Albumid = sql.SqlGetTableBasic(sqlstr).Rows[0][0].ToString();
                sqlstr = "update albumlist set CoverPath = '/album/Cover.jpg' where id = " + Albumid;
                error1 = sql.Sql_deal_with(sqlstr);
            }
            sqlstr = "delete from album where id = " + id;
            error2 = sql.SqlDealBasic(sqlstr);
            if (error1 != null)
            {
                return error1;
            }
            else if (error2 != null)
            {
                return error2;
            }
            else
            {
                return null;
            }
        }
        catch
        {
            return "连接失败";
        }
    }
}
