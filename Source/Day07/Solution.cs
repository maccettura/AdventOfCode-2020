using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day07
{
    public class Solution : BaseSolution
    {
        public Solution() : base(7, "Handy Haversacks")
        {
        }

        public override string GetPart1Answer()
        {
            var bags = ParseInput();
            return bags.Keys.Count(b => CanContain(bags, b, "shiny gold")).ToString();

            static bool CanContain(Dictionary<string, IEnumerable<(string name, int count)>> bags, string containingColor, string containedColor)
            {
                return bags[containingColor].Any(b => b.name == containedColor || CanContain(bags, b.name, containedColor));
            }
        }

        public override string GetPart2Answer()
        {
            var bags = ParseInput();
            return BagCount(bags, "shiny gold").ToString();

            static int BagCount(Dictionary<string, IEnumerable<(string name, int count)>> bags, string containingColor)
            {
                return bags[containingColor].Sum(b => b.count + b.count * BagCount(bags, b.name));
            }
        }

        private static readonly Regex _parentBagParse = new Regex(@"(.*) bags contain (.*).");
        private static readonly Regex _subBagParse = new Regex(@"(\d+) (.*) bag");

        private Dictionary<string, IEnumerable<(string name, int count)>> ParseInput()
        {
            var lines = GetResourceString().Split(Environment.NewLine);

            var bags = new Dictionary<string, IEnumerable<(string name, int count)>>();

            foreach (var line in lines)
            {
                var match = _parentBagParse.Match(line);
                bags.Add(match.Groups[1].Value, ParseChild(match.Groups[2].Value));
            }

            return bags;
        }

        private static IEnumerable<(string name, int count)> ParseChild(string input)
        {
            var output = new List<(string name, int count)>();
            foreach(var i in input.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                if(i.Contains("no other bags"))
                {
                    continue;
                }
                var match = _subBagParse.Match(i);
                if(match.Success)
                {
                    output.Add((match.Groups[2].Value, int.Parse(match.Groups[1].Value)));
                }                
            }
            return output;
        }
    }
}
