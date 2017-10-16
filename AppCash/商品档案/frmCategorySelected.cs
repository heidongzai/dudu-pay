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
    public partial class frmCategorySelected : Form
    {
        private DataTable dt = null;

        public frmCategorySelected()
        {
            InitializeComponent();
        }
        public string CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
        private string categoryName = "";
        private string categoryId = "";
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        //绑定根节点
        private void BindRoot()
        {
            Dong.BLL.Category bVip = new Dong.BLL.Category();
            dt = bVip.GetAllList().Tables[0];
            DataRow[] rows = dt.Select("Pid=0");//取根
            foreach (DataRow dRow in rows)
            {
                TreeNode rootNode = new TreeNode();
                rootNode.Tag = dRow;
                rootNode.Text = dRow["Name"].ToString();
                rootNode.Name = dRow["Id"].ToString();
                treeView1.Nodes.Add(rootNode);

                BindChildAreas(rootNode);
            }

        }

        //递归绑定子区域
        private void BindChildAreas(TreeNode fNode)
        {
            DataRow dr = (DataRow)fNode.Tag;//父节点数据关联的数据行
            int Pid = (int)dr["Id"]; //父节点ID
            DataRow[] rows = dt.Select("Pid=" + Pid);//子区域
            if (rows.Length == 0)  //递归终止，区域不包含子区域时
            {
                return;
            }

            foreach (DataRow dRow in rows)
            {
                TreeNode node = new TreeNode();
                node.Tag = dRow;
                node.Text = dRow["Name"].ToString();
                node.Name = dRow["Id"].ToString();
                //添加子节点
                fNode.Nodes.Add(node);
                //递归
                BindChildAreas(node);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCategorySelected_Load(object sender, EventArgs e)
        {
            BindRoot();
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //首先判断是否选中节点中的位置
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择一个类别！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //点击确定后
            categoryName = treeView1.SelectedNode.Text;
            categoryId = treeView1.SelectedNode.Name;
            this.DialogResult = DialogResult.OK;
            this.Close();
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in treeView1.Nodes)
            {
                tn.Collapse();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in treeView1.Nodes)
            {
                tn.ExpandAll();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            categoryName = "";
            categoryId = "";
            this.DialogResult = DialogResult.OK;
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }



    }
}
