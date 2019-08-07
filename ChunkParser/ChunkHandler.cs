using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkParser
{
    static class ChunkHandler
    {
        private static List<Chunk> chunks; // TODO remove...
        private static Chunk currentChunk;
        private static Chunk root;
        public static int chunkDepth { get; set; }

        public static void initializeChunkHandler()
        {
            chunks = new List<Chunk>();
        }

        public static List<Chunk> getChunks()
        {
            return chunks;
        }

        public static Chunk getCurrentChunk()
        {
            return currentChunk; // TODO REPLACE with this.currentChunk
        }

        public static Chunk getRoot()
        {
            return root;
        }


        public static Chunk createChunk(string chunkName)
        {
            Chunk newChunk = new Chunk(chunkName, chunkDepth, currentChunk);
            currentChunk = newChunk;
            chunks.Add(newChunk); // TODO remove...
            chunkDepth++;
            Chunk parent = newChunk.getParent();
            if (parent != null)
            {
                parent.addChunkToMap(chunkName, newChunk);
            } else
            {
                root = newChunk;
            }
            return newChunk;
        }

        public static void closeChunk()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~ Closing Chunk ~~~~~~~~~~~~~~~~~~~");
            chunkDepth--;
            currentChunk = currentChunk.getParent();
        }
        
    }
}
