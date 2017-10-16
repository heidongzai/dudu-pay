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
    public partial class frmAddVip : Form
    {
        public frmAddVip()
        {
            InitializeComponent();
        }

        #region ------退出------
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ------保存------
        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证用户手机号
            if (tbCode.Text.Trim() == "")
            {
                
                MessageBoxEx.Show("请输入手机号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbCode.Focus();
                return;
            }else if(!CommonUtility.IsMobile(tbCode.Text.Trim())){
                MessageBoxEx.Show("请输入正确的手机号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbCode.Focus();
                return;
            }
            //验证用户姓名
            if (tbName.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入会员姓名!","提示", MessageBoxButtons.OK,MessageBoxIcon.Error);
                tbName.Focus();
                return;
            }

            //if (cbStime.Text.Trim() == "")
            //{
            //    MessageBoxEx.Show("请输入会员的开始时间!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cbStime.Focus();
            //    return;
            //}

            //if (cbEtime.Text.Trim() == "")
            //{
            //    MessageBoxEx.Show("请输入会员的结束时间!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cbEtime.Focus();
            //    return;
            //}

            if (tbDiscount.Text.Trim() == "")
            {
                MessageBoxEx.Show("请输入会员享受的折扣!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbDiscount.Focus();
                return;
            }

            Dong.BLL.MemberInfo bMember = new Dong.BLL.MemberInfo();
            Dong.Model.MemberInfo mMember = new Dong.Model.MemberInfo();
            mMember.IdCode = tbCode.Text;
            mMember.Name = tbName.Text;

            if (cbStime.Text != "")
            {
                mMember.Stime = DateTime.Parse(cbStime.Text);
            }
            else
            {
                mMember.Stime = DateTime.Parse("1900-1-1");
            }
            if (cbEtime.Text != "")
            {
                mMember.Etime = DateTime.Parse(cbEtime.Text);
            }
            else
            {
                mMember.Etime = DateTime.Parse("1900-1-1");
            }
            if (tbEmail.Text != "")
            {
                mMember.Email = tbEmail.Text;
            }
            else
            {
                mMember.Email = "无";
            }
            if (tbAddr.Text != "")
            {
                mMember.Addr = tbAddr.Text;
            }
            else
            {
                mMember.Addr = "无";
            }
            if (tbBirthday.Text != "")
            {
                mMember.Birthday = DateTime.Parse(tbBirthday.Text);
            }
            else
            {
                mMember.Birthday = DateTime.Parse("1900-1-1");
            }
            mMember.Discount = double.Parse(tbDiscount.Text);
            mMember.Oper = Dong.Model.GlobalsInfo.UserName;
            mMember.OperDate = DateTime.Now;
            mMember.iMoney = double.Parse(tbIMoney.Text);

            if (bMember.Add(mMember))
            {
                MessageBoxEx.Show("添加成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmVip fvip = (frmVip)this.Owner;
                fvip.refreshData();
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("保存失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ------窗体加载------
        private void frmAddVip_Load(object sender, EventArgs e)
        {
            //tbCode.Text = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        #endregion

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void tbCode_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
