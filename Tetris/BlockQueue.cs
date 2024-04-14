using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[]
        {
            new BlockShapedI(),
            new BlockShapedJ(),
            new BlockShapedL(),
            new BlockShapedO(),
            new BlockShapedS(),
            new BlockShapedT(),
            new BlockShapedZ()
        };
        private readonly Random random = new Random();

        public Block NextBlock { get; private set; }

        public BlockQueue() 
        {
            NextBlock = RandomBlock();
        }

        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }
        public Block GetAndUpdate()
        {
            Block block = NextBlock;
            do { NextBlock = RandomBlock(); }

            while (block.Id == NextBlock.Id);

            return block;
        }

    }
}
