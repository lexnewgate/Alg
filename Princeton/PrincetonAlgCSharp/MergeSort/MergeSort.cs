using System;

namespace Sort
{
    public class MergeSort
    {
        public static int[] Sort(int[] source)
        {
            //base case
            if (source.Length == 1)
            {
                return new[] {source[0]};
            }

            //recursive 
            int nFirstHalf = source.Length / 2;
            int nSecHalf = source.Length - nFirstHalf;

            int i = 0;
            int[] firstArr = new int[nFirstHalf];
            int[] secArr = new int[nSecHalf];
            for (int j = 0; j < nFirstHalf; j++, i++)
            {
                firstArr[j] = source[i];
            }

            for (int j = 0; j < nSecHalf; j++, i++)
            {
                secArr[j] = source[i];
            }

            var firstSortedArr = Sort(firstArr);
            var secSortedArr = Sort(secArr);

            return Merge(firstSortedArr, secSortedArr);
        }


        private static int[] Merge(int[] sourceA, int[] sourceB)
        {
            int a = sourceA.Length;
            int b = sourceB.Length;
            int[] mergedArr = new int[a + b];
            for (int i = 0, k = 0, j = 0; i < mergedArr.Length; i++)
            {
                if (k < b && j < a)
                {
                    if (sourceA[j] < sourceB[k])
                    {
                        mergedArr[i] = sourceA[j];
                        j++;
                    }
                    else
                    {
                        mergedArr[i] = sourceB[k];
                        k++;
                    }
                }
                else
                {
                    if (j == a)
                    {
                        while (k < b)
                        {
                            mergedArr[i] = sourceB[k];
                            k++;
                            i++;
                        }
                    }
                    else
                    {
                        while (j < a)
                        {
                            mergedArr[i] = sourceA[j];
                            j++;
                            i++;
                        }
                    }
                }
            }

            return mergedArr;
        }
    }
}