using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChunkParser
{
    class Program
    {
        static Chunk chunk;
        static bool useCustomText = false;  // if false, uses sample.txt file
        static string inputText = "";       // change as desired
        static void Main(string[] args)
        {
            if (!useCustomText)
            {
                inputText = readFileContents(inputText);
            }
            

            Parse(inputText);
            Console.WriteLine("********************************************");

            List<Chunk> chunks = ChunkHandler.getChunks();


            try
            {
                Console.WriteLine(chunk.GetStr("Name"));
                Console.WriteLine(chunk.GetArray("Games").getStr(1));
                Console.WriteLine(chunk.GetNum("Established"));
                Console.WriteLine(chunk.GetChunk("Scores").GetChunk("Players").GetNum("Alice"));
                // Console.WriteLine(chunk.FindNum("Alice"));

            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }



        private static string readFileContents(string inputText)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string filePath = projectDirectory + @"\sample.txt";


            try
            {
                inputText = File.ReadAllText(filePath);
                Console.WriteLine("Reading File...");

            }
            catch
            {
                Console.WriteLine("Invalid file location.");
                System.Environment.Exit(1);
            }

            return inputText;
        }

        private static void Parse(string allText)
        {
            

            List<char> literals = new List<char>() { '{', '}', '=', ',', '(', ')', '"' };

            ChunkHandler.initializeChunkHandler();
            Tokenizer.initializeTokenizer(allText, literals);
            Prog program = new Prog();
            program.parse();
            chunk = ChunkHandler.getRoot();
        }
    }
}
