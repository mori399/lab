using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Linq;
using System.Globalization;

namespace HuffmanTest
{
    public class HuffmanTree
    {
        private List<Node> nodes = new List<Node>();
        public Node Root { get; set; }
        
        public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

        public void Build(string source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (!Frequencies.ContainsKey(source[i]))
                {
                    Frequencies.Add(source[i], 0);
                }

                Frequencies[source[i]]++;
            }

            foreach (KeyValuePair<char, int> symbol in Frequencies)
            {
                nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
            }

            while (nodes.Count > 1)
            {
                List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();

                if (orderedNodes.Count >= 2)
                {
                    // берёт первые 2 элемента
                    List<Node> taken = orderedNodes.Take(2).ToList<Node>();

                    // создает родительский узел для объединения частот
                    Node parent = new Node()
                    {
                        Symbol = '*',
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        Left = taken[0],
                        Right = taken[1]
                    };

                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }

                this.Root = nodes.FirstOrDefault();

            }

        }

        public BitArray Encode(string source)
        {
            List<bool> encodedSource = new List<bool>();

            for (int i = 0; i < source.Length; i++)
            {
                List<bool> encodedSymbol = this.Root.Traverse(source[i], new List<bool>());
                encodedSource.AddRange(encodedSymbol);
            }

            BitArray bits = new BitArray(encodedSource.ToArray());

            return bits;
        }

        public string Decode(BitArray bits)
        {
            Node current = this.Root;
            string decoded = "";

            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                }

                if (IsLeaf(current))
                {
                    decoded += current.Symbol;
                    current = this.Root;
                }
            }

            return decoded;
        }
        
        public void printTable(BitArray bits)
        {
            Dictionary<char, string> chars = new Dictionary<char, string>();
            Node current = this.Root;
            string decoded = "";

            string code = "";
            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                        code += "1";
                    }
                }
                else
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                        code += "0";
                    }
                }

                if (IsLeaf(current))
                {
                    decoded += current.Symbol;

                    try { chars.Add(current.Symbol, code); }
                    catch { }

                    current = this.Root;
                    code = "";
                }
            }

            string p = decoded;
            int length = 0;
            foreach (char c in p)
            {
                length++;
            }

            List<double> aa = new List<double>();
            foreach(var symb in chars)
            {
                int symb_c = 0;
                foreach (char c in p)
                {
                if (c == symb.Key) symb_c++;
                }
                aa.Add(symb_c);
               // Console.WriteLine(symb_c);
            }

            double qweqk = 0;
            int n = 0;
            foreach(var symb in chars)
            {
                qweqk = Math.Round(aa[n] / length, 4);
                Console.WriteLine($"{symb.Key}\t code: {symb.Value} \t p: {qweqk} ");
                n++;
            }

            Console.WriteLine("Entropy : " + chars.Count);
        }

        public bool IsLeaf(Node node)
        {
            return (node.Left == null && node.Right == null);
        }

    }
}