using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;



namespace AppCash
{
    public class CommonUtility
    {
        /// <summary>
        /// 键盘只允许输入数字
        /// </summary>
        /// <param name="e"></param>
        public static void ValidateNumber(KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')  //只允许输入数字，-，退格键
            {
                e.Handled = false;
            }
        }


        /// <summary>
        /// 键盘只允许输入数字（还有'-'）
        /// </summary>
        /// <param name="e"></param>
        public static void ValidateTel(KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == '\b')  //只允许输入数字，-，退格键
            {
                e.Handled = false;
            }

        }

        /// <summary>
        /// 验证是否所有TextBox都不为空,若都不为空,
        /// </summary>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static bool ValidateTexbBoxesEmpty(Control.ControlCollection cls)
        {
            foreach (Control c in cls)
            {
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    if (tb.Text == "")
                    {
                        return false;
                    }
                }

            }

            return true;
        }



        /// <summary>
        /// 设置所有TextBox为ReadOnly=true
        /// </summary>
        /// <param name="cls"></param>
        public static void SetAllTextBoxReadOnly(Control.ControlCollection cls)
        {
            foreach (Control c in cls)
            {
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    tb.ReadOnly = true;
                }

            }

        }


        public static string ChangeTimeToStr(DateTime time)
        {
            return time.ToString("yyyyMMddhhmmss");
        }


        /// <summary>  
        /// 获取url的返回值  
        /// </summary>  
        /// <param name="url">eg:http://m.weather.com.cn/atad/101010100.html </param>  
        public static string GetInfo(string url)
        {
            string strBuff = "";
            Uri httpURL = new Uri(url);
            ///HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换   
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
            ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换   
            HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
            ///GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容   
            ///若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理   
            Stream respStream = httpResp.GetResponseStream();
            ///返回的内容是Stream形式的，所以可以利用StreamReader类获取GetResponseStream的内容，并以   
            //StreamReader类的Read方法依次读取网页源程序代码每一行的内容，直至行尾（读取的编码格式：UTF8）   
            StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
            strBuff = respStreamReader.ReadToEnd();
            return strBuff;
        }

        /// <summary>
        /// 获取随机码
        /// </summary>
        /// <param name="length">长度</param>
        /// <param name="availableChars">指定随机字符，为空，默认系统指定</param>
        /// <returns></returns>
        public static string GetRandomString(int length, string availableChars = null)
        {
            if (availableChars == null) availableChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";


            var id = new char[length];
            Random random = new Random();
            for (var i = 0; i < length; i++)
            {
                id[i] = availableChars[random.Next(0, availableChars.Length)];
            }

            return new string(id);
        }

        //该方法有bug，待修改20170413echo
        public static void ReadStream(string filePath)
        {
            byte[] byData = new byte[100];
            char[] charData = new char[1000];
            try
            {
                FileStream file = new FileStream(filePath, FileMode.Open);
                file.Seek(0, SeekOrigin.Begin);
                file.Read(byData, 0, 100); //byData传进来的字节数组,用以接受FileStream对象中的数据,第2个参数是字节数组中开始写入数据的位置,它通常是0,表示从数组的开端文件中向数组写数据,最后一个参数规定从文件读多少字符.
                Decoder d = Encoding.Default.GetDecoder();
                d.GetChars(byData, 0, byData.Length, charData, 0);
                Console.WriteLine(charData);
                file.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static string ReadReader(string filePath)
        {
            String result = "";
            if (File.Exists(filePath)) { 
            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line.ToString());
                result = result+line;
            }
            sr.Close();
            }
            
            return result;
        }

        public static void WriteStream(string filePath,string content)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(content);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }

        public static void WriteWriter(string filePath, string content)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(content);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }


        /// <summary>  
        /// 生成公钥、私钥  
        /// </summary>  
        /// <returns>公钥、私钥，公钥键"PUBLIC",私钥键"PRIVATE"</returns>  
        public static Dictionary<string, string> createKeyPair()
        {
            Dictionary<string, string> keyPair = new Dictionary<string, string>();
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider(1024);
            string publickey = provider.ToXmlString(false);
            //publickey:<RSAKeyValue><Modulus>w9u2HfdbNZrmAUmXPbNmrhfy861qX4mzcCn69Ksl03Nz+Fq9gINZeN/vrfcWBzMyYxb2/J2TnGtpCLc0ls6gOTKDPbnQHwHr3oCzfvxNwvT2uoKQUBl4xMFw0TmvufMbheq6q3FCXUkVkAUC1cbQ/S9DqNp/veYcAavRDXtFdD0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>
            string privatekey = provider.ToXmlString(true);
            //privatekey:<RSAKeyValue><Modulus>w9u2HfdbNZrmAUmXPbNmrhfy861qX4mzcCn69Ksl03Nz+Fq9gINZeN/vrfcWBzMyYxb2/J2TnGtpCLc0ls6gOTKDPbnQHwHr3oCzfvxNwvT2uoKQUBl4xMFw0TmvufMbheq6q3FCXUkVkAUC1cbQ/S9DqNp/veYcAavRDXtFdD0=</Modulus><Exponent>AQAB</Exponent><P>6tzaLZmY+hLLAifunWwcdUSfqTUvKOO5bJ8M1Zt34en40tfBaH9zml9gP8cmXaWyfpiZgHlPS9xlkLngudAiJw==</P><Q>1Xw2E1ufXsCM2JZahB6PH9pCgfD4XPjrqxF9xOWVvfbPmVBZByBIHYRs8ifbjIPvSKuaCfVFVStoIcOYrT9I+w==</Q><DP>mS4iPsuHMtM/BND2mEYC6ZkwaTP+5jRgo6+4tzkHH5lyaFHAG1/FDlJWfEJvi3SezmLI+zojtd6xf4s8PvS40Q==</DP><DQ>I91kMEhaM87hWpmXx05i+RTvy2iyMNxYqzqbCHMRfwJxye3npvzTYLIYo23ywl5/2pOJo1ajOTW7nsB/a8uP9Q==</DQ><InverseQ>EtYQvvBViXf7A5bgh+H4xLlBezD0yziBigoP/xcg1mcuI9Kb9rtPq64hQsajDYeNmm0Ibkxz9ihHr8+uWtdi5w==</InverseQ><D>HSivw2RZKvDlv1lSb/gumEqufALcbF7W3SMS3qxAVGvC3z27Ks/jWTCVwWOg3u+LV99KZC+dk1MWbxq/dJhMmBSiHOT6Sg7wvNMmX58zHl7Bhs702henzbr7CkiWrUcy3pVigr4olT9FlkjQkeEu9VfVW4TRGUDUkixTeh9MMC0=</D></RSAKeyValue>
            keyPair.Add("PUBLIC", publickey);
            keyPair.Add("PRIVATE", privatekey);
            return keyPair;
        }


        public static string TestDecry(string pwd,string privateKey)
        {
            //java端的密文
            if (string.IsNullOrEmpty(pwd)) { 
            pwd = "Uye5dkFjGRU3R4mc/eIzVSp3YyNnCz7ZfgJNzJ5sDKtubQzXMi9frP1IQ/eFapDvj3lrURtphBF//+zjjhHreKe9EfGXAFygAHZMxtc7GWxbz4rOQcFLenmK44kQy/DwdRCw4IajNVZeus70eFBYvj7VtqufltzFF0ZZeoItdyI=";
            }
            //服务端私钥 由 createKeyPair 创建PRIVATE，
            if (string.IsNullOrEmpty(privateKey)) { 
             privateKey = "<RSAKeyValue><Modulus>w9u2HfdbNZrmAUmXPbNmrhfy861qX4mzcCn69Ksl03Nz+Fq9gINZeN/vrfcWBzMyYxb2/J2TnGtpCLc0ls6gOTKDPbnQHwHr3oCzfvxNwvT2uoKQUBl4xMFw0TmvufMbheq6q3FCXUkVkAUC1cbQ/S9DqNp/veYcAavRDXtFdD0=</Modulus><Exponent>AQAB</Exponent><P>6tzaLZmY+hLLAifunWwcdUSfqTUvKOO5bJ8M1Zt34en40tfBaH9zml9gP8cmXaWyfpiZgHlPS9xlkLngudAiJw==</P><Q>1Xw2E1ufXsCM2JZahB6PH9pCgfD4XPjrqxF9xOWVvfbPmVBZByBIHYRs8ifbjIPvSKuaCfVFVStoIcOYrT9I+w==</Q><DP>mS4iPsuHMtM/BND2mEYC6ZkwaTP+5jRgo6+4tzkHH5lyaFHAG1/FDlJWfEJvi3SezmLI+zojtd6xf4s8PvS40Q==</DP><DQ>I91kMEhaM87hWpmXx05i+RTvy2iyMNxYqzqbCHMRfwJxye3npvzTYLIYo23ywl5/2pOJo1ajOTW7nsB/a8uP9Q==</DQ><InverseQ>EtYQvvBViXf7A5bgh+H4xLlBezD0yziBigoP/xcg1mcuI9Kb9rtPq64hQsajDYeNmm0Ibkxz9ihHr8+uWtdi5w==</InverseQ><D>HSivw2RZKvDlv1lSb/gumEqufALcbF7W3SMS3qxAVGvC3z27Ks/jWTCVwWOg3u+LV99KZC+dk1MWbxq/dJhMmBSiHOT6Sg7wvNMmX58zHl7Bhs702henzbr7CkiWrUcy3pVigr4olT9FlkjQkeEu9VfVW4TRGUDUkixTeh9MMC0=</D></RSAKeyValue>";
            }
            string ms = decrypt(pwd, privateKey);
            return ms;


        }


        //
        public static string TestReg()
        {
            Dong.BLL.Dictionary bAccountNo = new Dong.BLL.Dictionary();
            Dong.Model.Dictionary mAccountNo = new Dong.Model.Dictionary();
            //序列号
            string strSql_AccountNo = "KeyStr = 'AccountNo'";
            String AccountNo = "";
            List<Dong.Model.Dictionary> AccountNoList = bAccountNo.GetModelList(strSql_AccountNo);
            if (AccountNoList.Count != 0)
            {
                mAccountNo = AccountNoList[0];
                if (!string.IsNullOrEmpty(mAccountNo.ValueStr))
                {
                    AccountNo = mAccountNo.ValueStr;
                }
            }
            //获取授权密文s
            string key = CommonUtility.ReadReader("hlx.dll");

            string jiqima = "cpuid:" + Computer.Instance().CpuID + "|diskId:" + Computer.Instance().DiskID + "|macAddress:" + Computer.Instance().MacAddress  ;
            string info = CommonUtility.TestDecry(key, null);
            //如果授权密文为空或者序列号为空或授权验证失败 ，说明该产品为试用版
            if (string.IsNullOrEmpty(key) || !info.Equals(jiqima) || string.IsNullOrEmpty(AccountNo))
            {
                return "0";
            }
            else
            {
                return "1";
            }


        }

        private static int MAXENCRYPTSIZE = 117;
        private static int MAXDECRYPTSIZE = 128;
        /// <summary>  
        /// RSA解密  
        /// </summary>  
        /// <param name="encryptData">经过Base64编码的密文</param>  
        /// <param name="privateKey">私钥</param>  
        /// <returns>RSA解密后的数据</returns>  
        public static string decrypt(string encryptData, string privateKey)
        {
            string decryptData = "";
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.FromXmlString(privateKey);
                byte[] bEncrypt = Convert.FromBase64String(encryptData);
                int length = bEncrypt.Length;
                int offset = 0;
                string cache;
                int i = 0;
                while (length - offset > 0)
                {
                    if (length - offset > MAXDECRYPTSIZE)
                    {
                        cache = Encoding.UTF8.GetString(provider.Decrypt(getSplit(bEncrypt, offset, MAXDECRYPTSIZE), false));
                    }
                    else
                    {
                        cache = Encoding.UTF8.GetString(provider.Decrypt(getSplit(bEncrypt, offset, length - offset), false));
                    }
                    decryptData += cache;
                    i++;
                    offset = i * MAXDECRYPTSIZE;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return decryptData;
        }

        /// <summary>  
        /// 截取字节数组部分字节  
        /// </summary>  
        /// <param name="input"></param>  
        /// <param name="offset">起始偏移位</param>  
        /// <param name="length">截取长度</param>  
        /// <returns></returns>  
        private static byte[] getSplit(byte[] input, int offset, int length)
        {
            byte[] output = new byte[length];
            for (int i = offset; i < offset + length; i++)
            {
                output[i - offset] = input[i];
            }
            return output;
        }  
    

    }
}
