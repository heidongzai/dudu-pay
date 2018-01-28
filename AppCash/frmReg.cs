using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using System.Security.Cryptography;
namespace AppCash
{
    public partial class frmReg : Form
    {
        string privatekey, pubkey;
        public frmReg()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                pubkey = "<RSAKeyValue><Modulus>xe3teTUwLgmbiwFJwWEQnshhKxgcasglGsfNVFTk0hdqKc9i7wb+gG7HOdPZLh65QyBcFfzdlrawwVkiPEL5kNTX1q3JW5J49mTVZqWd3w49reaLd8StHRYJdyGAL4ZovBhSTThETi+zYvgQ5SvCGkM6/xXOz+lkMaEgeFcjQQs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
                Dong.BLL.Dictionary bShop = new Dong.BLL.Dictionary();
                Dong.Model.Dictionary mShop = new Dong.Model.Dictionary();
                //Dong.BLL.Dictionary bAccountNo = new Dong.BLL.Dictionary();
                //Dong.Model.Dictionary mAccountNo = new Dong.Model.Dictionary();
                //string strSql_AccountNo = "KeyStr = 'AccountNo'";
                //String AccountNo = "";
                //List<Dong.Model.Dictionary> AccountNoList = bAccountNo.GetModelList(strSql_AccountNo);
                //if (AccountNoList.Count != 0)
                //{
                //    mAccountNo = AccountNoList[0];
                   
                //}
                String AccountNo =CommonUtility.ReadReader("duduCasherDB/an.dll", "2");

                //mShop = bShop.GetModel(int.Parse(tbId.Text));
                //mShop.Id = int.Parse(tbId.Text);
                //mShop.ValueStr = tbAccountNo.Text;

                //string jiqima = "cpuid_" + Computer.Instance().CpuID + "_macAddress_" + Computer.Instance().MacAddress ;
                string jiqima = "cpuid_" + Computer.Instance().CpuID + "_diskId_" + Computer.Instance().DiskID;
                //将机器码和软件序列号(账户标志)发送给远程进行加密
                //string requestString = "http://www.taiyuanecho.xyz/dudu-pay-web-gateway/microPay/rsaAuthrize?jiqima=" + jiqima + "&userNo=" + tbAccountNo.Text;
                string key = null;
                try
                {
                    //key = AppCash.CommonUtility.GetInfo(requestString);
                    key = CommonUtility.getMD5(tbAccountNo.Text);
                    
                    
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
                /*int i=key.IndexOf("fail");
                if (i >= 0)
                {
                    if (key.Length >= 4) {
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

                    CommonUtility.WriteWriter("duduCasherDB/an.dll",tbAccountNo.Text, "2");
                    CommonUtility.WriteWriter("duduCasherDB/hlx.dll", key,"2");
                    MessageBox.Show("注册成功!系统将关闭，请重新登录!");
                        Application.Exit();
                    return;

                }
                else
                {
                    MessageBox.Show("注册失败!");
                    return;
                }

            }

         }

        private void frmReg_Load(object sender, EventArgs e)
        {

            //初始化界面信息
            //提取用户列表
            DataSet ds = new DataSet();
            Dong.BLL.OperInfo mOper = new Dong.BLL.OperInfo();
            ds = mOper.GetAllList();


            //提取配置信息
            Dong.BLL.ShopInfo bShop = new Dong.BLL.ShopInfo();
            Dong.Model.ShopInfo mShop = new Dong.Model.ShopInfo();
            mShop = bShop.GetModel(1);
            Dong.Model.GlobalsInfo.shopName = mShop.Name;
            

            Dong.Model.GlobalsInfo.shopAddr = mShop.Addr;
            tbAccountNo.Text = CommonUtility.getJiqima();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "http://www.taiyuanecho.xyz");  
            //Application.Exit();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Application.Exit();
                    return true;
                case Keys.Enter:
                    btnReg_Click(null, null);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void miyao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
