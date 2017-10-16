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
    public partial class frmGY : Form
    {
        
        public frmGY()
        {
            InitializeComponent();
        }

        private void frmGY_Load(object sender, EventArgs e)
        {
            //版本号
            String ver = CommonUtility.ReadReader("ver.dll","0");
            lblVer.Text = "版本：" + ver;
          


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            


        }

       

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void lblVer_Click(object sender, EventArgs e)
        {

        }
        }
   
}
