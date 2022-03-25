using System.Collections.Generic;
using System;

namespace FlashTyperLibrary
{
    public class WordList
    {
        private static string[] words = new string[100] 
        {
            "twilight", "role", "shark", "doctor", "captivate", "boy", "fool", 
            "physics", "pace", "resource", "virus", "strict", "register", "participate", 
            "pleasure", "spin", "favorable", "skin", "technique", "ignite", "appetite", 
            "collar", "venture", "alive", "boom", "groan", "direct", "plot", "perfume", 
            "attention", "beer", "innovation", "preoccupation", "unlikely", "cultural", 
            "variation", "album", "fur", "efflux", "appear", "biography", "dismissal", 
            "congress", "invasion", "europe", "bland", "equal", "unity", "sport", "ethics",
            "nap","mass", "feedback", "terrify", "so", "burst",
            "thanks", "rung", "necklace", "can", "laboratory", "tolerant",
            "exposure", "install", "size", "winner", "loud", "fever",
            "meadow", "wrestle", "berry", "pursuit", "extinct", "kettle",
            "adjust", "subway", "coalition", "terrace", "evaluate", "swarm",
            "improvement", "throat", "west", "cry", "pool", "college", "examination",
            "harvest", "poetry", "approach", "network", "diplomatic", "safari",
            "tank", "do", "dine", "wife", "lobby", "registration", "divinity"
        };

        public static List<string> PossibleWords(int listSize)
        {
            List<string> listOfWords = new List<string>();
            int i = 0;

            while(i != listSize - 1)
            {
                Random index = new Random();
                int _index = index.Next(1, 100);

                if (!listOfWords.Contains(words[_index]))
                {
                    listOfWords.Add(words[_index]);
                    i++;
                }
            }

            return listOfWords;
        }
    }
}
