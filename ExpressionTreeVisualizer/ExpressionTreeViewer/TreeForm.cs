using System.Windows.Forms;

namespace ExpressionTreeViewer
{
    public partial class TreeForm : Form
    {
        public TreeForm()
        {
            InitializeComponent();
        }

        public void RenderExpression(ExpressionTreeNode node)
        {
            expressionTreeView.Nodes.Add(GetTreeNode(node));
            expressionTreeView.ExpandAll();
        }

        private TreeNode GetTreeNode(ExpressionTreeNode node)
        {
            var treeNode = new TreeNode(node.Text);
            node.Nodes.ForEach(n=> treeNode.Nodes.Add(this.GetTreeNode(n)));
            return treeNode;
        }
    }
}
