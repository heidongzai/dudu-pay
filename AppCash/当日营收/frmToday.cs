using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppCash
{
    public partial class frmToday : Form
    {
        public frmToday()
        {
            InitializeComponent();
        }

        private void frmToday_Load(object sender, EventArgs e)
        {
            //设置DataGridView的显示样式
            gvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvList.AutoGenerateColumns = false;
            CalcCash();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CalcCash();
        }

        private void CalcCash()
        {
            //计算当日的销售情况
            
            DataSet ds = new DataSet();
            Dong.BLL.SaleInfo bSaleInfo = new Dong.BLL.SaleInfo();
            ds = bSaleInfo.getToday(Dong.Model.GlobalsInfo.UserName);
            gvList.DataSource = ds.Tables[0];
            if (gvList.Rows.Count > 0)
            {
                double cash = 0;
                double Cash_ = 0;
                double Weixin_ = 0;
                double Alipay_ = 0;
                int c = 0;
                for (int i = 0; i < gvList.Rows.Count; i++)
                {
                    double price = double.Parse(gvList.Rows[i].Cells[2].Value.ToString());
                    cash = cash + price;

                    double price1 = double.Parse(gvList.Rows[i].Cells[3].Value.ToString());
                    Cash_ = Cash_ + price1;
                    double price2 = double.Parse(gvList.Rows[i].Cells[4].Value.ToString());
                    Weixin_ = Weixin_ + price2;
                    double price3 = double.Parse(gvList.Rows[i].Cells[5].Value.ToString());
                    Alipay_ = Alipay_ + price3;
                    int c1 = int.Parse(gvList.Rows[i].Cells[1].Value.ToString());
                    c = c + c1;
                }
                lblBCounts.Text = (gvList.Rows.Count - 1).ToString();
                lblGCounts.Text = c.ToString();
                lblPrice.Text = string.Format("{0:F2}", cash);
                lblCash.Text = string.Format("{0:F2}", Cash_);
                lblWeixin.Text = string.Format("{0:F2}", Weixin_);
                lblAlipay.Text = string.Format("{0:F2}", Alipay_);
            }
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void lblWeixin_Click(object sender, EventArgs e)
        {

        }

        private void gvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblAlipay_Click(object sender, EventArgs e)
        {

        }
    }
}
