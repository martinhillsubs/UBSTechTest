using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using UBS.SentenceParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UBS.SentenceParser.Tests
{
    [TestClass]
    public class SentenceParserTests
    {
        [TestMethod]
        public void ParserWillRejectStringOfPunctuation()
        {
            SentenceParse sp = new SentenceParse();
            bool exceptionCaught = false;
            try
            {
                sp.Sentence = "-+ * */// /*";
            }
            catch (InvalidSentenceException)
            {
                exceptionCaught = true;
            }

            Assert.AreEqual(true, exceptionCaught);
            
        }

        [TestMethod]
        public void ParserWillRejectNumericString()
        {
            SentenceParse sp = new SentenceParse();
            bool exceptionCaught = false;
            try
            {
                sp.Sentence = "234234 23423423 23234";
            }
            catch (InvalidSentenceException)
            {
                exceptionCaught = true;
            }
           
            Assert.AreEqual(true, exceptionCaught);

        }

        [TestMethod]
        public void ParserWillAcceptValidSentence()
        {
            SentenceParse sp = new SentenceParse();
            bool exceptionCaught = false;
            try
            {
                sp.Sentence = "This is a valid sentence.";
            }
            catch (InvalidSentenceException)
            {
                exceptionCaught = true;
            }

            Assert.AreEqual(false, exceptionCaught);
        }

        [TestMethod]
        public void ParserWillRejectInvalidSentence()
        {
            SentenceParse sp = new SentenceParse();
            bool exceptionCaught = false;
            try
            {
                sp.Sentence = "This is not a valid sentence";
            }
            catch (InvalidSentenceException)
            {
                exceptionCaught = true;
            }

            Assert.AreEqual(false, exceptionCaught);
        }

        [TestMethod]
        public void ParserCountsWordsCorrectly()
        {
            SentenceParse sp = new SentenceParse();
            sp.Sentence =
                "This is a valid sentence containing words, and it is going to have a number of repeated words.";
            sp.ParseSentence();

            if (sp.WordDictionary["is"] != 2)
                Assert.Fail();
            if (sp.WordDictionary["sentence"] != 1)
                Assert.Fail();
        }
    }
}
