using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    /// <summary>
    /// A binary gap within a positive integer N is any maximal sequence of consecutive 
    /// zeros that is surrounded by ones at both ends in the binary representation of N.
    /// <br/>
    /// For example, number 9 has binary representation 1001 and contains a binary gap  
    /// of length 2. The number 529 has binary representation 1000010001 and contains   
    /// two binary gaps: one of length 4 and one of length 3. The number 20 has binary  
    /// representation 10100 and contains one binary gap of length 1. The number 15 has 
    /// binary representation 1111 and has no binary gaps. The number 32 has binary     
    /// representation 100000 and has no binary gaps.
    /// </summary>
    public class BinaryGap
    {
        public static void PrintValues(IEnumerable myList, int myWidth)
        {
            int i = myWidth;
            foreach (Object obj in myList)
            {
                if (i <= 0)
                {
                    i = myWidth;
                    Console.Write("\t");
                }
                else if (i != myWidth) 
                    Console.Write("|");

                i--;
                Console.Write("{0}", obj);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Given a positive integer N, returns the length of its longest binary gap.
        /// <br/>
        /// Complexity: O(N).
        /// </summary>
        /// <param name="N">A positive integer</param>
        /// <returns>Length of its longest binary gap</returns>
        public static int GetBinaryGap(int N)
        {
            String binary = Convert.ToString(N, 2);

            int gap = 0, longest = 0;
            foreach(char c in binary)
            {
                if(c == '0')
                    gap++;
                else
                {
                    if(gap > longest)
                        longest = gap;
                    gap = 0;
                }
            }

            //BitArray b = new BitArray(new int[] { N });
            //Console.WriteLine(b.Count);
            //bool[] bits = new bool[b.Count];
            //b.CopyTo(bits, 0);
            //PrintValues(bits, 8);
            return longest;
        }

    }
}
