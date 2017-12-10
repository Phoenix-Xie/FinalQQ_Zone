using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// sql 的摘要说明 sql的处理，更新，删除，新增的操作类
/// </summary>
public class Sql
{
    Safe safe = new Safe();

    string database_global, table_global;

    /// <summary>
    /// sql的初始化
    /// </summary>
    public Sql(string database_get = "pp_zone", string table_get = "users")
    {
        database_global = database_get;
        table_global = table_get;
    }

    /*sql处理区域*/

    /// <summary>
    ///  (参数化，仅支持nvarchar类型)输入相关的sql语句，对相应数据库进行操作,无错误返回null，错误返回"数据库连接失败"
    /// </summary>
    public string Sql_deal_with(string sqlstring, params string[] items)
    {
        /// 功能介绍
        string database = database_global;
        string str = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        //Integrated Security 综合安全，集成安全
        //try
        //{
            //sqlstring = "select * from users where AccountName = '@here'";


            string ConnectionString = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sqlstring;
            int i;
            for (i = 0; i < items.Length; i += 2)
            {
                cmd.Parameters.Add("@" + items[i], SqlDbType.NVarChar);
                cmd.Parameters["@" + items[i]].Value = items[i + 1];
            }
            cmd.ExecuteNonQuery();
            return null;
        //}
        //catch
        //{
            //return "数据库连接失败";
        //}
    }

    /// <summary>
    /// (参数化，仅支持nvarchar类型)通用sql获得语句，在第一个参数传入sql语句，接下来以此写入在sql中参数化的位置与需要用于替代的字符
    /// </summary>
    /// <param name="sqlstring"></param>
    /// <param name="items"></param>以数组方式传入可同时对sql语句多个位置进行赋值
    /// <returns></returns>
    public DataTable Sql_Get_Datatable(string sqlstring, params string[] items)
    {
        string database = database_global;
        string str = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        //Integrated Security 综合安全，集成安全

        string ConnectionString = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        SqlConnection conn = new SqlConnection(ConnectionString);
        conn.Open();
        SqlCommand cmd = new SqlCommand();     //生成新的连接            
        cmd.Connection = conn;
        cmd.CommandText = sqlstring;

        int i;
        for (i = 0; i < items.Length; i += 2)          //循环替换字符串中相应位置的参数，一个@something 对应一个 somenting
        {
            cmd.Parameters.Add("@"+items[i], SqlDbType.NVarChar);
            cmd.Parameters["@" + items[i]].Value = items[i+1];              
        }         
            
        SqlDataAdapter da = new SqlDataAdapter(cmd); //注意，此处参数应为设置完成的cmd
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        conn.Dispose();
        return dt;     
        
    }

    /// <summary>
    /// (普通类型)通过语句对数据库直接进行操作
    /// </summary>
    /// <param name="sqlstring"></param>
    /// <returns></returns>
    public string SqlDealBasic(string sqlstring)
    {
        string database = database_global;
        string str = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        //Integrated Security 综合安全，集成安全
        string ConnectionString = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        SqlConnection conn = new SqlConnection(ConnectionString);
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = sqlstring;
        cmd.ExecuteNonQuery();
        return null;
    }

    /// <summary>
    /// 非参数化的查询表中内容
    /// </summary>
    /// <param name="sqlstring"></param>
    /// <returns></returns>
    public DataTable SqlGetTableBasic(string sqlstring)
    {
        string database = database_global;
        string str = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        //Integrated Security 综合安全，集成安全

        string ConnectionString = @"server=DESKTOP-8ROVJ5G;Integrated Security=SSPI;database=" + database;
        SqlConnection conn = new SqlConnection(ConnectionString);
        conn.Open();
        SqlCommand cmd = new SqlCommand();     //生成新的连接            
        cmd.Connection = conn;
        cmd.CommandText = sqlstring;
        SqlDataAdapter da = new SqlDataAdapter(cmd); //注意，此处参数应为设置完成的cmd
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        conn.Dispose();
        return dt;
    }
}