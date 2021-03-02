using Antinew.AspNetCore3._1.Interface;
using System;

namespace Antinew.AspNetCore3._1.Implement
{
    public class TestServiceD : ITestServiceD
    {
        public TestServiceD()
        {
            Console.WriteLine($"{this.GetType().Name}被构造。。。");
        }
        public void Show()
        {
            Console.WriteLine("D123456");
        }
    }
}
