namespace Leetcode;


public class TreePath {
    int diameter = 0;
    public int DiameterOfBinaryTree() {
        
        var one = new TreeNode(1);
        var two = new TreeNode(2);
        var three = new TreeNode(3);
        var four = new TreeNode(4);
        var five = new TreeNode(5);

        one.left = two;
        two.left = four;
        two.right = five;
        one.right = three;
        
        dfs(one);
        
        return diameter;
    }

    int dfs(TreeNode node)
    {
        if (node == null)
            return 0;

        int leftSubTree = dfs(node.left);
        int rightSubTree = dfs(node.right);
        
        Console.WriteLine(node?.val??0);   // 4 5 2 3 1  :: 
        
        diameter = Math.Max(diameter, leftSubTree + rightSubTree);
        return (Math.Max(leftSubTree, rightSubTree) + 1);
    }
}