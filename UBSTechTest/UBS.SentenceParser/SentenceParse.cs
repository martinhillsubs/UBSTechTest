using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UBS.SentenceParser
{

    public class SentenceParse
    {
        private string _sentence;
        private string _sentenceWithoutPunctuation;
        private bool _parsed = false;
        private Dictionary<string, int> _wordCountDictionary;


        public SentenceParse()
        {
        }

        public string Sentence
        {
            set
            {
                if (ValidateSentence(value))
                    _sentence = value;
                else
                {
                    throw new InvalidSentenceException();
                }
            }
        }

        public bool Parsed
        {
            get { return _parsed; }
        }

        public Dictionary<string, int> WordDictionary
        {
            get
            {
                if (!_parsed)
                    throw new SentenceNotParsedException();
                return _wordCountDictionary;
            }
        }

        private bool ValidateSentence(string value)
        {
            //check the value is not only numbers
            if (Regex.IsMatch(value.Replace(" ", string.Empty), @"^\d+$"))
                return false;
            //check there is one full stop
            if (value.Count(f => f == '.') > 1)
                return false;
            //check the sentence contains letters ie. not just punctuation etc. - store this as we'll use it later
            _sentenceWithoutPunctuation = RemovePunctuation(value);
            if (_sentenceWithoutPunctuation.Length == 0)
                return false;

            return true;
        }

        private string RemovePunctuation(string sentence)
        {
            var sb = new StringBuilder();

            foreach (char c in sentence)
            {
                if (char.IsLetterOrDigit(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }


        public void ParseSentence()
        {
            if (_sentence.Length == 0)
                throw new InvalidSentenceException();

            string[] words = _sentenceWithoutPunctuation.Split(' ');

            _wordCountDictionary = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (_wordCountDictionary.ContainsKey(word))
                    _wordCountDictionary[word] ++;
                else
                {
                    _wordCountDictionary.Add(word,1);
                }
            }

            _parsed = true;
        }
    }


    public class InvalidSentenceException : Exception
    {
        public InvalidSentenceException()
            :base ("The sentence is not valid.")
        {
        }
    }

    public class SentenceNotParsedException : Exception
    {
        public SentenceNotParsedException()
            : base("The sentence must be parsed before accessing the WordDictionary.")
        {
        }
    }
}
