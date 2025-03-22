namespace Leetcode;

public class MultiplyStrings
{
    private List<int> SumResults(List<List<int>> results)
    {
        // Initialize answer as a number from results.
        var answer = new List<int>(results[results.Count - 1]);
        List<int> newAnswer;
        for (var j = 0; j < results.Count - 1; ++j)
        {
            var result = new List<int>(results[j]);
            newAnswer = new List<int>();
            var carry = 0;
            for (var i = 0; i < answer.Count || i < result.Count; ++i)
            {
                var digit1 = i < result.Count ? result[i] : 0;
                var digit2 = i < answer.Count ? answer[i] : 0;
                var sum = digit1 + digit2 + carry;
                carry = sum / 10;
                newAnswer.Add(sum % 10);
            }

            if (carry != 0) newAnswer.Add(carry);

            answer = newAnswer;
        }

        return answer;
    }

    private List<int> MultiplyOneDigit(char[] firstNumber,
        char secondNumberDigit, int numZeros)
    {
        var currentResult = Enumerable.Repeat(0, numZeros).ToList();
        var carry = 0;
        for (var i = 0; i < firstNumber.Length; i++)
        {
            var multiplication =
                (secondNumberDigit - '0') * (firstNumber[i] - '0') + carry;
            carry = multiplication / 10;
            currentResult.Add(multiplication % 10);
        }

        if (carry != 0) currentResult.Add(carry);

        return currentResult;
    }

    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0") return "0";

        var firstNumber = num1.ToCharArray();
        Array.Reverse(firstNumber);
        var secondNumber = num2.ToCharArray();
        Array.Reverse(secondNumber);
        List<List<int>> results = new List<List<int>>();
        for (var i = 0; i < secondNumber.Length; ++i) results.Add(MultiplyOneDigit(firstNumber, secondNumber[i], i));

        var answer = SumResults(results);
        return string.Join(
            "", answer.Select(t => t.ToString()).ToArray().Reverse());
    }
}