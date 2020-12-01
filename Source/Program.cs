using AdventOfCode;
using System;

bool withStats = true;

foreach (var solution in SolutionRepository.GetAllSolutions())
{
    if (!string.IsNullOrWhiteSpace(solution.Title))
    {
        Console.WriteLine($"Day {solution.Day} | {solution.Title}");

        solution.ConsoleDump(withStats);
    }
}

Console.ReadLine();