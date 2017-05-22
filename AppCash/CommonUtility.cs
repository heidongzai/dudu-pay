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
        /// ����ֻ������������
        /// </summary>
        /// <param name="e"></param>
        public static void ValidateNumber(KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')  //ֻ�����������֣�-���˸��
            {
                e.Handled = false;
            }
        }


        /// <summary>
        /// ����ֻ�����������֣�����'-'��
        /// </summary>
        /// <param name="e"></param>
        public static void ValidateTel(KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == '\b')  //ֻ�����������֣�-���˸��
            {
                e.Handled = false;
            }

        }

        /// <summary>
        /// ��֤�Ƿ�����TextBox����Ϊ��,������Ϊ��,
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
        /// ��������TextBoxΪReadOnly=true
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
        /// ��ȡurl�ķ���ֵ  
        /// </summary>  
        /// <param name="url">eg:http://m.weather.com.cn/atad/101010100.html </param>  
        public static string GetInfo(string url)
        {
            string strBuff = "";
            Uri httpURL = new Uri(url);
            ///HttpWebRequest��̳���WebRequest����û���Լ��Ĺ��캯������ͨ��WebRequest��Creat���� ������������ǿ�Ƶ�����ת��   
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
            ///ͨ��HttpWebRequest��GetResponse()��������HttpWebResponse,ǿ������ת��   
            HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
            ///GetResponseStream()������ȡHTTP��Ӧ��������,������ȡ��URL����ָ������ҳ����   
            ///���ɹ�ȡ����ҳ�����ݣ�����System.IO.Stream��ʽ���أ���ʧ�������ProtoclViolationException�� ���ڴ���ȷ������Ӧ�����µĴ���ŵ�һ��try���д�������򵥴���   
            Stream respStream = httpResp.GetResponseStream();
            ///���ص�������Stream��ʽ�ģ����Կ�������StreamReader���ȡGetResponseStream�����ݣ�����   
            //StreamReader���Read�������ζ�ȡ��ҳԴ�������ÿһ�е����ݣ�ֱ����β����ȡ�ı����ʽ��UTF8��   
            StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
            strBuff = respStreamReader.ReadToEnd();
            return strBuff;
        }

        /// <summary>
        /// ��ȡ�����
        /// </summary>
        /// <param name="length">����</param>
        /// <param name="availableChars">ָ������ַ���Ϊ�գ�Ĭ��ϵͳָ��</param>
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

        //�÷�����bug�����޸�20170413echo
        public static void ReadStream(string filePath)
        {
            byte[] byData = new byte[100];
            char[] charData = new char[1000];
            try
            {
                FileStream file = new FileStream(filePath, FileMode.Open);
                file.Seek(0, SeekOrigin.Begin);
                file.Read(byData, 0, 100); //byData���������ֽ�����,���Խ���FileStream�����е�����,��2���������ֽ������п�ʼд�����ݵ�λ��,��ͨ����0,��ʾ������Ŀ����ļ���������д����,���һ�������涨���ļ��������ַ�.
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
            //����ֽ�����
            byte[] data = System.Text.Encoding.Default.GetBytes(content);
            //��ʼд��
            fs.Write(data, 0, data.Length);
            //��ջ��������ر���
            fs.Flush();
            fs.Close();
        }

        public static void WriteWriter(string filePath, string content)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //��ʼд��
            sw.Write(content);
            //��ջ�����
            sw.Flush();
            //�ر���
            sw.Close();
            fs.Close();
        }


        /// <summary>  
        /// ���ɹ�Կ��˽Կ  
        /// </summary>  
        /// <returns>��Կ��˽Կ����Կ��"PUBLIC",˽Կ��"PRIVATE"</returns>  
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
            //java�˵�����
            if (string.IsNullOrEmpty(pwd)) { 
            pwd = "Uye5dkFjGRU3R4mc/eIzVSp3YyNnCz7ZfgJNzJ5sDKtubQzXMi9frP1IQ/eFapDvj3lrURtphBF//+zjjhHreKe9EfGXAFygAHZMxtc7GWxbz4rOQcFLenmK44kQy/DwdRCw4IajNVZeus70eFBYvj7VtqufltzFF0ZZeoItdyI=";
            }
            //�����˽Կ �� createKeyPair ����PRIVATE��
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
            //���к�
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
            //��ȡ��Ȩ����s
            string key = CommonUtility.ReadReader("hlx.dll");

            string jiqima = "cpuid:" + Computer.Instance().CpuID + "|diskId:" + Computer.Instance().DiskID + "|macAddress:" + Computer.Instance().MacAddress  ;
            string info = CommonUtility.TestDecry(key, null);
            //�����Ȩ����Ϊ�ջ������к�Ϊ�ջ���Ȩ��֤ʧ�� ��˵���ò�ƷΪ���ð�
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
        /// RSA����  
        /// </summary>  
        /// <param name="encryptData">����Base64���������</param>  
        /// <param name="privateKey">˽Կ</param>  
        /// <returns>RSA���ܺ������</returns>  
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
        /// ��ȡ�ֽ����鲿���ֽ�  
        /// </summary>  
        /// <param name="input"></param>  
        /// <param name="offset">��ʼƫ��λ</param>  
        /// <param name="length">��ȡ����</param>  
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
