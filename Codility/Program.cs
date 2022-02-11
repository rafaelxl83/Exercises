using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
