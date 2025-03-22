namespace Leetcode;

public class TreeView
{
    public static void Do()
    {
        var root = new TreeNode { val = 1 };
        var left = new TreeNode { val = 2 };
        var right = new TreeNode { val = 3 };
        var r1 = new TreeNode { val = 4 };
        root.left = left;
        root.right = right;
        right.right = r1;
        r1.left = new TreeNode { val = 5 };

        RightSideView(root);
    }

    public static void RightSideView(TreeNode root) {

        var result = new List<int>();

        var currLevel = new Queue<TreeNode>();
        var nextLevel = new Queue<TreeNode>();
        
        TreeNode node = null;
        nextLevel.Enqueue(root);

        while (nextLevel.Count > 0)
        {
            currLevel = nextLevel;
            nextLevel = new Queue<TreeNode>();

            while (currLevel.Count > 0)
            {
                node = currLevel.Dequeue();

                if (node.left != null)
                    nextLevel.Enqueue(node.left);

                if (node.right != null)
                    nextLevel.Enqueue(node.right);
            }

            if (currLevel.Count == 0)
                result.Add(node.val);
        }

        foreach(var i in result)
            Console.WriteLine(i);
        
    }
}

public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
             this.val = val;
             this.left = left;
             this.right = right;
         }
 }