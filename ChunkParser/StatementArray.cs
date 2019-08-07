
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkParser
{
    class StatementArray : Statement
    {
        string definition;
        string value;

        public override void parse()
        {
            Chunk currentChunk = ChunkHandler.getCurrentChunk();

            /*
            while(!Tokenizer.checkToken(")"))
            {
                Console.WriteLine(Tokenizer.getNext());
            }
            Console.WriteLine("======= CLOSING paren ======");
            Tokenizer.getAndCheckNext("=");
            definition = Tokenizer.getPrevious();
            value = Tokenizer.getNext();
            */
        }

        internal override void handleStatement()
        {
            throw new NotImplementedException();
        }
    }
}
