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
    public partial class frmEditGoods : Form
    {
        String categoryName = "";
        String categoryId = "";
        public frmEditGoods()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditGoods_Load(object sender, EventArgs e)
        {
            Dong.BLL.Category catebll = new Dong.BLL.Category();
            
            //绑定单位
            Dong.BLL.Unit unitbll = new Dong.BLL.Unit();
            ddlUnit.DataSource = unitbll.GetAllList().Tables[0];
            ddlUnit.DisplayMember = "Name";
            ddlUnit.ValueMember = "Id";
            //绑定供应商
            Dong.BLL.Supplier supplierbll = new Dong.BLL.Supplier();
            ddlSupper.DataSource = supplierbll.GetAllList().Tables[0];
            ddlSupper.DisplayMember = "Name";
            ddlSupper.ValueMember = "Id";

            Dong.BLL.GoodsInfo bll = new Dong.BLL.GoodsInfo();
            Dong.Model.GoodsInfo model = new Dong.Model.GoodsInfo();
            model = bll.GetModelById(int.Parse(this.Tag.ToString()));
            if (model != null)
            {
                tbCode.Text = model.Code;
                tbName.Text = model.GoodsName;
                tbFactory.Text = model.Factory;
              
                ddlUnit.SelectedValue = model.Unit;
                ddlSupper.SelectedValue = model.Supplier;
                txtPrice0.Text = model.Price0 == null ? "" : model.Price0.ToString();
                txtPrice1.Text = model.Price1 == null ? "" : model.Price1.ToString();
                txtPrice2.Text = model.Price2 == null ? "" : model.Price2.ToString();
                this.categoryId = model.Category.ToString();
                this.tbCategory.Text = model.CategoryName;
                this.categoryName = model.CategoryName.ToString();
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证商品编号

            if (tbCode.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入商品商品!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbCode.Focus();
                return;
            }

            //验证商品名称
            if (tbName.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入商品名称!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbName.Focus();
                return;
            }
            //if (tbFactory.Text.Trim() == "")
            //{
            //    MessageBoxEx.Show("请输入商品生产厂家!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tbFactory.Focus();
            //    return;
            //}

            if (txtPrice0.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入零售价!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice0.Focus();
                return;
            }
            double price0;
            if (!double.TryParse(txtPrice0.Text, out price0))
            {
                MessageBoxEx.Show("零售价必须为数字!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice0.Focus();
                return;
            }


            if (txtPrice1.Text.Trim() == "")
            {
               MessageBoxEx.Show("请输入进货价!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice1.Focus();
                return;
            }
            double price1;
            if (!double.TryParse(txtPrice1.Text, out price1))
            {
                MessageBoxEx.Show("进货价必须为数字!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice1.Focus();
                return;
            }

            /**/
            double price2=0;
            if (txtPrice2.ReadOnly == false) { 
            if (txtPrice2.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入成本价!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice2.Focus();
                return;
            }
            
            if (!double.TryParse(txtPrice2.Text, out price2))
            {
                MessageBoxEx.Show("成本价必须为数字!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice2.Focus();
                return;
            }
            }
            Dong.BLL.GoodsInfo bll = new Dong.BLL.GoodsInfo();
            Dong.Model.GoodsInfo model = new Dong.Model.GoodsInfo();
            model = bll.GetModel(tbCode.Text);
            model.Id = int.Parse(this.Tag.ToString());
            model.Code = tbCode.Text;
            model.GoodsName = tbName.Text;
            if (!string.IsNullOrEmpty(categoryId) && !string.IsNullOrEmpty(categoryName) && !string.IsNullOrEmpty(this.tbCategory.Text))
            {
                model.Category = Int32.Parse(categoryId);
                model.CategoryName = categoryName;
            }
            else
            {
                model.CategoryName = "";
            }
            if (ddlUnit.SelectedValue != null && !string.IsNullOrEmpty(ddlUnit.SelectedValue.ToString()))
            {
                model.Unit = Int32.Parse(ddlUnit.SelectedValue.ToString());
                model.UnitName = ddlUnit.Text;
            }
            else
            {
                model.UnitName = "";
            }

            if (ddlSupper.SelectedValue != null && !string.IsNullOrEmpty(ddlSupper.SelectedValue.ToString()))
            {
                model.Supplier = Int32.Parse(ddlSupper.SelectedValue.ToString());
                model.SupplierName = ddlSupper.Text;
            }
            else
            {
                model.SupplierName = "";
            }
            model.Factory = tbFactory.Text;
            model.Counts = model.Counts;
            model.Price0 = price0;
            model.Price1 = price1;
            if (!price2.Equals(0)) {
                model.Price2 = price2;
            }
            if (bll.Update(model))
            {
                MessageBoxEx.Show("修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmGoods frm = (frmGoods)this.Owner;
                frm.refreshData();
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("修改失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                this.tbCategory.Text = categoryName;
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

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.txtPrice2.ReadOnly = false;
        }


    }
}
