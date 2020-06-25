using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFibannoci
{
    class PrimeFibannoci
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();
            string[] strvals = values.Split(' ');
            int starting = Convert.ToInt32(strvals[0]);
            int ending = Convert.ToInt32(strvals[1]);

            List<int> primeList = GetPrimes(starting, ending);
            HashSet<int> combinationArr = new HashSet<int>();

            for (int i = 0; i < primeList.Count; i++)
            {
                for(int j = 0; j < primeList.Count; j++)
                {
                    if(primeList[i] != primeList[j])
                    {
                        combinationArr.Add(Convert.ToInt32(primeList[i].ToString() + primeList[j].ToString()));
                    }
                }
            }

            List<int> finalprimeList = GetPrimes(combinationArr);

            int smallest = finalprimeList.Min();
            int largest = finalprimeList.Max();
            int listCount = finalprimeList.Count;

            Console.Write(GetOutput(smallest, largest, listCount));
            
            Console.ReadLine();
        }

        private static string GetOutput(int smallest, int largest, int listCount)
        {
            long result = 0;
            long a = smallest;
            long b = largest;
            for (int i = 0; i < listCount-2; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }
            return result.ToString();
        }

        private static List<int> GetPrimes(HashSet<int> combinationArr)
        {
            List<int> temp = new List<int>();
            foreach(int a in combinationArr)
            {
                if (Chkprime(a))
                {
                    temp.Add(a);
                }
            }
            return temp;
        }

        private static List<int> GetPrimes(int starting, int ending)
        {
            List<int> temp = new List<int>();
            for(int i = starting; i <= ending; i++)
            {
                if (Chkprime(i))
                {
                    temp.Add(i);
                }
            }
            return temp;
        }
        public static bool Chkprime(int num)
        {
            for (int i = 2; i < num; i++)
                if (num % i == 0)
                    return false;
            return true;
        }
    }
}
