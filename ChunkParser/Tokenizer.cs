using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ChunkParser
{
    static class Tokenizer
    {
        //private static Tokenizer theTokenizer;
        private static List<char> literals;
        private static string program;
        private static string[] tokens;
        private static int currentTokenIndex;

        public static void initializeTokenizer(string allText, List<char> literalsList)
        {
            literals = literalsList;
            program = allText;

            
            tokenize();
        }

        internal static void incrementTokenIndex()
        {
            currentTokenIndex++;
        }

        private static void tokenize()
        {
            String tokenizedProgram = program;
            tokenizedProgram = tokenizedProgram.Replace("\n", "");
            tokenizedProgram = tokenizedProgram.Replace(" ", "");
            tokenizedProgram = tokenizedProgram.Replace("\t", "");
            tokenizedProgram = tokenizedProgram.Replace("\r", "");
            
            foreach (char c in literals)
            {
                tokenizedProgram = tokenizedProgram.Replace(c.ToString(), "_" + c + "_");
            }
            
            tokens = Regex.Split(tokenizedProgram, @"[_]+");
            Console.WriteLine(tokenizedProgram);
        }

        private static string checkNext()
        {
            string token = "";
            if (currentTokenIndex < tokens.Length)
            {
                token = tokens[currentTokenIndex];
            } else
            {
                token = "NO_REMAINING_TOKENS";
            }
            return token;
        }

        public static string getNext()
        {
            string token = "";
            if (currentTokenIndex < tokens.Length)
            {
                token = tokens[currentTokenIndex];
                currentTokenIndex++;
            }
            else
            {
                token = "NULL_TOKEN";
            }
            return token;
        }

        public static string getPrevious()
        {
            string token = "";
            if (currentTokenIndex > 1)
            {
                token = tokens[currentTokenIndex-2];
            }
            else
            {
                token = "NULL_TOKEN";
            }
            return token;
        }

        public static bool checkToken(string regexp)
        {
            string s = checkNext();
            Console.WriteLine("comparing: <" + s + ">  to  <" + regexp + ">");
            return (s.Equals(regexp));
        }


        public static string getAndCheckNext(string v)
        {
            string s = getNext();

            if (!s.Equals(v))
            {
                Console.WriteLine("Error - Wrong token");
                System.Environment.Exit(1);
            }
            return s;
        }

        /*
        public static Tokenizer getTokenizer()
        {
            return theTokenizer;
        }
        */







        public static bool moreTokens()
        {
            return currentTokenIndex < tokens.Length;
        }

        

        /*
        public static void makeTokenizer(string filePath, List<char> literals)
        {
            if (theTokenizer == null)
            {
                theTokenizer = new Tokenizer(filePath, literals);
            }
        }
        */
    }

    /*
            for (int i = 0; i < allText.Length; i++)
            {
                Console.WriteLine(allText[i]);
            }
            */
}
