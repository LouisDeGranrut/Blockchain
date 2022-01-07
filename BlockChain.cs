using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    class BlockChain
    {
        public List<Block> chain;//list of blocks
        public int difficulty;//Mining difficulty

        public BlockChain()
        {
            chain = new List<Block>();
            chain.Add(CreateGenesisBlock());
            difficulty = 5;
            Console.WriteLine("Difficulty: " + difficulty);
        }

        //Creates the first block of the chain
        private Block CreateGenesisBlock()
        {
            Block Genesis = new Block(0, "01/01/2022", "Genesis Block", "0");
            Genesis.ShowInfo();
            return Genesis;
        }

        //returns the last block of the chain
        private Block GetLatestBlock()
        {
            return chain[chain.Count - 1];
        }

        //adds a new block to the chain
        public void AddBlock(int index, string time, string data)
        {
            Block newBlock = new Block(index ,time, data, GetLatestBlock().hash);
            newBlock.MineBlock(difficulty);
            chain.Add(newBlock);
        }

        //prints every info about every block of the chain
        public void ListBlocks()
        {
            foreach (Block b in chain)
                Console.WriteLine("Index: " + b.index + "\nTimestamp: " + b.timeStamp + "\n" + b.data + "\nHash: " + b.hash + "\nPreviousHash: " + b.previousHash + "\n\n");
        }

        //Checks if the chain we hold is valid by making sure every hash corresponds to the next blocks' previous hash
        public bool isChainValid()
        {
            Console.WriteLine("Checking chain validity...");
            for(int i = 1; i < chain.Count; i++)
            {
                Block currentBlock = chain[i];
                Block previousBlock = chain[i - 1];
                if (currentBlock.hash != currentBlock.CalculateHash())
                    return false;

                if (currentBlock.previousHash != previousBlock.hash)
                    return false;
            }
            return true;
        }
    }
}
