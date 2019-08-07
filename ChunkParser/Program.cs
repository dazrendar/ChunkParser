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

            inputText = ""; // modify to
            if (!useCustomText)
            {
                inputText = readFileContents(inputText);
            }
            

            Parse(inputText);
            Console.WriteLine("********************************************");

            List<Chunk> chunks = ChunkHandler.getChunks();
            int dsa = 1;

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


           





            /*
            List<string> lines = File.ReadAllLines(filePath).ToList();

            


            List<Chunk> chunks = new List<Chunk>();
            int chunkDepth = -1;
            int indexOfEqualSign = 0;
            bool foundEqualsSign = false;

            */


            /*
            foreach (string line in lines)
            {
                Console.WriteLine("====================================");
                Console.WriteLine(line);
                for (int i = 0; i < line.Length; i++)
                {
                    char currentChar = line[i];
                    if (currentChar == '{')
                    {

                        Chunk newChunk = new Chunk();
                        chunks.Add(newChunk);
                        chunkDepth++;
                    }
                    else if (currentChar == '=')
                    {
                        indexOfEqualSign = i;
                        foundEqualsSign = true;
                    }
                    else if (foundEqualsSign && (currentChar == ',' || currentChar == '}' || i == line.Length - 1))
                    {
                        string currentKey = line.Substring(0, indexOfEqualSign - 1).Trim();
                        string currentString = line.Substring(indexOfEqualSign + 1, i - indexOfEqualSign).Trim();


                        // Case 1: String
                        if (currentString[0] == '"')
                        {
                            Console.WriteLine("Found a string: " + currentString);

                            chunks[chunkDepth].stringMap.Add(currentKey, currentString);


                            Console.WriteLine(chunks[0].GetStr(currentKey));

                        }

                        // Case 2: Number
                        else
                        {
                            try
                            {
                                int value = Convert.ToInt32(currentString.Replace(',', ' '));
                                Console.WriteLine("Converting to int");
                                chunks[chunkDepth].numMap.Add(currentKey, value);
                                Console.WriteLine(chunks[0].GetNum(currentKey));
                            }
                            catch
                            {
                                Console.WriteLine("Cannot convert to int");
                            }

                        }


                        // Case 3: Array


                        // Case 4: Another Chunk
                        foundEqualsSign = false;
                    }


                }

            }
            */

            //File.WriteAllLines()
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
