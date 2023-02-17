using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClimbThePeaks
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] foodPortions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] staminaQuantities = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(foodPortions);
            Queue<int> queue = new Queue<int>(staminaQuantities);
            Dictionary<string, int> peaksDifficulty = new Dictionary<string, int>();

            peaksDifficulty["Vihren"] = 80;
            peaksDifficulty["Kutelo"] = 90;
            peaksDifficulty["Banski Suhodol"] = 100;
            peaksDifficulty["Polezhan"] = 60;
            peaksDifficulty["Kamenitza"] = 70;

            List<string> conqueredPeaks = new List<string>();

            int countOfPeaks = 0;
            foreach (var peak in peaksDifficulty)
            {
                if (stack.Count == 0)
                {
                    break;
                }

                while (stack.Any())//7 days
                {
                    int foodPortion = stack.Pop();
                    int staminaQuantity = queue.Dequeue();
                    if ((foodPortion + staminaQuantity) >= peak.Value)
                    {
                        conqueredPeaks.Add(peak.Key);
                        countOfPeaks++;
                        break;
                    }
                }
            }

            if (countOfPeaks == peaksDifficulty.Count)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (conqueredPeaks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                Console.WriteLine(string.Join(Environment.NewLine, conqueredPeaks));
            }

        }
    }
}
