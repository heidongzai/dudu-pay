using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppCash
{
    public partial class frmMoney : Form
    {
        public frmMoney()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
           // 焦点控件
            string jdkj= this.ActiveControl.Name;
            switch (keyData)
            {
                case Keys.Escape:
                    
                    this.Close();
                    return true;

                case Keys.Enter:
                    if (jdkj.Equals(this.tbPayCode.Name)) {
                        String totalFee = tbSSJE.Text;
                        Double totalFeeDoubleBy100 = Convert.ToDouble(totalFee) * Convert.ToDouble(100);
                        int totalFeeIntBy100 = Convert.ToInt32(totalFeeDoubleBy100);
                        string requestString="";
                        string payWay = "";
                        if (this.cbPayWay.SelectedIndex == 1) { 
                            payWay="weixinMicro";
                                                    }
                        else
                        {
                            payWay = "weixinMicro";
                            
                        }
                        requestString = "http://www.taiyuanecho.xyz/dudu-pay-web-sample-shop/duduPay/microPay?authCode=" + tbPayCode.Text + "&body=" + Dong.Model.GlobalsInfo.shopName + CommonUtility.GetRandomString(10, null) + "&key=" + Dong.Model.GlobalsInfo.key + "&attach=&outTradeNo=" + Dong.Model.GlobalsInfo.bill + "&totalFee=" + totalFeeIntBy100 + "&deviceInfo=" + Computer.Instance().GetHardWareInfo() + "&goodsTag=goodsTag&payWay="+payWay;

                        Console.WriteLine(requestString);
                        string r = AppCash.CommonUtility.GetInfo(requestString);
                        if (r != string.Empty) {
                            if (r.Equals("success"))
                            {
                                MessageBox.Show("支付成功!");
                            }
                            else if (r.Equals("nullFail"))
                            {
                                MessageBox.Show("支付失败[请求参数不全]!");
                            }
                            else if (r.Equals("payFail"))
                            {
                                MessageBox.Show("支付失败[支付异常]!");
                            }
                        Cash();
                        }
                        else
                        {
                            MessageBox.Show("支付失败!");
                        }
                    }else if(jdkj.Equals(this.cbPayWay.Name)){
                        if (this.cbPayWay.SelectedIndex == 0) {
                            Cash();
                        } else { SendKeys.Send("{tab}"); }
                        
                    }
                    else if (jdkj.Equals(this.tbSSJE.Name))
                    {
                        SendKeys.Send("{tab}");
                        SendKeys.Send("{tab}");
                        calculateZhaoling();
                    }
                    else if (jdkj.Equals(this.tbYS.Name))
                    {
                        SendKeys.Send("{tab}");
                    }
                    return true;
                //case Keys.D:
                //
                //    return true;
                //case Keys.F1:
                //    Form frmToday = new frmToday();
                //    frmToday.ShowDialog();
                //    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void frmMoney_Load(object sender, EventArgs e)
        {
            this.Show();
            this.TopMost = true;
            tbYS.Text = string.Format("{0:F2}", double.Parse(this.Tag.ToString()));
            tbYS.Focus();
        }

        private void tbSSJE_TextChanged(object sender, EventArgs e)
        {
            tbZL.Text = "";
        }

        protected void Cash()
        {
            if (tbZL.Text.Trim() == "")
            {
                tbZL.Text = string.Format("{0:F2}", (double.Parse(tbSSJE.Text.Trim()) - double.Parse(tbYS.Text.Trim())));
            }
            else
            {
                Dong.BLL.GoodsInfo bGoods = new Dong.BLL.GoodsInfo();
                Dong.BLL.SaleInfo bSale = new Dong.BLL.SaleInfo();
                Dong.Model.SaleInfo mSale = new Dong.Model.SaleInfo();

                frmCash frmP = (frmCash)this.Owner;
                DataGridView dgv = (DataGridView)frmP.Controls.Find("dGV", true)[0];
                for (int i = 0; i < dgv.Rows.Count; i++)
                {

                    //添加销售记录
                    double price = double.Parse(dgv.Rows[i].Cells[4].Value.ToString());
                    mSale.Pid = Dong.Model.GlobalsInfo.bill;
                    mSale.GoodsCode = dgv.Rows[i].Cells[0].Value.ToString();
                    mSale.Counts = int.Parse(dgv.Rows[i].Cells[3].Value.ToString());
                    mSale.Price = price;
                    mSale.PriceSum = double.Parse(tbYS.Text);
                    mSale.VipCode = Dong.Model.GlobalsInfo.vipCode;
                    mSale.Oper = Dong.Model.GlobalsInfo.UserName;
                    mSale.IDate = DateTime.Now;
                    bSale.Add(mSale);

                    //减少货物质量
                    bGoods.UpdateCount(int.Parse(dgv.Rows[i].Cells[3].Value.ToString()), dgv.Rows[i].Cells[0].Value.ToString());
                }

                frmP.ClearForm();
                frmP.showPre();
                this.Close();
            }
        }

        //计算找零
        protected void calculateZhaoling()
        {
            if (tbZL.Text.Trim() == "")
            {
                tbZL.Text = string.Format("{0:F2}", (double.Parse(tbSSJE.Text.Trim()) - double.Parse(tbYS.Text.Trim())));
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(e);
           // Console.WriteLine();
            int selectIndex=this.cbPayWay.SelectedIndex;
            if (selectIndex == 0)
            {
                this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
                this.tbPayCode.BackColor = System.Drawing.SystemColors.ControlDark;
                this.tbPayCode.ReadOnly = true;
                this.tbPayCode.Text = "";
            }else if(selectIndex == 1){
                this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
                this.tbPayCode.BackColor = System.Drawing.SystemColors.Window;
                this.tbPayCode.ReadOnly = false;
                this.tbPayCode.Text = "";
            }
            else if (selectIndex == 2)
            {
                this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
                this.tbPayCode.BackColor = System.Drawing.SystemColors.Window;
                this.tbPayCode.ReadOnly = false;
                this.tbPayCode.Text = "";
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
