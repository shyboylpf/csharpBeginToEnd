// See https://aka.ms/new-console-template for more information
string[] words = new string[]
{
    // index from start    index from end
    "The",      // 0                   ^9
    "quick",    // 1                   ^8
    "brown",    // 2                   ^7
    "fox",      // 3                   ^6
    "jumps",    // 4                   ^5
    "over",     // 5                   ^4
    "the",      // 6                   ^3
    "lazy",     // 7                   ^2
    "dog"       // 8                   ^1
};              // 9 (or words.Length) ^0
string word2 = "abcdefg";
Console.WriteLine($"The last word is {words[^1]}");
Console.WriteLine($"The last word2 is {word2[..^1]}");

string[] quickBrownFox = words[1..4];
foreach (var word in quickBrownFox)
    Console.Write($"< {word} >");
Console.WriteLine();

string[] lazyDog = words[^2..^0];
foreach (var word in lazyDog)
    Console.Write($"< {word} >");
Console.WriteLine();

Index the = ^3;
Console.WriteLine($"The last word2 is {word2[..the]}");


Console.WriteLine("Hello, World!");
