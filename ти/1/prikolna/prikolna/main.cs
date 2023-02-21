using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HuffmanTest
{
    class main
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("C:\\Users\\morim\\Desktop\\Для пугу\\ти\\1\\prikolna\\prikolna\\text.txt");
            HuffmanTree huffmanTree = new HuffmanTree();

            // строим дерево
            huffmanTree.Build(input);

            // кодируем
            BitArray encoded = huffmanTree.Encode(input);

            Console.Write("Encoded: ");
            foreach (bool bit in encoded)
            {
                Console.Write(bit ? 1 : 0);
            }
            Console.WriteLine();

            // декодируем
            string decoded = huffmanTree.Decode(encoded);

            huffmanTree.printTable(encoded);
            Console.WriteLine("Decoded: " + decoded);

            Console.ReadLine();
        }
    }
}