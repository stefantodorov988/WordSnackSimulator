﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Demo1_Words
{
    class StartUp
    {
        public static List<string> allWords;
        public static Trie trieOfAllWords = new Trie();
        public const int CONSOLE_HEIGH = 20;
        public const int CONSOLE_WIDHT = 70;
        public const int RANGE_OF_WORD_OF_3CHARACTERS = 1007;
        public const int RANGE_OF_WORD_OF_4CHARACTERS = 6087;
        public const int RANGE_OF_WORD_OF_5CHARACTERS = 19014;
        public const int RANGE_OF_WORD_OF_6CHARACTERS = 45145;
        public const int RANGE_OF_WORD_OF_7CHARACTERS = 83296;
        public const int RANGE_OF_WORD_OF_8CHARACTERS = 131359;
        public const int RANGE_OF_WORD_OF_9CHARACTERS = 180766;
        public const int RANGE_OF_WORD_OF_10CHARACTERS = 223760;
        public const int RANGE_OF_WORD_OF_10_PLUS_CHARACTERS = 340728;
        static void Main()
        {
            allWords = File.ReadAllLines(@"C:\Users\Stefan\Desktop\Demo1-Words\Demo1-Words\Demo1-Words\resource\words.txt").ToList();
            allWords = allWords.OrderBy(x => x.Length).ToList();
            allWords.ForEach(x => trieOfAllWords.insert(x));
            Console.WriteLine(Shuffle("jabc"));
        }
        public static string Shuffle(string input)
        {
            Random num = new Random();
            return  new string(input.ToCharArray().
                OrderBy(s => (num.Next(2) % 2) == 0).ToArray());
        }
        public static List<string> findingSoution(string characters)
        {
            int range;
            switch (characters.Length)
            {
                case 3:
                    range = RANGE_OF_WORD_OF_3CHARACTERS;
                    break;
                case 4:
                    range = RANGE_OF_WORD_OF_4CHARACTERS;
                    break;
                case 5:
                    range = RANGE_OF_WORD_OF_5CHARACTERS;
                    break;
                case 6:
                    range = RANGE_OF_WORD_OF_6CHARACTERS;
                    break;
                case 7:
                    range = RANGE_OF_WORD_OF_7CHARACTERS;
                    break;
                case 8:
                    range = RANGE_OF_WORD_OF_8CHARACTERS;
                    break;
                case 9:
                    range = RANGE_OF_WORD_OF_9CHARACTERS;
                    break;
                case 10:
                    range = RANGE_OF_WORD_OF_10CHARACTERS;
                    break;
                    default:
                        range = RANGE_OF_WORD_OF_10_PLUS_CHARACTERS;
                    break;
            }
            List<string> validWords = new List<string>();
            int[] alphabetArray = new int[26];
            for (int i = 0; i < characters.Length; i++)
            {
                alphabetArray[characters[i] - 'a']++;                
            }
            for (int i = 0; i < range; i++)
            {
                bool isValid = true;
                string currentWord = allWords[i];
                int[] temporaryArray = new int[26];
                for (int j = 0; j < currentWord.Length; j++)
                {
                    temporaryArray[currentWord[j] - 'a']++;
                }
                for (int j = 0; j <= 25; j++)
                {
                    if (alphabetArray[j] < temporaryArray[j])
                    {
                        isValid = false;
                    }
                }
                if (isValid)
                {
                    validWords.Add(currentWord);
                }
            }
            if (validWords.Count == 0)
            {
                Console.WriteLine("No valid word");
            }
            return validWords;
        }
        public static string givingRandomWordWithNLenght(int n)
        {
            Random r = new Random();
            int randomIndex;
            switch (n)
            {
                case 3:
                    randomIndex = r.Next(0, RANGE_OF_WORD_OF_3CHARACTERS);
                    break;
                case 4:
                    randomIndex = r.Next(RANGE_OF_WORD_OF_3CHARACTERS, RANGE_OF_WORD_OF_4CHARACTERS);
                    break;
                case 5:
                    randomIndex = r.Next(RANGE_OF_WORD_OF_4CHARACTERS, RANGE_OF_WORD_OF_5CHARACTERS);
                    break;
                case 6:
                    randomIndex = r.Next(RANGE_OF_WORD_OF_5CHARACTERS, RANGE_OF_WORD_OF_6CHARACTERS);
                    break;
                case 7:
                    randomIndex = r.Next(RANGE_OF_WORD_OF_6CHARACTERS, RANGE_OF_WORD_OF_7CHARACTERS);
                    break;
                case 8:
                    randomIndex = r.Next(RANGE_OF_WORD_OF_7CHARACTERS, RANGE_OF_WORD_OF_8CHARACTERS);
                    break;
                case 9:
                    randomIndex = r.Next(RANGE_OF_WORD_OF_8CHARACTERS, RANGE_OF_WORD_OF_9CHARACTERS);
                    break;
                case 10:
                    randomIndex = r.Next(RANGE_OF_WORD_OF_9CHARACTERS, RANGE_OF_WORD_OF_10CHARACTERS);
                    break;
                default:
                    randomIndex = r.Next(RANGE_OF_WORD_OF_10CHARACTERS, RANGE_OF_WORD_OF_10_PLUS_CHARACTERS);
                    break;
            }
            return allWords[randomIndex];
        }
    }
}