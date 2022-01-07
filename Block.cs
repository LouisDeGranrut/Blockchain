using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    class Block
    {
        public int index;
        public string timeStamp;
        public string previousHash;
        public string data;
        public string hash;
        public int nonce;

        public Block(int i, string time, string data, string previousH)
        {
            index = i;
            timeStamp = time;
            this.data = data;
            previousHash = previousH;
            hash = CalculateHash();
            nonce = 0;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Index: " + index + "\nTimestamp: " + timeStamp + "\n" + data + "\nHash: " + hash + "\nPreviousHash: " + previousHash + "\n\n");
        }

        //calculates the block's hash
        public string CalculateHash()
        {
            return Hash(index + timeStamp + previousHash + data + nonce);
        }

        //hashing functions
        private string Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));//byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(index + timeStamp + previousHash + data + nonce));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        //Creates a block only when the computer is able to find a hash starting with DIFFICULTY amount of zeros
        public void MineBlock(int difficulty)
        {
            string startString = "";
            for (int i = 0; i < difficulty; i++)
                startString += "0";

            while (hash.Substring(0, difficulty) != startString)
            {
                nonce++;
                hash = CalculateHash();
            }
            Console.WriteLine("Block mined !");
            ShowInfo();
        }
    }
}
