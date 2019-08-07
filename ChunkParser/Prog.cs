using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkParser
{
    class Prog : Node
    {
        private List<Statement> statements = new List<Statement>();

        public override void parse()
        {
            while (Tokenizer.moreTokens())
            {
                Statement stmt = Statement.getSubStatement();

                if (stmt != null)
                {
                    stmt.parse();
                    stmt.handleStatement();

                    
                }
                else
                {
                    Tokenizer.incrementTokenIndex();
                }


                
            }
        }


        
    }
}
