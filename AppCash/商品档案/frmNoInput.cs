using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace AppCash
{
    public partial class frmNoInput : Form
    {
        private DataTable dt = null;
        

        public frmNoInput()
        {
            InitializeComponent();
        }
        
        public string ItemIds
        {
            get { return itemIds; }
            set { itemIds = value; }
        }

        private string itemIds = "";
       

        //绑定根节点
       
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNoInput_Load(object sender, EventArgs e)
        {
           
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string rel = "";
            foreach (TextBox t in this.flowLayoutPanel1.Controls)
            {
                rel += "," + t.Text;
            }
            this.itemIds = rel;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }


        private void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            TextBox t1 = new TextBox();
            int itemNums =int.Parse(labelNum.Text) + 1;
            t1.Name = "txt_" + itemNums;
            t1.Width = 200;
            flowLayoutPanel1.Controls.Add(t1);
            String s =itemNums.ToString();
            this.labelNum.Text = s;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(this.labelNum.Text);
            if(n<=1){
                return;
            }
            string strPxName = "txt_"+this.labelNum.Text;
            Control sk = GetPbControl(flowLayoutPanel1,strPxName);
            if (sk == null)
            {

                return;
            }
            else
            {
                this.flowLayoutPanel1.Controls.Remove(sk);
                this.labelNum.Text= (n - 1).ToString();
            }
            
        }
        private Control GetPbControl(Control c,string strName)
        {
            string pbName = strName;
            return GetControl(c, pbName);
        }
        /// <summary>
        /// 通过控件名获取控件
        /// </summary>
        /// <param name="ct">控件所在的容器或者窗体</param>
        /// <param name="name">需要查找的控件名</param>
        /// <returns></returns>
        public static Control GetControl(Control ct, string name)
        {
            Control[] ctls = ct.Controls.Find(name, false);
            if (ctls.Length > 0)
            {
                return ctls[0];
            }
            else
            {
                return null;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
