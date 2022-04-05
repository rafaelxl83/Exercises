using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    /// <summary>
    /// A non-negative integer N is called sparse if its binary representation does not 
    /// contain two consecutive bits set to 1. For example, 41 is sparse, because its 
    /// binary representation is "101001" and it does not contain two consecutive 1s. 
    /// On the other hand, 26 is not sparse, because its binary representation is 
    /// "11010" and it contains two consecutive 1s.
    /// <br/>
    /// Two non-negative integers P and Q are called a sparse decomposition of integer 
    /// N if P and Q are sparse and N = P + Q.
    /// <br/>
    /// For example:
    /// <br/>
    /// 8 and 18 are a sparse decomposition of 26 (binary representation of 8 is "1000", 
    /// binary representation of 18 is "10010");<br/>
    /// 9 and 17 are a sparse decomposition of 26 (binary representation of 9 is "1001", 
    /// binary representation of 17 is "10001");<br/>
    /// 2 and 24 are not a sparse decomposition of 26; though 2 + 24 = 26, 
    /// the binary representation of 24 is "11000", which is not sparse.<br/>
    /// </summary>
    public class SparseBinaryDecomposition
    {
        public static bool IsSparseNumber(int n)
        {
            // n is not sparse if there
            // is set in AND of n and n/2
            if ((n & (n >> 1)) >= 1)
                return false;

            return true;
        }

        public static int CalculateMask(int n)
        {
            int idx = (int)Math.Ceiling(Math.Log(n, 2));
            int mask = (int)Math.Pow(2, idx) - 1;

            bool zero = true;
            while (idx >= 0)
            {
                if (zero)
                    mask -= (int)Math.Ceiling(Math.Pow(2, idx));

                zero = !zero;
                idx--;
            }

            return mask;
        }

        public static int GetNextSparse(int n)
        {
            // Find binary representation of x and store it in binaries.get(].
            // binaries.get(0] contains least significant bit (LSB), next
            // bit is in binaries.get(1], and so on.
            ArrayList binaries = new ArrayList();
            
            while (n != 0)
            {
                binaries.Add(n & 1);
                n >>= 1;
            }

            // There my be extra bit in result, so add one extra bit
            binaries.Add(0);
            int size = binaries.Count; // Size of binary representation

            // The position till which all bits are finalized
            int last = 0;

            // Start from second bit (next to LSB)
            for (int i = 1; i < size - 1; i++)
            {
                // If current bit and its previous bit are 1, but next
                // bit is not 1.
                if ((int)binaries[i] == 1 && (int)binaries[i - 1] == 1 && (int)binaries[i + 1] != 1)
                {
                    // Make the next bit 1
                    binaries[i + 1] = 1;

                    // Make all bits before current bit as 0 to make
                    // sure that we get the smallest next number
                    for (int j = i; j >= last; j--)
                        binaries[j] = 0;

                    // Store position of the bit set so that this bit
                    // and bits before it are not changed next time.
                    last = i + 1;
                }
            }

            // Find decimal equivalent of modified bin.get(]
            int result = 0;
            for (int i = 0; i < size; i++)
                result += (int)binaries[i] * (1 << i);
            return result;
        }

        /// <summary>
        /// Given a non-negative integer N, returns any integer that is one part of a 
        /// sparse decomposition of N. The function should return −1 if there is no 
        /// sparse decomposition of N.
        /// <br/>
        /// Complexity: O(log(N))
        /// </summary>
        /// <param name="N">non-negative integer</param>
        /// <returns>−1 if there is no sparse decomposition of N</returns>
        public static int GetSparseBinaryDecomposition(int N)
        {
            if (N <= 2) return N;
            if (N == 3) return 1;
            if (IsSparseNumber(N))  return 0;

            return N & CalculateMask(N);
        }

        /// <summary>
        /// Complexity: O(N * log(N))
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int GetSparseBinaryDecomposition1(int N)
        {
            int part1 = 1, part2;

            if (N <= 2) return N;
            if (N == 3) return 1;
            if (IsSparseNumber(N))  return 0;

            for (int i = 0; i < N; i++)
            {
                part1 = i;
                if (IsSparseNumber(part1))
                {
                    part2 = N - part1;
                    if (IsSparseNumber(part2))
                        return part1;
                }
            }

            return -1;
        }

        /// <summary>
        /// Complexity: O(N * log(N))
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int GetSparseBinaryDecomposition2(int N)
        {
            int part1 = 1, part2;

            if (N <= 2) return N;
            if (N == 3) return 1;
            if (IsSparseNumber(N)) return 0;

            do
            {
                if (IsSparseNumber(part1))
                {
                    part2 = N - part1;
                    if (IsSparseNumber(part2))
                        return part1;
                }
                part1 = GetNextSparse(++part1);
            } while (part1 < N);

            return -1;
        }
    }
}
