using System;
using System.Collections.Generic;

namespace AgHW6_T3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sentencesTotal = GetSenteceTotal();
            List<string> sentences = GetSentences(sentencesTotal);
            List<string> words = ConvertSentencesToListWords(sentences);
            PrintResult(words);
            Console.ReadKey();
        }
        static byte GetSenteceTotal()
        {
            byte sentencesTotal = GetByte("количество предложений", minValue: 0, maxValue: 20);
            return sentencesTotal;
        }
        static List<string> GetSentences(int sentencesTotal)
        {
            string str = "первое";
            List<string> sentences = new List<string>();
            for (int i = 0; i < sentencesTotal; i++)
            {
                Console.WriteLine($"Введите {str} предложение:");
                str = Console.ReadLine();
                sentences.Add(str);
                str = "следующее";
            }
            return sentences;
        }
        static List<string> ConvertSentencesToListWords(List<string> sentences)
        {
            string word = string.Empty;
            List<string> words = new List<string>();
            foreach (string str in sentences)
            {
                foreach (char ch in str)
                {
                    if (Char.IsLetter(ch))
                    {
                        word += ch;
                    }
                    if ((Char.IsWhiteSpace(ch) || Char.IsPunctuation(ch)) && word != string.Empty)
                    {
                        words.Add(word);
                        word = string.Empty;
                    }
                }
                if (word != string.Empty)
                {
                    words.Add(word);
                    word = string.Empty;
                }
            }
            return words;
        }
        static void PrintResult(List<string> words)
        {
            int lastIndex = -1;
            int countWords = 1;
            string word = string.Empty;
            for (int i = 0; i < words.Count;)
            {
                word = words[i];
                words.Remove(word);
                lastIndex = i;
                do
                {
                    lastIndex = words.IndexOf(word, lastIndex);
                    if (lastIndex != -1)
                    {
                        countWords++;
                        words.Remove(word);
                    }
                }
                while (lastIndex != -1);
                if (countWords > 1)
                {
                    word = "\tСлово: " + word;
                    word = word.PadRight(25) + $"повторяется {countWords}\tраз";
                    if (countWords < 5)
                        word += 'а';
                    Console.WriteLine(word);
                    countWords = 1;
                }
            }
        }

        //-- Methods from library
        static byte GetByte(string prompt = "", byte minValue = byte.MinValue, byte maxValue = byte.MaxValue)
        {
            string inputStr = string.Empty;
            while (true)
            {
                Console.WriteLine($"Введите {prompt}");
                Console.Write($"(Целое число от {minValue} до {maxValue}): ");
                inputStr = Console.ReadLine();
                if (byte.TryParse(inputStr, out byte value))
                    if (value >= minValue && value <= maxValue)
                    {
                        return value;
                    }
            }
        }
    }
}
