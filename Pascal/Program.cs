using System;

namespace Program{
    class Program{

        static int getNum(int row, int column){
            //Console.WriteLine("Recursing");
            //Console.WriteLine($"row = {row}, column = {column}");
            if (column == 0 || row == column){
                return 1;
            } else {
                return getNum(row-1, column-1) + getNum(row-1, column);
            }
        }

        static List<int> getRow(int rowNum){
            List<int> row = new List<int>();
            for(int i = 0; i < rowNum+1; i++) {
                int temp = getNum(rowNum, i); 
                row.Add(temp);
                //Console.WriteLine(temp);
            }
            return row;
        }

        static void Main(string[] args){
            List<int> row = getRow(20);
            foreach (int rowVal in row){
                Console.WriteLine(rowVal);
            }
            Console.ReadLine();
        }
    }
}