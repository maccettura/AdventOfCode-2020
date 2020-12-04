using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day04
{
    public class Solution : BaseSolution
    {
        public Solution() : base(4, "Passport Processing")
        {
        }

        public override string GetPart1Answer()
        {
            var lines = GetResourceString().Split(Environment.NewLine);

            string[] keys = new[] { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };

            var validCount = GetValidCount(lines, Validate);

            return validCount.ToString();

            bool Validate(string passport)
            {
                return keys.All(passport.Contains);
            }    
        }
               
        public override string GetPart2Answer()
        {
            var lines = GetResourceString().Split(Environment.NewLine);

            var regexes = new[]
            {
                new Regex(@"byr:(19[2-9]\d|200[0-2])"),
                new Regex(@"iyr:(201\d|2020)"),
                new Regex(@"eyr:(202\d|2030)"),
                new Regex(@"hgt:(1[5-8]\dcm|19[0-3]cm|[5-6]\din|7[0-6]in)"),
                new Regex(@"hcl:#[0-9a-f]{6}"),
                new Regex(@"ecl:(amb|blu|brn|gry|grn|hzl|oth)"),
                new Regex(@"pid:[\d]{9}")
            };

            var validCount = GetValidCount(lines, Validate);

            return validCount.ToString();

            bool Validate(string passport)
            {
                foreach(var regex in regexes)
                {
                    if(!regex.Match(passport).Success)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private static int GetValidCount(string[] lines, Func<string, bool> validator)
        {
            int validCount = 0;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                sb.Append($"{lines[i]} ");
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    if (validator(sb.ToString()))
                    {
                        validCount++;
                    }
                    sb.Clear();
                    continue;
                }
            }

            return validCount;
        }
    }
}
