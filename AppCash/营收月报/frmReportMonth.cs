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
    public partial class frmReportMonth : Form
    {
        public frmReportMonth()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbYear.Text != "")
            {
                fillGVList(cbYear.Text);
            }
            else
            {
                MessageBoxEx.Show("年份不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
            }
        }

        private void frmReportMonth_Load(object sender, EventArgs e)
        {
            //设置DataGridView的显示样式
            gvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gvList.AutoGenerateColumns = false;
        }
        #region ------填出datagridview------
        private void fillGVList(string key)
        {

            Dong.BLL.SaleInfo bll = new Dong.BLL.SaleInfo();
            DataTable dt = new DataTable();
            dt = bll.getMonthRePort(key);
            gvList.DataSource = dt;
            int count = 0;
            double price = 0;
            double priceCash = 0;
            double priceWeixin = 0;
            double priceAlipay = 0;
            double gain = 0;
            foreach (DataRow dr in dt.Rows)
            {
                count += int.Parse(dr[0].ToString());
                price += double.Parse(dr[1].ToString());
                gain += double.Parse(dr[2].ToString());
                priceCash += double.Parse(dr[3].ToString());
                priceWeixin += double.Parse(dr[4].ToString());
                priceAlipay += double.Parse(dr[5].ToString());
            }
            lblCount.Text = count.ToString();
            lblXSZE.Text = string.Format("{0:F2}",price);
            lblGain.Text = string.Format("{0:F2}",gain);
            lblCash.Text = string.Format("{0:F2}",priceCash);
            lblWeixin.Text = string.Format("{0:F2}",priceWeixin);
            lblAlipay.Text = string.Format("{0:F2}",priceAlipay);
        }
        #endregion

        private void gvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void lblXSZE_Click(object sender, EventArgs e)
        {

        }

        private void lblWeixin_Click(object sender, EventArgs e)
        {

        }
    }
}
