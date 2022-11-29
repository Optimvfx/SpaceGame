using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class RequestParser
{
    private static readonly List<char> _spleatChar = new List<char>(new[] { '{', '}', '[', ']' });
    private static readonly List<char> _removeChar = new List<char>(new[] { ',' });

    public static List<string> Parse(string from)
    {
        var result = new List<string>();

        from = from.Replace(" ", "").Replace("\n", "").Replace("\t", " ").Replace(((char)(13)).ToString(), "");

        for (int i = 0; i < from.Length; i++)
        {
            var currentString = new StringBuilder();

            while ((_spleatChar.Contains(from[i]) || _removeChar.Contains(from[i])) == false && i < from.Length)
            {
                currentString.Append(from[i]);
                i++;
            }

            if (currentString.Length > 0)
                result.Add(currentString.ToString());

            if (_spleatChar.Contains(from[i]))
                result.Add(from[i].ToString());
        }

        return result;
    }
}
