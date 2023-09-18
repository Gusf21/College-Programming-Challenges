using System;

namespace testing {
    
    class Program {
    
        static void Main(string[] args) {
            List<int> sequence = new List<int>{};
            sequence.Add(0);
            sequence.Add(1);
            for (int i = 0; i < 30; i++) {
                int len = sequence.Count();
                sequence.Add(sequence[len-1] + sequence[len -2]);
            }
            foreach (int num in sequence) {
                Console.WriteLine(num);
            }
            Console.ReadLine();
        }
    }
}