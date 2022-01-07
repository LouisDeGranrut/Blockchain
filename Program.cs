using System;

namespace Blockchain
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Creating blockchain...");
            BlockChain bc = new BlockChain();

            Console.WriteLine("Mining block 1...");
            bc.AddBlock(1, "01/01/2022", "Value = 1");

            Console.WriteLine("Mining block 2...");
            bc.AddBlock(2, "02:01/2022", "Value = 6");


            Console.WriteLine("Chain is valid: " + bc.isChainValid());

            //bc.ListBlocks();
        }
    }
}
