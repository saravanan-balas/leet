namespace Leetcode;

public class Words
{
    List<string> map = new List<string>()
    {
        "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"
    };

    List<string> result = new List<string>();

    public static void Do()
    {
        var i = new Words();
        foreach(var word in i.LetterCombinations("23"))
            Console.WriteLine(word);
    }

    public IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits))
            return result;

        backtrack(0, digits, new List<char>());
        return result;
    }

    void backtrack(int i, string d, List<char> temp)
    {
        string t = new string(temp.ToArray());
        if (temp.Count == d.Length)
        {
            result.Add(t);
            Console.WriteLine(t);
            return;
        }

        int num = int.Parse(d[i].ToString());

        var possibleLetters = map[num];
        foreach (var c in possibleLetters)
        {
            temp.Add(c);
            backtrack(i + 1, d, temp);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}