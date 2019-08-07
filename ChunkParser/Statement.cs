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
                return new Declaration();
            }
            
            else if (Tokenizer.checkToken("}"))
            {
                return new StatementCloseChunk();
            }
            
            return null;
        }

        internal abstract void handleStatement();
    }
}
