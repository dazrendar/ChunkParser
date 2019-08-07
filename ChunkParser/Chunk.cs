using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkParser
{
    class Chunk
    {
        private Dictionary<string, string> stringMap;
        private Dictionary<string, int> intMap;
        private Dictionary<string, List<object>> listMap;
        private Dictionary<string, Chunk> chunkMap;
        private int chunkDepth;
        private Chunk parent;
        private string name;

        public Chunk(string chunkName, int chunkDepth, Chunk parent)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~ Creating Chunk ~~~~~~~~~~~~~~~~~~~");
            this.name = chunkName;
            this.chunkDepth = chunkDepth;
            this.parent = parent;
            stringMap = new Dictionary<string, string>();
            intMap = new Dictionary<string, int>();
            listMap = new Dictionary<string, List<object>>();
            chunkMap = new Dictionary<string, Chunk>();
        }

        public Chunk getParent()
        {
            return this.parent;
        }

        public void addToStringMap(string key, string value)
        {
            stringMap.Add(key, value);
        }

        public void addToIntMap(string key, int value)
        {
            intMap.Add(key, value);
        }

        public void addChunkToMap(string chunkName, Chunk chunk)
        {
            chunkMap.Add(chunkName, chunk);
        }

        public void addNewListToMap(string key, List<object> list)
        {
            listMap.Add(key, list);
        }

        public string GetStr(string str)
        {
            string value = "";
            stringMap.TryGetValue(str, out value);
            if (value == "")
            {
                throw new MissingMemberException("String \'" + name + "\' does not exist.");
            }
            return value;
        }

        public int GetNum(string str)
        {
            int value = -1;
            intMap.TryGetValue(str, out value);
            if (value == -1)
            {
                throw new MissingMemberException("Number \'" + name + "\' does not exist.");
            }
            return value;
        }

        public Chunk GetChunk(string name)
        {
            Chunk value;
            chunkMap.TryGetValue(name, out value);
            
            if (value == null)
            {
                throw new MissingMemberException("Chunk \'" + name + "\' does not exist.");
            }
            
            return value;
        }

        public ListOfObjects GetArray(string arrayName)
        {
            List<object> value;
            listMap.TryGetValue(arrayName, out value);
            if (value == null)
            {
                throw new MissingMemberException("List \'" + arrayName + "\' does not exist.");
            }

            return new ListOfObjects(value);
        }

        // TODO Find* functions...

    }
}
