using System;
using System.Numerics;

namespace P4
{
    class Program
    {
        public static BigInteger GenerateD(BigInteger e, BigInteger phi)
        {
            BigInteger d = new BigInteger();

            for (BigInteger i = 1; i < phi; i = BigInteger.Add(i, 1))
            {
                d = BigInteger.DivRem(BigInteger.Add(BigInteger.Multiply(i, phi), 1), e, out BigInteger remainder);
                if (remainder == 0)
                {
                    break;
                }
            }
            return d;
        }
        public static void Main(string[] args)
        {
            int p_e = int.Parse(args[0]),
                p_c = int.Parse(args[1]),
                q_e = int.Parse(args[2]),
                q_c = int.Parse(args[3]);
            BigInteger ciperText = BigInteger.Parse(args[4]),
                plainText = BigInteger.Parse(args[5]);
            var p = (BigInteger.Pow(2, p_e) - p_c);
            var q = BigInteger.Pow(2, q_e) - q_c;
            var e = BigInteger.Pow(2,16) + 1;
            var n = p * q;
            var phi = (p - 1) * (q - 1);
            var d = GenerateD(e,phi);
            Console.WriteLine(Decryption(ciperText, d, n) + "," + Encryption(plainText, e, n));
            

        }
        public static BigInteger Encryption(BigInteger message, BigInteger e, BigInteger n)
        {
            return BigInteger.ModPow(message, e, n);
        }
        public static BigInteger Decryption(BigInteger cipher, BigInteger d, BigInteger n)
        {
            return BigInteger.ModPow(cipher, d, n);
        }

    }
}
