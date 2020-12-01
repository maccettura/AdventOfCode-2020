using AdventOfCode;
using System;
using System.Diagnostics;

bool withStats = true;

foreach (var solution in SolutionRepository.GetAllSolutions())
{
    if (!string.IsNullOrWhiteSpace(solution.Title))
    {
        Console.WriteLine($"Day {solution.Day} | {solution.Title}");

        if(withStats)
        {
            AnswerWithStats(solution);
        }
        else
        {
            Answer(solution);
        }

    }
}

Console.ReadLine();

//Methods

void AnswerWithStats(ISolution solution)
{
    var sw = new Stopwatch();

    sw.Start();
    var answer1 = solution.GetPart1Answer();
    sw.Stop();
    Console.WriteLine($"Solution Part 1: {answer1} | Time: {sw.Elapsed}");

    sw.Reset();
    sw.Start();
    var answer2 = solution.GetPart2Answer();
    sw.Stop();
    Console.WriteLine($"Solution Part 2: {answer2} | Time: {sw.Elapsed}");
}

void Answer(ISolution solution)
{
    Console.WriteLine($"Solution Part 1: {solution.GetPart1Answer()}");
    Console.WriteLine($"Solution Part 2: {solution.GetPart2Answer()}");
}