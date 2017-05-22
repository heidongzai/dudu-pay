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
                //mShop = bShop.GetModel(int.Parse(tbId.Text));
                //mShop.Id = int.Parse(tbId.Text);
                //mShop.ValueStr = tbAccountNo.Text;

                string jiqima = "cpuid:" + Computer.Instance().CpuID + "|diskId:" + Computer.Instance().DiskID + "|macAddress:" + Computer.Instance().MacAddress ;
                //将机器码和软件序列号(账户标志)发送给远程进行加密
                string requestString = "http://www.taiyuanecho.xyz/roncoo-pay-web-sample-shop/roncooPay/rsaAuthrize?jiqima=" + jiqima + "&accountNo=" + tbAccountNo.Text;
                string key = AppCash.CommonUtility.GetInfo(requestString);

                if (string.IsNullOrEmpty(key))
                {
                    MessageBox.Show("注册失败!");
                    return;
                }
                CommonUtility.WriteWriter("hlx.dll", key);


                string info = CommonUtility.TestDecry(key, null);
                if (jiqima == info)
                {
                    if (MessageBox.Show("注册成功!") == DialogResult.OK)
                    {

                        frmLogin frmLogin = new frmLogin();
                        frmLogin.Show();
                        this.Visible = false;
                        //this.Close();
                    }
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
    }
}
