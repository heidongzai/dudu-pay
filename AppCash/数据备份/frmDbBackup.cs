using DevComponents.DotNetBar;
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
    public partial class frmDbBackup : Form
    {
        string prikey, pubkey;
        public frmDbBackup()
        {
            InitializeComponent();
        }

        private void frmDbBackup_Load(object sender, EventArgs e)
        {
            //初始化界面信息
          




        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try { 
            String desFileName = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = "D:\\";
            sfd.Filter = "mdb File(*.mdb)|*.mdb";
            sfd.FileName = "MarketDB.mdb";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                desFileName = sfd.FileName;
                if (string.IsNullOrEmpty(Dong.Model.GlobalsInfo.hostIp))
                {
                    System.IO.File.Copy(CommonUtility.localPathToDocumentPath("duduCasherDB/MarketDB.mdb"), desFileName, true);
                }
                else
                {
                    String str=CommonUtility.localPathToHostIp("duduCasherDB/MarketDB.mdb");
                    System.IO.File.Copy(str, desFileName, true);
                }
                MessageBoxEx.Show("备份成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
            catch (Exception e5)
            {
                MessageBoxEx.Show("备份失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            String srcFileName = "";
            try { 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\";
            openFileDialog.Filter = "Mdb File(*.mdb)|*.mdb";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                srcFileName = openFileDialog.FileName;
                if (string.IsNullOrEmpty(Dong.Model.GlobalsInfo.hostIp))
                {
                System.IO.File.Copy(srcFileName, CommonUtility.localPathToDocumentPath("duduCasherDB/MarketDB.mdb"), true);}
                else{
                    System.IO.File.Copy(srcFileName, CommonUtility.localPathToHostIp("duduCasherDB/MarketDB.mdb"), true);
                }
                MessageBoxEx.Show("还原成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
            catch (Exception e5)
            {
                MessageBoxEx.Show("还原失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
              

        }
        
    
        private void buttonX1_Click(object sender, EventArgs e)
        {
               
            }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        }
   
}
