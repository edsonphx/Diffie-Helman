using System;
using System.Numerics;

namespace Diffie_Helman
{
    class Program
    {
        private readonly Random _random = new Random();
        static void Main(string[] args)
        {
            new Program().Start();
        }
        public void Start()
        {
            BigInteger i = 0;
            BigInteger p = 0;

            Console.Write("Chose a random number: ");
            if (BigInteger.TryParse(Console.ReadLine(), out BigInteger result))
            {
                i = result;
                Console.Write("Chose a random prime number: ");
                if (BigInteger.TryParse(Console.ReadLine(), out BigInteger resultPrime) && IsPrime(resultPrime))
                {
                    p = resultPrime;
                }
                else
                {
                    Console.WriteLine("Digit a valid number >:(");
                    return;
                }

            }
            else
            {
                Console.WriteLine("Digit a valid number >:(");
                return;
            }

            var mySecretNumber = _random.Next(0, 1000);
            var friendSecretNumber = _random.Next(0, 1000);

            var x = BigInteger.Pow(i, mySecretNumber) % p; //number sended to my friend
            var y = BigInteger.Pow(i, friendSecretNumber) % p; //number received from my friend

            var myGenerateKey = BigInteger.Pow(y, mySecretNumber) % p;
            var friendGenerateKey = BigInteger.Pow(x, friendSecretNumber) % p;

            if (myGenerateKey == friendGenerateKey)
            {
                Console.WriteLine($"Sucess on generate key: {myGenerateKey} == {friendGenerateKey}");
            } 
            else
                Console.WriteLine($"Fail on generate key: {myGenerateKey} != {friendGenerateKey}");
        }
        private bool IsPrime(BigInteger n)
        {
            BigInteger m = n / 2;
            for (BigInteger i = 2; i <= m; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
