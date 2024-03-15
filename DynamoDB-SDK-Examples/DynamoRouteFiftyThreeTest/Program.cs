using System;
using System.Threading.Tasks;
using DotnetSamples;

namespace DynamoRouteFiftyThreeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var testddb = new DotnetSamples.DynamoR53ConnectionTestClass();

            var task3 = testddb.DynamoRoute53PutItemTest1();
            task3.Wait();            
        }
    }
}
