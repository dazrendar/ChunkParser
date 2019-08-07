using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkParser
{
    class Declaration : Statement
    {

        string value;
        string definition;

        public override void parse()
        {
            Tokenizer.getAndCheckNext("="); // TODO CHANGED?  // Todo must also do something similar for COMMAS
            definition = Tokenizer.getPrevious();
            value = Tokenizer.getNext();
        }
        

        internal override void handleStatement()
        {
            // Case: New "Chunk"
            if (value.Equals("{"))
            {
                ChunkHandler.createChunk(definition);
            }

            // Case: String
            if (value.Equals("\""))
            {
                Console.WriteLine("YES!!!!! ~~~~ " + definition + " vs. " + value);
                try
                {

                    Chunk currentChunk = ChunkHandler.getCurrentChunk();
                    currentChunk.addToStringMap(definition, Tokenizer.getNext());
                }
                catch
                {
                    Console.WriteLine("Error: Chunk not found :(");

                }
               
            }

            // Case: List (paren)
            if (value.Equals("("))
            {
                int x = ChunkHandler.chunkDepth;
                Chunk currentChunk = ChunkHandler.getCurrentChunk();
                List<object> newList = new List<object>();
                while (!Tokenizer.checkToken(")"))
                {
                    if (!Tokenizer.checkToken(",") && !Tokenizer.checkToken("\""))
                    {
                        string newString = Tokenizer.getNext();
                        try
                        {
                            int newVal = Convert.ToInt32(newString);
                            newList.Add(newVal);
                        } catch
                        {
                            newList.Add(newString);
                        }
                        
                    } else
                    {
                        Tokenizer.incrementTokenIndex();
                    }
                    
                }
                currentChunk.addNewListToMap(definition, newList);
            }
            
            // Case: Int
            else
            {
                
                try
                {
                    Chunk currentChunk = ChunkHandler.getCurrentChunk();
                    int newVal = Convert.ToInt32(value);
                    currentChunk.addToIntMap(definition, newVal);
                }
                catch
                {
                    Console.WriteLine("Error: Not an int");
                }

            }




        }
    }
}
