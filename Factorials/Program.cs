using System;
using System.Numerics;

namespace Program{

    class Program{

        // limit of 5045
        static BigInteger getFactorial(BigInteger num){
            if (num != 0){
                return num * getFactorial(num - 1);
            } else {
                return (BigInteger)1;
            }
        }
 
        static void Main(string[] args){
            BigInteger num;
            do{
                Console.WriteLine("Enter Number");                
            } while (!BigInteger.TryParse(Console.ReadLine(), out num));
            BigInteger factorial = getFactorial(num);
            Console.WriteLine($"Factorial of {num} is {factorial}");
        }
    }
}