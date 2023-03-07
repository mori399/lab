using System.Security.Cryptography;
using System.Numerics;

namespace lab_2
{
    class Program
    {
        static string ByteArrayToString(byte[] _by)
        {
            string result = "";

            for (int c = 0; c < _by.Length; c++)
            {
                result += _by[c].ToString("X2");
            }

            return result;
        }
        static void Main(string[] args)
        {
            byte[] b = { 5, 6 };
            HashAlgorithm sha = SHA1.Create();

            byte[] result = sha.ComputeHash(File.ReadAllBytes(@"..\source.txt"));
            string results;
            Console.WriteLine("Хеш-код");
            Console.WriteLine(results = ByteArrayToString(result));


            Console.ReadKey(); //ЭЦП

            RSA psa = new RSA();
            long p = 101, q = 103, d = 0, n = 0;
            psa.Start(p, q, ref d, ref n);
            psa.startD(d, n);
        }
    }

    public partial class RSA
    {
        char[] characters = new char[] { '#', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        //зашифровать
        public void Start(long p, long q, ref long d, ref long n)
        {

            string s = "";

            StreamReader sr = new StreamReader("text.txt");


            while (!sr.EndOfStream)
            {
                s += sr.ReadLine();
            }

            sr.Close();

            s = s.ToUpper();

            long n_ = p * q;
            long m = (p - 1) * (q - 1);
            long d_ = Calculate_d(m);
            long e_ = 10199;   //Открытый ключ

            List<string> result = RSA_Endoce(s, e_, n_);

            StreamWriter sw = new StreamWriter("resul1.txt");
            foreach (string item in result)
                sw.WriteLine(item);
            sw.Close();

            d = d_;
            n = n_;      //закрытые
        }

        //расшифровать
        public void startD(long d, long n)
        {

            List<string> input = new List<string>();

            StreamReader sr = new StreamReader("resul1.txt");

            while (!sr.EndOfStream)
            {
                input.Add(sr.ReadLine());
            }

            sr.Close();

            string result = RSA_Dedoce(input, d, n);

            StreamWriter sw = new StreamWriter("resul2.txt");
            sw.WriteLine(result);
            sw.Close();
        }

        //зашифровать
        private List<string> RSA_Endoce(string s, long e, long n)
        {
            List<string> result = new List<string>();
            BigInteger bi;

            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(characters, s[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            return result;
        }
        //расшифровать
        private string RSA_Dedoce(List<string> input, long d, long n)
        {
            string result = "";

            BigInteger bi;

            foreach (string item in input)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                int index = Convert.ToInt32(bi.ToString());

                result += characters[index].ToString();
            }

            return result;
        }

        //вычисление параметра d. d должно быть взаимно простым с m
        private long Calculate_d(long m)
        {
            long d = m - 1;

            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0)) //если имеют общие делители
                {
                    d--;
                    i = 1;
                }

            return d;
        }
    }
}
