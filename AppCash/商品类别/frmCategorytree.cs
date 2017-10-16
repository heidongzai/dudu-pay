using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppCash
{
    public partial class frmCategorytree : Form
    {
        private DataTable dt = null;
        public frmCategorytree()
        {
            InitializeComponent();

        }

        private void frmCategorytree_Load(object sender, EventArgs e)
        {

            BindRoot();
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


        /// <summary>
        /// 添加子节点的方法
        /// </summary>
        public void addChildCode()
        {
            //首先判断是否选中节点中的位置
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择一个节点！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (textBox1.Text != "")
                {
                    //创建一个节点对象并初始化
                    TreeNode tmp = new TreeNode(textBox1.Text);
                    //在TreeView组件中加入子节点
                    treeView1.SelectedNode.Nodes.Add(tmp);
                    treeView1.SelectedNode = tmp;
                    treeView1.ExpandAll();
                }
                else
                {
                    MessageBox.Show("请填写类别名称！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }


        /// <summary>
        /// 添加兄弟节点的方法
        /// </summary>
        public void addBrother()
        {
            try
            {
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请选择一个节点！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (textBox1.Text != null)
                    {
                        //创建一个节点对象并且初始化
                        TreeNode tmp = new TreeNode(textBox1.Text);
                        //在TreeView 组件中加入兄弟节点
                        treeView1.SelectedNode.Parent.Nodes.Add(tmp);
                        treeView1.ExpandAll();
                    }
                    else
                    {
                        MessageBox.Show("请填写类别名称！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch
            {
                TreeNode rmp = new TreeNode("根节点");
                treeView1.Nodes.Add(rmp);
            }
        }


        /// <summary>
        /// 判断鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            //获取是否是鼠标右键点击
            if (e.Button == MouseButtons.Right)
            {
                //contextMenuStrip1.Show(this, new Point(e.X, e.Y));
            }
        }


        /// <summary>
        /// 展开下一节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择一个节点！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            treeView1.SelectedNode.Expand();
        }


        /// <summary>
        /// 展开全部节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //定位根节点
           // treeView1.SelectedNode = treeView1.Nodes[0];
            //展开组件中的所有节点
            //treeView1.SelectedNode.ExpandAll();
            foreach (TreeNode tn in treeView1.Nodes)
            {
                tn.ExpandAll();
            }
        }


        /// <summary>
        /// 折叠全部节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //定位根节点
            //treeView1.SelectedNode = treeView1.Nodes[0];
            //收缩组件中的所有节点
            //treeView1.SelectedNode.Collapse();
            foreach (TreeNode tn in treeView1.Nodes)
            {
                tn.Collapse();
            }
        }


        /// <summary>
        /// 点击快捷菜单中的“加入子节点”菜单项，则调用用户自定义的addChildCode()方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click2(object sender, EventArgs e)
        {
            addChildCode();
        }

        /// <summary>
        /// 点击快捷菜单中的“加入兄弟节点”菜单项，则调用用户自定义的addParent(方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click1(object sender, EventArgs e)
        {
            addBrother();
        }


        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Nodes.Count == 0)
            {
                treeView1.SelectedNode.Remove();
            }
            else
            {
                MessageBox.Show("请先删除此节点中的子节点！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void panelEx2_Click(object sender, EventArgs e)
        {

        }




      

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择一个节点！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Dong.Model.Category cModel = new Dong.Model.Category();
            Dong.BLL.Category bVip = new Dong.BLL.Category();

            cModel = bVip.GetModel(int.Parse(treeView1.SelectedNode.Name));
            if (cModel == null)
            {
                MessageBox.Show("添加失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmAddCategory fac = new frmAddCategory((int)cModel.Pid);
            //fac.MdiParent = this;
            fac.Show(this);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择一个节点！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmAddCategory fac = new frmAddCategory(int.Parse(treeView1.SelectedNode.Name));
            //fac.MdiParent = this;
            fac.Show(this);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择一个节点！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Dong.Model.Category cModel = new Dong.Model.Category();
           
            Dong.BLL.Category bVip = new Dong.BLL.Category();
            cModel = bVip.GetModel(int.Parse(treeView1.SelectedNode.Name));
            List < Dong.Model.Category> l=bVip.GetModelList(" 1=1 and Pid=" + int.Parse(treeView1.SelectedNode.Name));
            if(l.Count>0)
            { 
                MessageBox.Show("请先删除此节点中的子节点！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            Dong.BLL.GoodsInfo gi = new Dong.BLL.GoodsInfo();
            List<Dong.Model.GoodsInfo> gl = gi.GetModelList("1=1 and Category=" + int.Parse(treeView1.SelectedNode.Name));
            if (gl.Count > 0)
            {
                MessageBox.Show("有商品关联此类别，无法删除！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bVip.Delete(cModel.Id);
            MessageBox.Show("删除成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            int name = int.Parse(treeView1.SelectedNode.Name);
            String value = treeView1.SelectedNode.Text;
            this.textBox1.Text = value;
            
                //Dong.Model.Category cModel = new Dong.Model.Category();
                //Dong.BLL.Category bVip = new Dong.BLL.Category();

                //cModel = bVip.GetModel(name);
            
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("类别名称不得为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择一个节点！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Dong.Model.Category cModel = new Dong.Model.Category();
            Dong.BLL.Category bVip = new Dong.BLL.Category();
            int name = int.Parse(treeView1.SelectedNode.Name);
            cModel = bVip.GetModel(name);
            cModel.Name = this.textBox1.Text;
            bVip.Update(cModel);
            MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            treeView1.Nodes.Clear();
            BindRoot();
           
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            fresh_();
        }
        public void fresh_()
        {
            treeView1.Nodes.Clear();
            BindRoot();
        }
    }
}