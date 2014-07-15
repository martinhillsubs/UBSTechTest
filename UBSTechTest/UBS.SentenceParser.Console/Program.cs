using System;
using System.Collections.Generic;
using UBS.SentenceParser;

namespace UBS.SentenceParser.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            SentenceParse sp = new SentenceParse();
            sp.Sentence = "This is a statement, and so is this.";
            sp.ParseSentence();

            foreach (KeyValuePair<string, int> keyValuePair in sp.WordDictionary)
            {
                System.Console.WriteLine(keyValuePair.Key + " - " + keyValuePair.Value);
            }

            System.Console.ReadKey();
        }
    }
}
