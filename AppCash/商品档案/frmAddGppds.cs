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
    public partial class frmAddGoods : Form
    {
        String categoryName = "";
        String categoryId = "";
        public frmAddGoods()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddGoods_Load(object sender, EventArgs e)
        {
            
            //绑定商品类别
            //Dong.BLL.Category catebll = new Dong.BLL.Category();
            //ddlCategory.DataSource = catebll.GetAllList().Tables[0];
            //ddlCategory.DisplayMember = "Name";
            //ddlCategory.ValueMember = "Id";
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证商品重复性
            Dong.BLL.GoodsInfo bGoods = new Dong.BLL.GoodsInfo();
            Dong.Model.GoodsInfo mGoods = new Dong.Model.GoodsInfo();

            //验证商品编号

            if (tbCode.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入商品编码!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbCode.Focus();
                return;
            }
            else
            {
                mGoods = bGoods.GetModel(tbCode.Text.Trim());
                if (mGoods != null)
                {

                    MessageBoxEx.Show("系统中已存在改商品编码，请重新输入!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbCode.Text = "";
                    tbCode.Focus();
                    return;
                }
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

            //if (txtPrice2.Text.Trim() == "")
            //{
            //    MessageBoxEx.Show("请输入成本价!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtPrice2.Focus();
            //    return;
            //}
            //double price2;
            //if (!double.TryParse(txtPrice2.Text, out price2))
            //{
            //    MessageBoxEx.Show("成本价必须为数字!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
             //   txtPrice2.Focus();
            //    return;
            //}

            Dong.BLL.GoodsInfo bll = new Dong.BLL.GoodsInfo();
            Dong.Model.GoodsInfo model = new Dong.Model.GoodsInfo();
            model.Code = tbCode.Text;
            model.GoodsName = tbName.Text;
            if (!string.IsNullOrEmpty(categoryId) && !string.IsNullOrEmpty(categoryName) && !string.IsNullOrEmpty(this.tbCategory.Text))
            {
                model.Category = Int32.Parse(categoryId);
                model.CategoryName = categoryName;
            }
            else
            {
                MessageBoxEx.Show("请选择商品类别!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            model.Counts = 0;
            model.Price0 = price0;
            model.Price1 = price1;
            //model.Price2 = price2;
            if (bll.Add(model))
            {
                MessageBoxEx.Show("添加成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmGoods frm = (frmGoods)this.Owner;
                frm.refreshData();
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("保存失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void txtPrice2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
