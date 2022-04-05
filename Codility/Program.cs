using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Codility
{
    internal class Program
    {
        class A { }
        class B
        {
            public static void Foo()
            {
                object a = new A();
                B b = null;
                try
                {
                    b = (B)a;
                    Console.WriteLine("1");
                }
                catch (Exception) { }

                try
                {
                    b = a as B;
                    Console.WriteLine("2");
                }
                catch (Exception) { }
                if (a is B)
                    Console.WriteLine("3");
            }

            public static IEnumerable<string> Integers()
            {
                yield return "1";
                yield return "2";
                yield return "3";
                yield return "4";
            }
        }

        //public class Ordered<T> : IEnumerable<T>
        //{
        //    public bool IsSorted<T>(this IEnumerable<T> collection, IComparer<T> comparer)
        //    {
        //        System.Diagnostics.Contracts.Contract.Requires(collection != null);
        //        using (var enumerator = collection.GetEnumerator())
        //        {
        //            if (enumerator.MoveNext())
        //            {
        //                var previous = enumerator.Current;

        //                while (enumerator.MoveNext())
        //                {
        //                    var current = enumerator.Current;

        //                    if (comparer.Compare(previous, current) >= 0)
        //                        return false;

        //                    previous = current;
        //                }
        //            }
        //        }

        //        return true;
        //    }
        //}

        static void PrintDigits()
        {
            for (int i = 1; i <= 4; i++)
            {
                Thread t = new Thread(delegate () { Console.Write(i); });
                t.Start();
            }
        }

        static void Main(string[] args)
        {
            PrintDigits();

            

            B.Foo();
            Console.WriteLine(B.Integers().Count());
            Console.WriteLine(B.Integers());
            Console.WriteLine(B.Integers());
            Console.WriteLine(B.Integers().Count());

            Console.WriteLine("Challenge - task1: counter example\n" +
                    string.Join(",", Challenge.solution1(4))
                );

            Console.WriteLine("Challenge - task2: maximum length\n" +
                    Challenge.solution2(new int[] {2, 1, 1, 3, 2, 1, 1, 3})
                );

            Console.WriteLine("Binary Gaps\n" +
                BinaryGap.GetBinaryGap(9) + " \n" +
                BinaryGap.GetBinaryGap(529) + " \n" +
                BinaryGap.GetBinaryGap(20) + " \n" +
                BinaryGap.GetBinaryGap(15) + " \n" +
                BinaryGap.GetBinaryGap(32)
                );

            Console.WriteLine("Count Conforming Bitmasks\n" +
                CountConformingBitmasks.GetCountConformingBitmasks(
                    1073741727, 1073741631, 1073741679) + "\n" +
                CountConformingBitmasks.GetCountConformingBitmasks(
                    1073741727, 1073741759, 1073741791) + "\n" +
                CountConformingBitmasks.GetCountConformingBitmasks(
                    1073741791, 1073741807, 1073741823) + "\n" +
                CountConformingBitmasks.GetCountConformingBitmasks(
                    1072693248, 1047552, 1023)
            );

            Console.WriteLine("Sparse Binary Decomposition\n" +
                SparseBinaryDecomposition.GetSparseBinaryDecomposition(26) + "\n" +
                SparseBinaryDecomposition.GetSparseBinaryDecomposition(5) + "\n" +
                SparseBinaryDecomposition.GetSparseBinaryDecomposition(7) + "\n" +
                SparseBinaryDecomposition.GetSparseBinaryDecomposition(154) + "\n" +
                SparseBinaryDecomposition.GetSparseBinaryDecomposition(0) + "\n" +
                SparseBinaryDecomposition.GetSparseBinaryDecomposition(1) + "\n" +
                SparseBinaryDecomposition.GetSparseBinaryDecomposition(180) + "\n" +
                SparseBinaryDecomposition.GetSparseBinaryDecomposition(2345) + "\n" +
                SparseBinaryDecomposition.GetSparseBinaryDecomposition(536870912) + "\n" +
                SparseBinaryDecomposition.GetSparseBinaryDecomposition(216188401) + "\n" +
                SparseBinaryDecomposition.GetSparseBinaryDecomposition(74901729)
                );

            Console.ReadLine();
        }
    }
}
