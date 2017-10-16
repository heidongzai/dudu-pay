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
    public partial class frmHostConfig : Form
    {
        
        public frmHostConfig()
        {
            InitializeComponent();
        }

        private void btnHostConfig_Click(object sender, EventArgs e)
        {

            if (CommonUtility.isAIp(this.tbHostIp.Text).Equals("0"))
            {
                MessageBox.Show("输入的ip地址格式不正确");
                return;
            }
           
                if (this.tbHostIp.Text != "")
                {
                    //设置xml文件
                                        CommonUtility.WriteWriter("hostIp.dll", this.tbHostIp.Text, "2");
                }
                else
                {
                    MessageBox.Show("请输入ip地址");
                    return;
                }

                MessageBox.Show("操作成功!系统将关闭，请重新登录!");
                Application.Exit();
                return;
                    
                

            

         }

        private void frmHostConfig_Load(object sender, EventArgs e)
        {
            String HostIp = "";
            HostIp = CommonUtility.ReadReader("hostIp.dll", "2");
               this.tbHostIp.Text = HostIp;
               Dong.Model.GlobalsInfo.hostIp = HostIp;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //设置xml文件
            CommonUtility.SetValue("ConnectionString", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB/MarketDB.mdb");
            //将信息保存到数据库中
            //Dong.BLL.Dictionary bHostIp = new Dong.BLL.Dictionary();
           // Dong.Model.Dictionary mHostIp = new Dong.Model.Dictionary();
           // string strSql_HostIp = "KeyStr = 'hostIp'";
            CommonUtility.WriteWriter("hostIp.dll", "", "2");
            //try
           // {
             //   List<Dong.Model.Dictionary> HostIpList = bHostIp.GetModelList(strSql_HostIp);
             //   if (HostIpList.Count != 0)
             //   {
             //       mHostIp = HostIpList[0];
             //       mHostIp.ValueStr = this.tbHostIp.Text;
              //      bHostIp.Update(mHostIp);

               // }
              //  else
              //  {
              //      mHostIp.KeyStr = "hostIp";
               //     mHostIp.ValueStr = this.tbHostIp.Text;
             //       mHostIp.Mark = "";
             //       bHostIp.Add(mHostIp);
             //   }
          //  }catch(Exception e2){
//
           // }
            MessageBox.Show("操作成功!系统将关闭，请重新登录!");
            Application.Exit();
            return;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Application.Exit();
                    return true;
                case Keys.Enter:
                    btnHostConfig_Click(null, null);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void tbHostIp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
