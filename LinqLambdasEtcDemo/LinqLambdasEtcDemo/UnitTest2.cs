using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace LinqLambdasEtcDemo
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] items = { 1, 2, 3, 4, 5, 6 };
            
            items.Where(i => i % 2 == 0).Print();
            MyExtensionMethods.Print(items.Where(i => i % 2 == 0));
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        [TestMethod]
        public void MyTestMethod()
        {
            var people = new List<Person>
            {
                new Person { Name = "Manuel", Age = 31 },
                new Person { Name = "Ezra", Age = 4 }
            };

            var result = people.Where(p => p.Age > 4).Select(p => p.Name);
            result.Print();
        }
    }
}
