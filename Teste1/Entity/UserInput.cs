﻿using System.Text;
using System.Text.RegularExpressions;
using Teste1.Constants;
using Teste1.Helper;

namespace Teste1.Entity
{
    internal static partial class UserInput
    {
        public static string RequestInput()
        {
            string input;

            do
            {
                Console.WriteLine(ConsoleMessage.InputRequest);
                input = Console.ReadLine()!;
            } while (string.IsNullOrEmpty(input) || MyRegex().IsMatch(input));

            return input;
        }

        public static StringBuilder ReturnInputWithoutDuplicates(string input)
        {
            HashSet<char> charsControl = [];
            StringBuilder result = new();

            var uniqueChars = input
                .ToUpper()
                .Distinct()
                .Where(c => charsControl.Add(c))
                .ToList();

            return result.AppendJoin("", uniqueChars);
        }

        [GeneratedRegex(RegexPattern.SpacesPattern)]
        private static partial Regex MyRegex();
    }
}