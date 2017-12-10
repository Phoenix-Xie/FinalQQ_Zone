using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

/// <summary>
/// Safe 安全检测加密模块
/// </summary>
public class Safe
{
    public Safe()
    {
        
    }

    /// <summary>
    /// 以MD5格式加密数据（无法反向）
    /// </summary>
    public string MD5Encode(string str)
    {
        byte[] result = Encoding.Default.GetBytes(str);
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] output = md5.ComputeHash(result);
        return BitConverter.ToString(output);
    }

    /// <summary>
    /// 替换可能出现的特殊字符
    /// </summary>
    public string Relace_special_characters(string str)
    {
        //特殊字符对照表
        /*    / 　　' 　 "   　+  　-
            あ　　い 　う　　え　　お
        */
        string new_str;
        Regex quotation = new Regex("[\"\'\']");
        new_str = Regex.Replace(str, @"[']", "い");
        new_str = Regex.Replace(str, "[\"]", "あ");
        new_str = Regex.Replace(str, @"[']", "う");
        new_str = Regex.Replace(str, @"[+]", "え");
        new_str = Regex.Replace(str, @"[-]", "お");
        return new_str;
    }

    /// <summary>
    /// 检测密码强度并返回相关错误信息字符串，需要两次读入密码保证正确性,完全符合返回null
    /// </summary>
    public string Test_pwd_safe(string pwd, string pwd_twice)
    {
        Regex number = new Regex("[0-9]");
        Regex Uppercharacter = new Regex("[A-Z]");
        Regex Lowercharacter = new Regex("[a-z]");
        Regex others = new Regex("[^0-9a-zA-Z]");
        Regex Chinese_character = new Regex("[\u4E00 - \uFA29]");//匹配汉字
        Regex space = new Regex("/s");
        if (pwd.Length > 15)
        {
            return "密码不得超过15位";
        }
        else if (pwd != pwd_twice)
        {
            return "两次密码不相符！！！";
        }
        else if (pwd == "")
        {
            return "密码不能为空";
        }
        else if (pwd.Length < 5)
        {
            return "密码必须五位以上，但不超过15位";
        }
        else if (!(number.IsMatch(pwd) && (Uppercharacter.IsMatch(pwd) || Lowercharacter.IsMatch(pwd))))//如果没有出现字母，数字混合需要更改
        {
            return "密码里必须有数字，字母混合";
        }
        else if (space.IsMatch(pwd))
        {
            return "密码中不允许有空格";
        }
        else if (Chinese_character.IsMatch(pwd))
        {
            return "密码中不允许包含有汉字";
        }
        else
        {
            return null;
        }

    }

    /// <summary>
    /// 检测用户名位数（15以内）及是否为空，返回相关提示信息字符串
    /// </summary>
    public string Test_name_safe(string name)
    {
        if (name.Length > 15)
        {
            return "用户名长度不能超过15位";
        }
        else if (name == "")
        {
            return "用户名不能为空";
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// DES加密，密匙必须八位
    /// </summary>
    /// <param name="pToEncrypt"></param>
    /// <param name="sKey"></param>
    /// <returns></returns>
    public string EncryptDES(string pToEncrypt, string sKey)
    {
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                cs.Close();
            }
            string str = Convert.ToBase64String(ms.ToArray());
            ms.Close();
            return str;
        }
    }
    /// <summary>
    /// DES解密，密匙共8位
    /// </summary>
    /// <param name="pToDecrypt"></param>
    /// <param name="sKey"></param>
    /// <returns></returns>
    public string DecryptDES(string pToDecrypt, string sKey)
    {
        byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                cs.Close();
            }
            string str = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return str;
        }
    }
}