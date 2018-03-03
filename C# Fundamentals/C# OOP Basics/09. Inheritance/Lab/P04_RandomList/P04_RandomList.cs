using System;

namespace P04_RandomList
{
    class P04_RandomList
    {
        static void Main(string[] args)
        {
            RandomList rndList = new RandomList();
            rndList.Add("asd");
            rndList.Add("bbb");
            rndList.Add("asafg");
            string strDeleted = rndList.RandomString();
            Console.WriteLine(strDeleted);
        }
    }
}
