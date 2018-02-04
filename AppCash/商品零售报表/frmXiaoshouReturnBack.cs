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
    public partial class frmXiaoshouReturnBack : Form
    {
        String categoryName = "";
        String categoryId = "";
        public frmXiaoshouReturnBack()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmXiaoshouReturnBack_Load(object sender, EventArgs e)
        {
            Dong.BLL.SaleInfo bll = new Dong.BLL.SaleInfo();
            Dong.Model.SaleInfo model = new Dong.Model.SaleInfo();
            model = bll.GetModelById(int.Parse(this.Tag.ToString()));

            Dong.BLL.GoodsInfo bll2 = new Dong.BLL.GoodsInfo();
            Dong.Model.GoodsInfo model2 = new Dong.Model.GoodsInfo();
            
            if(model!=null){
                model2 = bll2.GetModel(model.GoodsCode);
                this.tbxItemName.Text = model2.GoodsName;
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

            Dong.BLL.SaleInfo bll = new Dong.BLL.SaleInfo();
            Dong.Model.SaleInfo model = new Dong.Model.SaleInfo();
            model = bll.GetModelById(int.Parse(this.Tag.ToString()));

            Dong.BLL.GoodsInfo bll2 = new Dong.BLL.GoodsInfo();
            Dong.Model.GoodsInfo model2 = new Dong.Model.GoodsInfo();
            model2 = bll2.GetModel(model.GoodsCode);

            
            if (model == null)
            {
                MessageBoxEx.Show("该商品不存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tuiHuoShuLiang.Focus();
                return;
            }
            if(tuihuoNum>model.Counts){
                 MessageBoxEx.Show("退货数量不能超过销售数量!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tuiHuoShuLiang.Focus();
                return;
            }
            if(price0>model.PriceSum){
                 MessageBoxEx.Show("退货总额不能超过销售总额!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tuiHuoZongE.Focus();
                return;
            }
            
            //修改商品库存数量
            model2.Counts = model2.Counts + tuihuoNum;
            

            //添加销售信息
            Dong.BLL.SaleInfo bSale = new Dong.BLL.SaleInfo();
            Dong.Model.SaleInfo mSale = new Dong.Model.SaleInfo();
            string pId = "B" + DateTime.Now.ToString("yyyyMMddHHmmss");
            mSale.Pid = pId;
            mSale.GoodsCode = model2.Code;

            mSale.Counts = 0 - tuihuoNum;
            mSale.Price = 0 - price0;
            mSale.PriceSum = 0 - price0;
            
            mSale.Oper = Dong.Model.GlobalsInfo.UserName;
            mSale.IDate = DateTime.Now;
            mSale.Alipay = 0;
            mSale.Weixin = 0;
            mSale.Cash = 0 - price0;
            mSale.Mark1 = "";
            mSale.Mark2 = "";
            mSale.Mark3 = 0;
            mSale.VipCode = "";

 

            if(
            bSale.Add(mSale))
            {
                if (bll2.Update(model2))
                {
                    MessageBoxEx.Show("操作成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmReport1 frm = (frmReport1)this.Owner;
                    frm.refreshData();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBoxEx.Show("操作失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.tuiHuoZongE.Focus();
                    return;
                }
            }
            else
            {
                MessageBoxEx.Show("操作失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tuiHuoZongE.Focus();
                return;
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
