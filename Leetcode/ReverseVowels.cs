namespace Leetcode;

public class ReverseVowels
{
    public static string Run(string s)
    {
        var start = 0;
        var end = s.Length - 1;
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        var arr = s.ToCharArray();

        while (start < end)
        {
            while (start < s.Length && !vowels.Contains(arr[start]))
                start++;

            while (end >= 0 && !vowels.Contains(arr[end]))
                end--;

            if (start < end)
            {
                var t = arr[start];
                arr[start] = arr[end];
                arr[end] = t;

                start++;
                end--;
            }
        }

        return new string(arr);
    }
}