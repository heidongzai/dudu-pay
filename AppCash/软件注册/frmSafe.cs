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
            Dong.BLL.Dictionary bShop = new Dong.BLL.Dictionary();
            Dong.Model.Dictionary mShop = new Dong.Model.Dictionary();
            string strSql = "KeyStr = 'AccountNo'";
            List<Dong.Model.Dictionary> dl= bShop.GetModelList(strSql);
            if (dl!=null)
            {
                mShop = dl[0];
            }

            tbAccountNo.Text = mShop.ValueStr;
            //tbId.Text = mShop.Id+"";


          
            //提取用户注册信息

            if (CommonUtility.TestReg().Equals("1"))
            {
                this.tbAccountNo.Visible = false;
                this.labelX1.Visible = false;
                this.labelX2.Visible = true;
                this.btnSave.Visible = false;
            }




        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                pubkey = "<RSAKeyValue><Modulus>xe3teTUwLgmbiwFJwWEQnshhKxgcasglGsfNVFTk0hdqKc9i7wb+gG7HOdPZLh65QyBcFfzdlrawwVkiPEL5kNTX1q3JW5J49mTVZqWd3w49reaLd8StHRYJdyGAL4ZovBhSTThETi+zYvgQ5SvCGkM6/xXOz+lkMaEgeFcjQQs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
                Dong.BLL.Dictionary bShop = new Dong.BLL.Dictionary();
                Dong.Model.Dictionary mShop = new Dong.Model.Dictionary();
                //mShop = bShop.GetModel(int.Parse(tbId.Text));
                //mShop.Id = int.Parse(tbId.Text);
                //mShop.ValueStr = tbAccountNo.Text;

                string jiqima = "cpuid:" + Computer.Instance().CpuID + "|diskId:" + Computer.Instance().DiskID + "|macAddress:" + Computer.Instance().MacAddress + "|LoginUserName:" + Computer.Instance().LoginUserName + "|IpAddress:" + Computer.Instance().IpAddress;
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
                    MessageBox.Show("注册成功!");
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
    }
}
