using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LinqLambdasEtcDemo
{
    delegate void MyDelegate(int input);
    delegate void MyDelegate<T>(T input);
    delegate void MyDelegate<T1, T2>(T1 input1, T2 input2);

    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void SimpleStandardDelegate()
        {
            ExecuteMyDelegate(new MyDelegate(Console.WriteLine));
        }

        [TestMethod]
        public void SimpleStandardDelegateSomewhatAbbreviated()
        {
            ExecuteMyDelegate(Console.WriteLine);
        }

        [TestMethod]
        public void GenericDelegate()
        {
            ExecuteMyDelegateGeneric(Console.WriteLine);
        }

        [TestMethod]
        public void ActionDemo()
        {
            ExecuteAction(Console.WriteLine);
        }

        

        private static void ExecuteMyDelegate(MyDelegate m)
        {
            m(13);
        }

        private static void ExecuteMyDelegateGeneric(MyDelegate<int> m)
        {
            m(13);
        }

        private static void ExecuteAction(Action<int> a)
        {
            a(13);
        }

        [TestMethod]
        public void TestPrintSquare()
        {
            ExecuteAction(PrintSquare);
        }

        void PrintSquare(int m)
        {
            Console.WriteLine(m * m);
        }

        [TestMethod]
        public void AnonymousDelegate()
        {
            ExecuteAction(delegate(int m) { Console.WriteLine(m * m); });
        }

        [TestMethod]
        public void TestWhereWithCustomEnumerator()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var output = Where(input, delegate(int item) { return item % 2 == 0; });

            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void TestWhereWithYield()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var output = WhereWithYield(input, delegate(int item) { return item % 2 == 0; });

            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<T> Where<T>(IEnumerable<T> input, Predicate<T> predicate)
        {
            return new MyEnumerable<T>(input, predicate);
        }

        class MyEnumerable<T> : IEnumerable<T>
        {
            private IEnumerable<T> input;
            private Predicate<T> predicate;


            public MyEnumerable(IEnumerable<T> input, Predicate<T> predicate)
            {
                this.input = input;
                this.predicate = predicate;
            }

            class MyEnumerator : IEnumerator<T>
            {
                private IEnumerator<T> input;
                private Predicate<T> predicate;


                public MyEnumerator(IEnumerable<T> input, Predicate<T> predicate)
                {
                    this.input = input.GetEnumerator();
                    this.predicate = predicate;
                }

                public T Current
                {
                    get
                    {
                        return input.Current;
                    }
                }

                public void Dispose()
                {
                    input.Dispose();
                }

                object System.Collections.IEnumerator.Current
                {
                    get { return Current; }
                }

                public bool MoveNext()
                {
                    bool hasNext = true;
                    while ((hasNext = input.MoveNext()) && 
                        !predicate(input.Current))
                    {
                    }

                    return hasNext;
                }

                public void Reset()
                {
                    input.Reset();
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new MyEnumerator(input, predicate);
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private static IEnumerable<T> WhereWithYield<T>(IEnumerable<T> input, Predicate<T> predicate)
        {
            foreach (var item in input)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        [TestMethod]
        public void FilterWithLamdba()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var output = WhereWithYield(input, item =>  item % 2 == 0);
            //var output = WhereWithYield(input, (int item) => item % 2 == 0);
            //var output = WhereWithYield(input, (int item) => { return item % 2 == 0; });

            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        public void ExpressionsInsteadofLambda()
        {
            //ExecuteExpression(Console.Write);
            ExecuteExpression(m => Console.Write(m * m));
        }

        private static void ExecuteExpression(Expression<Action<int>> m)
        {
            m.Compile()(13);
        }
    }
}
