using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day08
{
    public class Solution : BaseSolution
    {
        public Solution() : base(8, "Handheld Halting")
        {
        }

        private static readonly Regex _lineParser = new Regex(@"(\w+) (-?\+?\d+)");

        public override string GetPart1Answer()
        {
            var lines = GetResourceString().Split(Environment.NewLine);
            var (_, accumulate) = Compute(lines);
            return accumulate.ToString();                        
        }

        public override string GetPart2Answer()
        {
            var lines = GetResourceString().Split(Environment.NewLine);

            for(int i = 0; i < lines.Length; i++)
            {                
                var tempLines = new string[lines.Length];
                Array.Copy(lines, tempLines, tempLines.Length);

                if(tempLines[i].StartsWith("nop"))
                {
                    tempLines[i] = tempLines[i].Replace("nop", "jmp");
                }
                else if(tempLines[i].StartsWith("jmp"))
                {
                    tempLines[i] = tempLines[i].Replace("jmp", "nop");
                }

                var (infinite, accumulate) = Compute(tempLines);
                if (!infinite)
                {
                    return accumulate.ToString();
                }
            }

            return string.Empty;
        }

        private static (bool infinite, int accumulate) Compute(string[] lines)
        {
            var operations = new HashSet<int>();
            int lineIndex = 0;
            int accumulator = 0;
            do
            {
                if (operations.Contains(lineIndex))
                {
                    return (true, accumulator);
                }
                operations.Add(lineIndex);

                var match = _lineParser.Match(lines[lineIndex]);
                string op = match.Groups[1].Value;

                if (op == "acc")
                {
                    accumulator += int.Parse(match.Groups[2].Value);
                    lineIndex += 1;
                }
                else if (op == "jmp")
                {
                    int jmp = int.Parse(match.Groups[2].Value);
                    lineIndex += jmp;
                }
                else if (op == "nop")
                {
                    lineIndex += 1;
                }

                if (lineIndex == lines.Length)
                {
                    return (false, accumulator);
                }
            }
            while (true);
        }
    }
}
