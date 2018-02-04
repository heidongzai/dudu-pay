using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace AppCash
{
    public partial class frmSafe : Form
    {
        string prikey, pubkey;
        public frmSafe()
        {
            InitializeComponent();
        }

        private void frmShop_Load(object sender, EventArgs e)
        {
            //初始化界面信息
            //Dong.BLL.Dictionary bShop = new Dong.BLL.Dictionary();
            //Dong.Model.Dictionary mShop = new Dong.Model.Dictionary();
            //string strSql = "KeyStr = 'AccountNo'";
            //List<Dong.Model.Dictionary> dl= bShop.GetModelList(strSql);
            //if (dl!=null)
            //{
            //    mShop = dl[0];
            //}
            string AccountNo = CommonUtility.ReadReader("duduCasherDB/an.dll", "2");
            if (string.IsNullOrEmpty(AccountNo))
            {

                tbAccountNo.Text = CommonUtility.getJiqima();
            }
            else {
                tbAccountNo.Text = AccountNo;
            }
            //tbId.Text = mShop.Id+"";


          
            //提取用户注册信息

            if (CommonUtility.TestReg().Equals("1"))
            {
                this.tbAccountNo.Visible = false;
                this.labelX1.Visible = false;
                this.labelX2.Visible = true;
                //this.buttonX1.Visible = true;
                //this.buttonX2.Visible = true;
                this.btnSave.Visible = false;
            }




        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                //pubkey = "<RSAKeyValue><Modulus>xe3teTUwLgmbiwFJwWEQnshhKxgcasglGsfNVFTk0hdqKc9i7wb+gG7HOdPZLh65QyBcFfzdlrawwVkiPEL5kNTX1q3JW5J49mTVZqWd3w49reaLd8StHRYJdyGAL4ZovBhSTThETi+zYvgQ5SvCGkM6/xXOz+lkMaEgeFcjQQs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
                Dong.BLL.Dictionary bShop = new Dong.BLL.Dictionary();
                Dong.Model.Dictionary mShop = new Dong.Model.Dictionary();
                //mShop = bShop.GetModel(int.Parse(tbId.Text));
                //mShop.Id = int.Parse(tbId.Text);
                //mShop.ValueStr = tbAccountNo.Text;
                //Dong.BLL.Dictionary bAccountNo = new Dong.BLL.Dictionary();
                //Dong.Model.Dictionary mAccountNo = new Dong.Model.Dictionary();
                //string strSql_AccountNo = "KeyStr = 'AccountNo'";
                //String AccountNo = "";
                //List<Dong.Model.Dictionary> AccountNoList = bAccountNo.GetModelList(strSql_AccountNo);
                //if (AccountNoList.Count != 0)
                //{
                //    mAccountNo = AccountNoList[0];

                //}
                string mAccountNo=CommonUtility.ReadReader("duduCasherDB/an.dll",  "2");
              //  string jiqima = "cpuid:" + Computer.Instance().CpuID + "|diskId:" + Computer.Instance().DiskID + "|macAddress:" + Computer.Instance().MacAddress + "|LoginUserName:" + Computer.Instance().LoginUserName + "|IpAddress:" + Computer.Instance().IpAddress;
                //string jiqima = "cpuid_" + Computer.Instance().CpuID + "_macAddress_" + Computer.Instance().MacAddress;
                //string jiqima = "cpuid_" + Computer.Instance().CpuID + "_diskId_" + Computer.Instance().DiskID;
                //将机器码和软件序列号(账户标志)发送给远程进行加密
                //string requestString = "http://www.taiyuanecho.xyz/dudu-pay-web-gateway/microPay/rsaAuthrize?jiqima=" + jiqima + "&userNo=" + tbAccountNo.Text;
                string key = null;
                try
                {
                    key = CommonUtility.getMD5(CommonUtility.getJiqima());
                    //key = AppCash.CommonUtility.GetInfo(requestString);
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.Message);
                    //MessageBox.Show("请求失败，请检查网络连接或联系软件管理员!");
                    MessageBox.Show("注册失败!");


                }
                if (string.IsNullOrEmpty(key))
                {
                    MessageBox.Show("注册失败!");
                    return;
                }
                /*int i = key.IndexOf("fail");
                if (i >= 0)
                {
                    if (key.Length >= 4)
                    {
                        MessageBox.Show("注册失败!" + key.Substring(4, key.Length - 4));
                    }
                    else
                    {
                        MessageBox.Show("注册失败!");
                    }
                    return;
                }*/

               

                //string info = CommonUtility.TestDecry(key, null);
                //if (jiqima == info)
                if (key.Equals(miyao.Text))
                {
                    //将用户编号保存到库中
                    //mAccountNo.ValueStr = tbAccountNo.Text;
                    //bAccountNo.Update(mAccountNo);
                    CommonUtility.WriteWriter("duduCasherDB/an.dll", tbAccountNo.Text, "2");
                    CommonUtility.WriteWriter("duduCasherDB/hlx.dll", key,"2");
                    MessageBox.Show("注册成功!系统将关闭，请重新登录!");
                    Application.Exit();
                    //刷新窗体
                    frmShop_Load(this, null);
                }
                else
                {
                    MessageBox.Show("注册失败!");
                    return;
                }

            }


        }

        void getKeys()
        {
            using (RSACryptoServiceProvider ras = new RSACryptoServiceProvider())
            {
                //公匙
                pubkey = ras.ToXmlString(false);
                //私匙
                prikey = ras.ToXmlString(true);
            }
        }

        private void tbShopName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            
                 Dong.BLL.Dictionary bShop = new Dong.BLL.Dictionary();
                Dong.Model.Dictionary mShop = new Dong.Model.Dictionary();
                //mShop = bShop.GetModel(int.Parse(tbId.Text));
                //mShop.Id = int.Parse(tbId.Text);
                //mShop.ValueStr = tbAccountNo.Text;
                //Dong.BLL.Dictionary bAccountNo = new Dong.BLL.Dictionary();
                //Dong.Model.Dictionary mAccountNo = new Dong.Model.Dictionary();
                //string strSql_AccountNo = "KeyStr = 'AccountNo'";
                
                //List<Dong.Model.Dictionary> AccountNoList = bAccountNo.GetModelList(strSql_AccountNo);
                //if (AccountNoList.Count != 0)
                //{
                //    mAccountNo = AccountNoList[0];

                //}
                //获取产品序列号
                string AccountNo = CommonUtility.ReadReader("duduCasherDB/an.dll", "2");
               //String AccountNo = mAccountNo.ValueStr;
              //  获取产品机器码
                string jiqima = "cpuid_" + Computer.Instance().CpuID + "_diskId_" + Computer.Instance().DiskID;

                //  获取产品密文

                string miwen = CommonUtility.ReadReader("duduCasherDB/hlx.dll","2");
                
                //将机器码和软件序列号(账户标志)发送给远程进行加密
                string requestString = "http://www.taiyuanecho.xyz/dudu-pay-web-gateway/microPay/deRsaAuthrize?jiqima=" + jiqima + "&userNo=" + tbAccountNo.Text+"&miwen="+miwen+"&operType=jinyong";
                string key = null;
                try
                {
                    key = AppCash.CommonUtility.GetInfo(requestString);
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.Message);
                    MessageBox.Show("请求失败，请检查网络连接或联系软件管理员!");


                }
                if (string.IsNullOrEmpty(key))
                {
                    MessageBox.Show("注销失败!");
                    return;
                }
                int i = key.IndexOf("fail");
                if (i >= 0)
                {
                    if (key.Length >= 4)
                    {
                        MessageBox.Show("注销失败!" + key.Substring(4, key.Length - 4));
                    }
                    else
                    {
                        MessageBox.Show("注销失败!");
                    }
                    return;
                }

                    //将用户使用次数调为最高，并删除用户序列号信息
                   CommonUtility. deleteFile("duduCasherDB/hlx.dll","2");
                   CommonUtility.WriteWriter("duduCasherDB/sycs.dll", "60","2");
                    MessageBox.Show("注销成功，程序将关闭!");
                    //关闭程序
                    Application.Exit();
                

        }
        
    
        private void buttonX1_Click(object sender, EventArgs e)
        {
                 Dong.BLL.Dictionary bShop = new Dong.BLL.Dictionary();
                Dong.Model.Dictionary mShop = new Dong.Model.Dictionary();
                //mShop = bShop.GetModel(int.Parse(tbId.Text));
                //mShop.Id = int.Parse(tbId.Text);
                //mShop.ValueStr = tbAccountNo.Text;
                //Dong.BLL.Dictionary bAccountNo = new Dong.BLL.Dictionary();
                //Dong.Model.Dictionary mAccountNo = new Dong.Model.Dictionary();
                //string strSql_AccountNo = "KeyStr = 'AccountNo'";
                
                //List<Dong.Model.Dictionary> AccountNoList = bAccountNo.GetModelList(strSql_AccountNo);
                //if (AccountNoList.Count != 0)
                //{
                //    mAccountNo = AccountNoList[0];

                //}

                //获取产品序列号
               //String AccountNo = mAccountNo.ValueStr;
               string AccountNo = CommonUtility.ReadReader("duduCasherDB/an.dll", "2");
              //  获取产品机器码
                string jiqima = "cpuid_" + Computer.Instance().CpuID + "_diskId_" + Computer.Instance().DiskID;

                //  获取产品密文

                string miwen = CommonUtility.ReadReader("duduCasherDB/hlx.dll","2");
                
                //将机器码和软件序列号(账户标志)发送给远程进行加密
                string requestString = "http://www.taiyuanecho.xyz/dudu-pay-web-gateway/microPay/deRsaAuthrize?jiqima=" + jiqima + "&userNo=" + tbAccountNo.Text + "&miwen=" + miwen + "&operType=jiebang";
                string key = null;
                try
                {
                    key = AppCash.CommonUtility.GetInfo(requestString);
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.Message);
                    MessageBox.Show("请求失败，请检查网络连接或联系软件管理员!");


                }
                if (string.IsNullOrEmpty(key))
                {
                    MessageBox.Show("解绑失败!");
                    return;
                }
                int i = key.IndexOf("fail");
                if (i >= 0)
                {
                    if (key.Length >= 4)
                    {
                        MessageBox.Show("解绑失败!" + key.Substring(4, key.Length - 4));
                    }
                    else
                    {
                        MessageBox.Show("解绑失败!");
                    }
                    return;
                }

                //将用户使用次数调为最高，并删除用户序列号信息
                CommonUtility.deleteFile("duduCasherDB/hlx.dll","2");
                CommonUtility.WriteWriter("duduCasherDB/sycs.dll", "60","2");
                MessageBox.Show("注销成功，程序将关闭!");
                //关闭程序
                Application.Exit();

            }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }
        }
   
}
