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
    public partial class frmJinhuoTiaojia : Form
    {
        String categoryName = "";
        String categoryId = "";
        public frmJinhuoTiaojia()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmJinhuoReturnBack_Load(object sender, EventArgs e)
        {
            Dong.BLL.GoodsInfo bll = new Dong.BLL.GoodsInfo();
            Dong.Model.GoodsInfo model = new Dong.Model.GoodsInfo();
            model = bll.GetModelById(int.Parse(this.Tag.ToString()));
            if(model!=null){
                this.tbxItemName.Text=model.GoodsName;
                this.keTuiShuLiang.Text=model.Counts.ToString();
            }
            


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证退货总额

            if (this.tuiHuoZongE.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入退货总额!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                keTuiShuLiang.Focus();
                return;
            }

            //验证退货数量
            if (tuiHuoShuLiang.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入退货数量!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tuiHuoShuLiang.Focus();
                return;
            }
            double price0;
            if (!double.TryParse(tuiHuoZongE.Text, out price0))
            {
                MessageBoxEx.Show("退货总额为数字!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tuiHuoZongE.Focus();
                return;
            }

            int tuihuoNum;
            if (!int.TryParse(tuiHuoShuLiang.Text, out tuihuoNum))
            {

                MessageBoxEx.Show("退货数量为整数!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tuiHuoShuLiang.Focus();
                return;
            }
            if(price0<=0){
                 MessageBoxEx.Show("退货总额为正数!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tuiHuoShuLiang.Focus();
                return;
            }
            if(tuihuoNum<1){
                 MessageBoxEx.Show("退货数量为正整数!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tuiHuoShuLiang.Focus();
                return;
            }
            

            Dong.BLL.GoodsInfo bll = new Dong.BLL.GoodsInfo();
            Dong.Model.GoodsInfo model = new Dong.Model.GoodsInfo();
            model = bll.GetModelById(int.Parse(this.Tag.ToString()));
            if (model == null)
            {
                MessageBoxEx.Show("该商品不存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tuiHuoShuLiang.Focus();
                return;
            }
            if(tuihuoNum>model.Counts){
                 MessageBoxEx.Show("退货数量不能超过库存数量!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tuiHuoShuLiang.Focus();
                return;
            }
            if(price0>model.Price2*model.Counts){
                 MessageBoxEx.Show("退货总额不能超过库存成本总额!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tuiHuoZongE.Focus();
                return;
            }
            

            //添加进货信息
            Dong.BLL.InGoods bInGoods = new Dong.BLL.InGoods();
            Dong.Model.InGoods mInGoods = new Dong.Model.InGoods();
            string input = "B" + DateTime.Now.ToString("yyyyMMddHHmmss");

            if (model.Counts == tuihuoNum)
            {
                
                mInGoods.Price = 0-model.Price2 * model.Counts;
                mInGoods.Counts = 0 - tuihuoNum;
                model.Counts = 0;
                model.Price2 = 0;
            }
            else
            {
                mInGoods.Price = 0 - price0;
                mInGoods.Counts = 0 - tuihuoNum;
                model.Price2 = (model.Price2 * model.Counts - price0) / (model.Counts - tuihuoNum);
                model.Counts = model.Counts - tuihuoNum;
                
                
            }
            mInGoods.PCode = input;
            mInGoods.GoodsCode = model.Code;
            
            mInGoods.IDate = DateTime.Now.Date;
            mInGoods.Oper = Dong.Model.GlobalsInfo.UserName;
            mInGoods.Supplier = model.Supplier;
            mInGoods.Remark = "进货退货";
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
