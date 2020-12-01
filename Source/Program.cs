using AdventOfCode;
using System;

const bool withStats = true;

foreach (var solution in SolutionRepository.GetAllSolutions())
{
    if (!string.IsNullOrWhiteSpace(solution.Title))
    {
        solution.ConsoleDump(withStats);
    }
}

Console.ReadLine();