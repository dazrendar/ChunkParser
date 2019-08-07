using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkParser
{
    class StatementCloseChunk : Statement
    {
        public override void parse()
        {
            ChunkHandler.closeChunk();
        }

        internal override void handleStatement()
        {
            Tokenizer.getAndCheckNext("}"); // TODO CHANGED
            Tokenizer.incrementTokenIndex();
        }
    }
}
