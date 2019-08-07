using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkParser
{
    class ListOfObjects
    {
        private List<object> theList;

        public ListOfObjects(List<object> newList)
        {
            theList = newList;
        }

        public object GetStr(int index)
        {
            return theList[index];
        }
    }
}
