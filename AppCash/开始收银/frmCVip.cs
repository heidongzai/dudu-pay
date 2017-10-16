using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppCash
{
    public partial class frmCVip : Form
    { 
        public frmCVip()
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
                    if (jdkj.Equals(this.tbVipCode.Name)) {
                        if (!CommonUtility.IsMobile(tbVipCode.Text.Trim()))
                        {
                            MessageBox.Show("请输入正确的手机号!");
                            this.tbVipCode.Text = "";
                            this.tbVipCode.Focus();
                            return true;
                        }
                        if (tbVipCode.Text.Trim()!="")
                        {
                            Dong.BLL.MemberInfo bMember = new Dong.BLL.MemberInfo();
                            Dong.Model.MemberInfo mMember = new Dong.Model.MemberInfo();
                            mMember = bMember.GetModel(tbVipCode.Text);
                            if (mMember == null)
                            {
                                MessageBox.Show("无此会员，立即创建(详细资料可稍后填写)!");
                                this.tbVipName.ReadOnly = false;
                                this.tbVipName.Focus();
                                this.label2.Text="创建会员";
                                return true;
                            }
                            else
                            {
                                tbVipName.Text = mMember.Name;
                                Dong.Model.GlobalsInfo.vipZK = mMember.Discount;
                                Dong.Model.GlobalsInfo.vipCode = tbVipCode.Text;
                                frmCash frmP = (frmCash)this.Owner;
                                frmP.sumCash();
                                this.tbVipName.Focus();
                            }
                        }
                    }
                    else if (jdkj.Equals(this.tbVipName.Name))
                    {
                        
                        //姓名不得为空
                        if (tbVipName.Text.Trim() == "")
                        {
                            MessageBox.Show("姓名不得为空!");
                            return true;
                        }
                        //开始创建会员
                        

                        Dong.BLL.MemberInfo bMember = new Dong.BLL.MemberInfo();
                        //如已存在改会员手机号，则不创建
                        if (bMember.GetModel(tbVipCode.Text) != null)
                        {
                            this.Close();
                            return true;
                        }
                        Dong.Model.MemberInfo mMember = new Dong.Model.MemberInfo();
                        mMember.IdCode = tbVipCode.Text;
                        mMember.Name = tbVipName.Text;
                        mMember.Birthday=DateTime.Parse("1900-1-1");
                        mMember.Addr = "无";
                        mMember.Discount = double.Parse("1");
                        mMember.Oper = Dong.Model.GlobalsInfo.UserName;
                        mMember.OperDate = DateTime.Now;
                        mMember.iMoney = double.Parse("0");
                        mMember.Email = "无";
                        mMember.Stime = DateTime.Parse("1900-1-1");
                        mMember.Etime = DateTime.Parse("1900-1-1");

                        if (bMember.Add(mMember))
                        {
                            tbVipName.Text = mMember.Name;
                            Dong.Model.GlobalsInfo.vipZK = mMember.Discount;
                            Dong.Model.GlobalsInfo.vipCode = tbVipCode.Text;
                            frmCash frmP = (frmCash)this.Owner;
                            frmP.sumCash();
                            this.tbVipName.Focus();

                            MessageBox.Show("创建成功!");
                        }
                        else
                        {
                            MessageBox.Show("创建失败!");
                        }

                        this.Close();
                        return true;
                    }
                    return true;
                
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void frmVip_Load(object sender, EventArgs e)
        {
            this.Show();
            this.TopMost = true;
        }

        private void tbVipCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbVipName_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
