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
    public partial class frmTiaojia : Form
    {
        String categoryName = "";
        String categoryId = "";
        public frmTiaojia()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTiaojia_Load(object sender, EventArgs e)
        {
            Dong.BLL.GoodsInfo bll = new Dong.BLL.GoodsInfo();
            Dong.Model.GoodsInfo model = new Dong.Model.GoodsInfo();
            model = bll.GetModelById(int.Parse(this.Tag.ToString()));
            if(model!=null){
                this.tbxItemName.Text=model.GoodsName;
                this.tiaojiajine.Text=model.Counts.ToString();
            }
            


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证退货总额

            if (this.tiaojiajine.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入调价金额!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tiaojiajine.Focus();
                return;
            }

            double price0;
            if (!double.TryParse(tiaojiajine.Text, out price0))
            {
                MessageBoxEx.Show("调价金额为数字!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tiaojiajine.Focus();
                return;
            }

            

            Dong.BLL.GoodsInfo bll = new Dong.BLL.GoodsInfo();
            Dong.Model.GoodsInfo model = new Dong.Model.GoodsInfo();
            model = bll.GetModelById(int.Parse(this.Tag.ToString()));
            if (model == null)
            {
                MessageBoxEx.Show("该商品不存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                return;
            }
            if (model.Price2 * model.Counts + price0<=0)
            {
                MessageBoxEx.Show("调价后库存成本小于等于零，不合法!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            

            //添加进货信息
            Dong.BLL.InGoods bInGoods = new Dong.BLL.InGoods();
            Dong.Model.InGoods mInGoods = new Dong.Model.InGoods();
            string input = "B" + DateTime.Now.ToString("yyyyMMddHHmmss");

        
          
                mInGoods.Price = price0;
                mInGoods.Counts = 0;
                model.Price2 = (model.Price2 * model.Counts + price0) / (model.Counts);
                
                
                
           
            mInGoods.PCode = input;
            mInGoods.GoodsCode = model.Code;
            
            mInGoods.IDate = DateTime.Now.Date;
            mInGoods.Oper = Dong.Model.GlobalsInfo.UserName;
            mInGoods.Supplier = model.Supplier;
            mInGoods.Remark = "进货调价";
            if( bll.Update(model)){
                if(bInGoods.Add(mInGoods)){
                    MessageBoxEx.Show("操作成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmGoods frm = (frmGoods)this.Owner;
                    frm.refreshData();
                    this.Close();
                }
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
