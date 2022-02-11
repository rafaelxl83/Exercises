using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    /// <summary>
    /// In this problem we consider unsigned 30-bit integers, i.e. all integers B such 
    /// that <![CDATA[0 <= B < 230]]>.
    /// <br/>
    /// We say that integer A conforms to integer B if, in all positions where B has 
    /// bits set to 1, A has corresponding bits set to 1.
    /// <br/>
    /// For example:
    /// <br/>
    /// A 00 0000 1111 0111 1101 1110 0000 1111(BIN) = 16,244,239 conforms to<br/>
    /// B 00 0000 1100 0110 1101 1110 0000 0001(BIN) = 13,032,961, but<br/>
    /// A 11 0000 1101 0111 0000 1010 0000 0101(BIN) = 819,399,173 does not conform to<br/>
    /// B 00 0000 1001 0110 0011 0011 0000 1111(BIN) = 9,843,471.<br/>
    /// <br/><br/>
    /// Solution:
    /// <br/>
    /// You can use the 3-set 
    /// <see cref="https://en.wikipedia.org/wiki/Inclusion%E2%80%93exclusion_principle">inclusion-exclusion principle</see> 
    /// The full principle would be required if you want to generalize to more than 3 numbers.
    /// </summary>
    public class CountConformingBitmasks
    {
        public static int ZeroCount(BitArray b)
        {
            return b.OfType<bool>().Where(i => i == false).Count(); ;
        }

        /// <summary>
        /// Given three unsigned 30-bit integers A, B and C, returns the number of 
        /// unsigned 30-bit integers conforming to at least one of the given integers.
        /// <br/>
        /// For example, for integers:
        /// <br/>
        /// A = 11 1111 1111 1111 1111 1111 1001 1111(BIN) = 1,073,741,727,<br/>
        /// B = 11 1111 1111 1111 1111 1111 0011 1111(BIN) = 1,073,741,631, and<br/>
        /// C = 11 1111 1111 1111 1111 1111 0110 1111(BIN) = 1,073,741,679,<br/>
        /// the function should return 8, since there are 8 unsigned 30-bit integers conforming 
        /// to A, B or C, namely.
        /// <br/>
        /// Complexity: O(log(N))
        /// </summary>
        /// <param name="A">Unsigned 30-bit integers</param>
        /// <param name="B">Unsigned 30-bit integers</param>
        /// <param name="C">Unsigned 30-bit integers</param>
        /// <returns>
        /// The number of unsigned 30-bit integers conforming to at least one of the 
        /// given integers.
        /// </returns>
        public static int GetCountConformingBitmasks(int A, int B, int C)
        {
            double s = 0;
            BitArray bA = new BitArray(new int[] { A });
            BitArray bB = new BitArray(new int[] { B });
            BitArray bC = new BitArray(new int[] { C });

            bA.Length = 30;
            bB.Length = 30;
            bC.Length = 30;

            // include individual items: A, B and C
            s = Math.Pow(2,ZeroCount(bA));
            s += Math.Pow(2, ZeroCount(bB));
            s += Math.Pow(2, ZeroCount(bC));

            // exclude pairs: A|B, A|C and B|C
            BitArray aORb = ((BitArray)bA.Clone()).Or(bB);
            BitArray aORc = ((BitArray)bA.Clone()).Or(bC);
            BitArray bORc = ((BitArray)bB.Clone()).Or(bC);

            s -= Math.Pow(2, ZeroCount(aORb));
            s -= Math.Pow(2, ZeroCount(aORc));
            s -= Math.Pow(2, ZeroCount(bORc));

            // include all 3: A|B|C
            BitArray aORbORc = ((BitArray)bA.Clone()).Or(bB).Or(bC);
            s += Math.Pow(2, ZeroCount(aORbORc));

            return (int)s;
        }
    }
}
