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
                        Double totalFeeDoubleBy100 = Convert.ToDouble(totalFee) * Convert.ToDouble(1);
                        //int totalFeeIntBy100 = Convert.ToInt32(totalFeeDoubleBy100);
                        string requestString="";
                        //支付方式，存放WEIXIN和ALIPAY两个字段
                        string payWayCode = "";
                        string payType = "";
                        if (this.cbPayWay.SelectedIndex == 1) {
                            payWayCode = "WEIXIN";
                            payType = "WEIXIN_MICROPAY";
                                                    }
                        if (this.cbPayWay.SelectedIndex == 2)
                        {
                            payWayCode = "ALIPAY";
                            payType = "ALIPAY_F2FPAY";
                            
                        }
                        //获取支付账户
                        //Dong.BLL.Dictionary bAccountNo = new Dong.BLL.Dictionary();
                        //Dong.Model.Dictionary mAccountNo = new Dong.Model.Dictionary();
                        //string strSql_AccountNo = "KeyStr = 'AccountNo'";
                        //String AccountNo = "";
                        //List<Dong.Model.Dictionary> AccountNoList = bAccountNo.GetModelList(strSql_AccountNo);
                        //if (AccountNoList.Count != 0)
                        //{
                        //    mAccountNo = AccountNoList[0];
                        //    if (!string.IsNullOrEmpty(mAccountNo.ValueStr))
                        //    {
                        //        AccountNo = mAccountNo.ValueStr;
                        //    }
                        //}
                        string AccountNo=CommonUtility.ReadReader("duduCasherDB/an.dll",  "2");
                        String outTradeNo=Dong.Model.GlobalsInfo.bill;
                        if (payTimes > 0)
                        {
                            outTradeNo = outTradeNo + "_" + payTimes;
                        }
                        requestString = "http://www.taiyuanecho.xyz/dudu-pay-web-gateway/microPay/doPay?authCode=" + tbPayCode.Text + "&body=" + CommonUtility.UrlEncode(Dong.Model.GlobalsInfo.shopName) + CommonUtility.GetRandomString(10, null) + "&miwen=" + Dong.Model.GlobalsInfo.key + "&attach=&outTradeNo=" + outTradeNo + "&totalFee=" + totalFeeDoubleBy100 + "&deviceInfo=" + Computer.Instance().GetHardWareInfo() + "&goodsTag=goodsTag&payWayCode=" + payWayCode + "&payType=" + payType + "&userNo=" + AccountNo;

                        Console.WriteLine(requestString); 
                       // Console.WriteLine(CommonUtility.UrlEncode(requestString));
                        string r=null;
                        try {
                            r = AppCash.CommonUtility.GetInfo(requestString);
                        }catch(Exception e){
                            Console.WriteLine(e.Message);
                            MessageBox.Show("请求失败，请检查网络连接或联系软件管理员!");
                        

                        }
                        
                        if (!string.IsNullOrEmpty(r))
                        {
                            if (r.Equals("success"))
                            {
                                MessageBox.Show("支付成功!");
                                Check_Cash();
                            }

                            else
                            {
                                MessageBox.Show("支付失败![" + r + "]");
                                Dong.Model.GlobalsInfo.bill = Dong.Model.GlobalsInfo.bill + DateTime.Now.Second.ToString();
                                this.tbPayCode.Text = "";
                                cbPayWay.Focus();
                            }
                        
                        }
                        else
                        {
                            MessageBox.Show("支付失败![返回结果为空]");
                            Dong.Model.GlobalsInfo.bill = Dong.Model.GlobalsInfo.bill + DateTime.Now.Second.ToString();
                            this.tbPayCode.Text = "";
                            cbPayWay.Focus();
                        }
                    }else if(jdkj.Equals(this.cbPayWay.Name)){
                        if (this.cbPayWay.SelectedIndex == 0) {
                            Check_Cash();
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
                        tbSSJE.Text = tbYS.Text;
                        //修改剩余应付金额
                        syyf = double.Parse(tbYS.Text);
                        tbSSJE.SelectAll();
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
            tbYS.SelectAll();
        }

        private void tbSSJE_TextChanged(object sender, EventArgs e)
        {
            tbZL.Text = "";
        }


        private void Check_Cash()
        {
            //首先更新已收金额
            yishou=yishou+double.Parse(tbSSJE.Text.Trim());

            //更新 微信 支付宝 现金 支付金额
            if (this.cbPayWay.SelectedIndex ==0)
            {
                Cash_ = Cash_ + double.Parse(tbSSJE.Text.Trim());
            }
            if (this.cbPayWay.SelectedIndex == 1)
            {
                Weixin_ = Weixin_ + double.Parse(tbSSJE.Text.Trim());
            }
            if (this.cbPayWay.SelectedIndex == 2)
            {
                Alipay_ = Alipay_ + double.Parse(tbSSJE.Text.Trim());
            }
            //更新收银支付次数
            payTimes = payTimes + 1;
            //如果已收金额大于等于应收金额，则返回1，结束本次收银
            if (yishou >= double.Parse(tbYS.Text.Trim()))
            {
                
                
                Cash();
            }
            //如果已收金额小于应收金额，则将应收金额冻结，将找回金额显示为剩余应付，将实收金额标签改为再次支付
            //并将金额默认置为剩余应付金额，返回0
            else{
                tbYS.ReadOnly = true;
                tbSSJE.Text = syyf.ToString();
                label1.Text = "再次支付";
                label1.ForeColor = System.Drawing.Color.Red;
                tbSSJE.Focus();
                tbSSJE.SelectAll();
                cbPayWay.SelectedIndex = 0;
                tbPayCode.BackColor = System.Drawing.SystemColors.ControlDark;
                tbPayCode.ReadOnly = true;
                tbPayCode.Text = "";
                calculateZhaoling();
            }
        }

        protected void Cash()
        {
            //if (tbZL.Text.Trim() == "")
            //{
            //    tbZL.Text = string.Format("{0:F2}", (double.Parse(tbSSJE.Text.Trim()) - double.Parse(tbYS.Text.Trim())));
            //}
            //else
            //{
                Dong.BLL.GoodsInfo bGoods = new Dong.BLL.GoodsInfo();
                Dong.BLL.SaleInfo bSale = new Dong.BLL.SaleInfo();
                Dong.Model.SaleInfo mSale = new Dong.Model.SaleInfo();
                double sumPrice = 0;
            
                
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
                    mSale.Alipay = Alipay_;
                    mSale.Weixin = Weixin_;
                    mSale.Cash = Cash_;
                    mSale.Mark1 = "";
                    mSale.Mark2 = "";
                    mSale.Mark3 = 0;
                    bSale.Add(mSale);
                   
                    //减少货物质量
                    bGoods.UpdateCount(int.Parse(dgv.Rows[i].Cells[3].Value.ToString()), dgv.Rows[i].Cells[0].Value.ToString());
                //}

                frmP.ClearForm();
                frmP.showPre();
                    
                
            }
                //更新vip积分
                Dong.BLL.MemberInfo bMember = new Dong.BLL.MemberInfo();
                Dong.Model.MemberInfo mMember = null;
                if (!String.IsNullOrEmpty(Dong.Model.GlobalsInfo.vipCode))
                {
                    
                    mMember = bMember.GetModel(Dong.Model.GlobalsInfo.vipCode);
                   
                    if (mMember != null)
                    {

                        Console.WriteLine("2:" + mMember.iMoney + "|" + double.Parse(tbYS.Text) + Dong.Model.GlobalsInfo.vipCode + "|" + mMember.IdCode);
                        mMember.iMoney = mMember.iMoney + double.Parse(tbYS.Text);
                        bMember.Update(mMember);
                        Console.WriteLine("5:" + "保存完毕");
                    }
                    else
                    {
                        Console.WriteLine("3:" + Dong.Model.GlobalsInfo.vipCode);
                    }

                }
                
                
                //重置会员信息和会员折扣
                Dong.Model.GlobalsInfo.vipCode = "";
                Dong.Model.GlobalsInfo.vipZK = 1;
                frmP.lblVip.Text = "";
                this.Close();
        }

        //计算找零
        protected void calculateZhaoling()
        {
            //如果已收金额小于剩余应付金额，则将应收金额冻结，将找回金额显示为剩余应付，将实收金额标签改为再次支付
            if (double.Parse(tbSSJE.Text.Trim()) >= syyf)
            {
                tbZL.Text = string.Format("{0:F2}", (double.Parse(tbSSJE.Text.Trim()) - syyf));
                label2.Text = "找零金额";
                label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            }
            else
            {
                label2.Text = "剩余待付";
                label2.ForeColor = System.Drawing.Color.Red;
                tbZL.Text = string.Format("{0:F2}", syyf-double.Parse(tbSSJE.Text.Trim()));
                syyf = syyf - double.Parse(tbSSJE.Text.Trim());

            }


            //if (tbZL.Text.Trim() == "")
            //{
            //    tbZL.Text = string.Format("{0:F2}", (double.Parse(tbSSJE.Text.Trim()) - double.Parse(tbYS.Text.Trim())));
            //}
            
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
