using Antinew.AspNetCore3._1.Interface;
using System;

namespace Antinew.AspNetCore3._1.Implement
{
    public class TestServiceB : ITestServiceB
    {
        public TestServiceB(ITestServiceA iTestServiceA)
        {
            Console.WriteLine($"{this.GetType().Name}被构造。。。");
        }


        public void Show()
        {
            Console.WriteLine($"This is TestServiceB B123456");
        }
    }
}
