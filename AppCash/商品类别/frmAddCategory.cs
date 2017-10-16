using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppCash
{
    public partial class frmAddCategory : Form
    {
        public frmAddCategory()
        {
            InitializeComponent();
        }
        public int Pid;

        public frmAddCategory(int parentValue)
        {  
            InitializeComponent();
            Pid = parentValue;  
        }  
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证单位名称

            if (txtName.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入商品类别!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }



            Dong.BLL.Category bll = new Dong.BLL.Category();
            Dong.Model.Category model = new Dong.Model.Category();
            model.Name = txtName.Text;
            model.Pid = Pid;

            if (bll.Add(model))
            {
                MessageBoxEx.Show("添加成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //frmCategorytree frm = (frmCategorytree)this.Owner;
                //frm.fresh_();
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("保存失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }
    }
}
