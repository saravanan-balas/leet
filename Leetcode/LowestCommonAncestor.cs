namespace Leetcode;

public class LowestCommonAncestor
{
    public TreeNode Do(TreeNode root, TreeNode p, TreeNode q) {
        return dfs(root, p, q);  
    }

    TreeNode dfs(TreeNode node, TreeNode p, TreeNode q)
    {
        if (node == null)
            return null;

        if (node == p || node == q)
            return node;

        TreeNode left = dfs(node.left, p, q);
        TreeNode right = dfs(node.right, p, q);

        if (left != null && right != null)
        {
            return node;
        }

        if (left != null)
            return left;

        return right;
    }
}