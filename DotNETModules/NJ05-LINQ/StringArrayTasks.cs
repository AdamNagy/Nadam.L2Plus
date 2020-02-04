using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJ05_LINQ
{
    public static class StringArrayTasks
    {
        private static readonly string[] strings =
{
            "You only live forever in the lights you make",
            "When we were young we used to say",
            "That you only hear the music when your heart begins to break",
            "Now we are the kids from yesterday",
            "ca cab cat bolt bab bottom after alter"
        };

        public static void Run()
        {
            WordCounts();
            Vowels();
            LongestWord();
            AvgWordCount();
            RemoveDuplicates();
        }

        private static void WordCounts()
        {
            var counts = strings
                .Select(sentence => sentence.Split(' '))
                .Select(words => words.Count())
                .ToList();

            foreach (var count in counts)
                Console.Write($"{count} ");

            Console.WriteLine();
        }

        private static void Vowels()
        {
            var VOWELS = new List<char> { 'a', 'e', 'i', 'o', 'u' };

            var selected = strings.Select(sentence => sentence.Split(' '))
                .Select(words =>
                    words.Where(word => VOWELS.Contains(word[0])));

            foreach (var words in selected)
            {
                foreach (var word in words)
                    Console.Write($"{word} ");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void LongestWord()
        {
            var flatenned = strings
                .Select(sentence => sentence.Split(' '))
                .SelectMany(words => words);

            var longest = flatenned.MaxByProperty(p => p.Length);
            Console.Write($"longest: {longest} \n");
        }

        private static void AvgWordCount()
        {
            var avgWordCount = strings
                .Select(sentence => sentence.Split(' '))
                .Select(words => words.Count())
                .Average();

            Console.WriteLine($"Avarage word count: {avgWordCount}\n");
        }

        private static void RemoveDuplicates()
        {
            var distinctWords = strings
                .Select(sentence => sentence.ToLower().Split(' '))
                //.SelectMany(p => p)
                .GroupBy(word => word[0]);

            // .Select(groups => groups.First());
            // .OrderBy(words => words[0][0]);

            foreach (var group in distinctWords)
            {
                foreach (var sentence in group)
                {
                    //Console.WriteLine($"{sentence.Key}: {word}");
                    //foreach (var s in word)
                    //{
                    //    Console.Write($"{s} ");
                    //}
                }
                // Console.WriteLine();
            }


            //var nums = new int[] {1, 2, 3, 4, 5, 6, 7, 8};
            //var s = nums.GroupBy(p => p % 2 == 0);
        }
    }
}
