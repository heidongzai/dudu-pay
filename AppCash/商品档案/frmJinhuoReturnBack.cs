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
    public partial class frmJinhuoReturnBack : Form
    {
        String categoryName = "";
        String categoryId = "";
        public frmJinhuoReturnBack()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmJinhuoReturnBack_Load(object sender, EventArgs e)
        {
            


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证商品编号

            if (keTuiShuLiang.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入商品商品!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                keTuiShuLiang.Focus();
                return;
            }

            //验证商品名称
            if (tuiHuoShuLiang.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入商品名称!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tuiHuoShuLiang.Focus();
                return;
            }
            //if (tbFactory.Text.Trim() == "")
            //{
            //    MessageBoxEx.Show("请输入商品生产厂家!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tbFactory.Focus();
            //    return;
            //}



           

            /*if (txtPrice2.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入成本价!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice2.Focus();
                return;
            }
            double price2;
            if (!double.TryParse(txtPrice2.Text, out price2))
            {
                MessageBoxEx.Show("成本价必须为数字!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice2.Focus();
                return;
            }*/

            Dong.BLL.GoodsInfo bll = new Dong.BLL.GoodsInfo();
            Dong.Model.GoodsInfo model = new Dong.Model.GoodsInfo();
            model = bll.GetModel(keTuiShuLiang.Text);
            model.Id = int.Parse(this.Tag.ToString());
            model.Code = keTuiShuLiang.Text;
            model.GoodsName = tuiHuoShuLiang.Text;
           
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //点击弹出方法
            frmCategorySelected frmChild = new frmCategorySelected();
            frmChild.ShowDialog();
            if (frmChild.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                categoryId = frmChild.CategoryId;
                categoryName = frmChild.CategoryName;
                //this.tbCategory.Text = categoryName;
            }
        }

        private void tbCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
