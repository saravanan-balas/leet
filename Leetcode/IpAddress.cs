namespace Leetcode;

public class IpAddress
{
    public string ValidIPAddress(string queryIP)
    {
        if (queryIP.Contains('.'))
            return ValidateIPV4(queryIP);
        if (queryIP.Contains(':'))
            return ValidateIPV6(queryIP);

        return "Neither";
    }

    private string ValidateIPV6(string ip)
    {
        var tokens = ip.Split(':');
        var map = new HashSet<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F' };
        for (int i = 0; i <= 9; i++)
        {
            Console.WriteLine((char)('0' +i));
            map.Add((char)('0' +i));
        }

        if (tokens.Length != 8)
            return "Neither";

        foreach (var token in tokens)
        {
            if (token.Length == 0 || token.Length > 4)
                return "Neither";

            foreach (var c in token)
                if (!map.Contains(c))
                    return "Neither";
        }

        return "IPv6";
    }

    private string ValidateIPV4(string ip)
    {
        var tokens = ip.Split('.');

        if (tokens.Length != 4)
            return "Neither";

        foreach (var token in tokens)
        {
            if (token.Length == 0 || token.Length > 3)
                return "Neither";

            foreach (var c in token)
                if (!char.IsNumber(c))
                    return "Neither";

            var num = int.Parse(token);
            if (num > 255)
                return "Neither";
        }

        return "IPv4";
    }
}