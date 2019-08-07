using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkParser
{
    abstract class Statement : Node
    {
        
        
        public static Statement getSubStatement()
        {
            if (Tokenizer.checkToken("=")) {
                Console.WriteLine("** Found DEC **");
                return new Declaration();
            }
            
            else if (Tokenizer.checkToken("}"))
            {

                Console.WriteLine("** Found CLOSER **");
                return new StatementCloseChunk();
            }

            /*
            else if (Tokenizer.checkToken(")"))
            {
                Console.WriteLine("** Found CLOSER PAREN ~~~~!!!! **");
                return new StatementCloseArray();
            }
            */
            return null;
        }

        internal abstract void handleStatement();
    }
}
