using AdventOfCode.Properties;

namespace AdventOfCode
{
    public abstract class BaseSolution : ISolution
    {
        protected BaseSolution(int day, string title)
        {
            Day = day;
            Title = title;
        }

        public int Day { get; }

        public string Title { get; }

        public abstract string GetPart1Answer();

        public abstract string GetPart2Answer();

        protected string GetResourceString() => Resources.ResourceManager.GetString($"Day{Day:D2}");
    }
}