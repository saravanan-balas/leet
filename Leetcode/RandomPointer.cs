namespace Leetcode;

public class RandomPointer
{
    public static void Do()
    {
        var fourth = new NodeR() { val = 4, next = null, random = null };
        var third =  new NodeR() {val = 3, next = fourth, random = null };
        var second = new NodeR() { val = 2, next = third, random = fourth };
        var first = new NodeR() { val = 1, next = second, random = third };
        
        third.random = first;
        fourth.random = second;

        NodeR head = first, curr = first;
        while (curr != null)
        {
            curr.Print();
            curr = curr.next;
        }

        var dict  = new Dictionary<NodeR, NodeR>();
        NodeR head2, curr2;
        curr = head;
        while (curr != null)
        {
            NodeR clone = new NodeR() { val = curr.val };
            dict.Add(curr, clone);
            curr = curr.next;
        }

        curr = head;
        while (curr != null)
        {
            if (curr.next != null)
            {
                dict[curr].next = dict[curr.next];
            }
            
            dict[curr].random = dict[curr.random];
            curr = curr.next;
        }

        head2 = dict[head];
        
        while (head2 != null)
        {
            head2.Print();
            head2 = head2.next;
        }
    }
}

public class NodeR
{
    public int val;
    public NodeR next;
    public NodeR random;

    public void Print()
    {
        int nextVal = next?.val ?? -999;
        Console.WriteLine($"{val} -> {nextVal} -> {random?.val}");
    }
}