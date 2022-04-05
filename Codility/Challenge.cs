using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    internal class Challenge
    {
        /// <summary>
        /// An incorrect implementation of a function that should return 
        /// the smallest integer from a given array.
        /// </summary>
        /// <param name="A">a given array</param>
        /// <returns>can returns a wrong answer.</returns>
        public static int find_min(int[] A)
        {
            int ans = 0;
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] < ans)
                {
                    ans = A[i];
                }
            }
            return ans;
        }

        /// <summary>
        /// Given an integer N, returns an array A consisting of N integers 
        /// witch describes a counterexample as a wrong return of the function
        /// <see cref="@find_min"/>.
        /// <br/>
        /// </summary>
        /// <param name="N">an integer N</param>
        /// <returns>an array A consisting of N integers</returns>
        public static int[] solution1(int N)
        {
            int Min = 1;
            int Max = 1000;

            int[] test2 = new int[N];
            Random randNum = new Random();
            do
            {
                for (int i = 0; i < N; i++)
                    test2[i] = randNum.Next(Min, Max);
            }
            while (find_min(test2) == test2.Min());
            return test2;
        }

        /// <summary>
        /// The goal is to find the minimum subarray in A that contains set(A). 
        /// In other words, our goal is to try and find a minimum window in A 
        /// that contains all the elements (vacation locations) in A.
        /// <br/>
        /// Complexity: O(2n) time and O(n) space
        /// </summary>
        /// <param name="A">an array A consisting of N integers</param>
        /// <returns>the minimum subarray length</returns>
        public static int solution2(int[] A)
        {
            // creates a set like the following sample:
            // array: [2, 1, 1, 3, 2, 1, 1, 3]
            // result: {0 [2,1]}, {1 [1,1]}, {2 [3,1]}
            var needed = new HashSet<int>(A).ToDictionary(val => val, val => 1);
            int missing = needed.Count;

            // create start and end windows for the current window
            // as well as for the result window
            int cur_i = 0;
            int result_i = 0;
            int result_j = 0;

            foreach (var it in A.Select((Value, Index) => new { Value, Index }))
            {
                int cur_j = it.Index;
                int num = it.Value;

                // if the location hasnt been visited before 
                // subtract from visited list
                if (needed[num] > 0)
                    missing -= 1;

                // number of times its been visited across
                needed[num] -= 1;

                // once all locations are visited at least once
                // we need to minimize the length of the window
                if (missing == 0)
                {
                    // needed[A[cur_i]] < 0 implies that there exists
                    // within our window some duplicates for A[cur_i]
                    // so adjust cur_i to remove these duplicates 
                    while (cur_i < cur_j && needed[A[cur_i]] < 0)
                    {
                        needed[A[cur_i]] += 1;
                        cur_i += 1;
                    }
                    // update the maximum length of the current window
                    if (result_j == 0 || cur_j - cur_i <= result_j - result_i)
                    {
                        result_i = cur_i;
                        result_j = cur_j;
                    }
                }
            }

            // Index starts at position 0
            return result_j - result_i + 1;
        }

    }
}
