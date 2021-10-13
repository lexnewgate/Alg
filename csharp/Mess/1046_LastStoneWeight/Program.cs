using System;

namespace _1046_LastStoneWeight
{
    public class Solution
    {
        class MaxPQ
        {
            private int[] pq;
            private int count;
            public MaxPQ(int[] keys)
            {
                count = keys.Length;
                pq = new int[count + 1];
                for (int i = 0; i < count; i++)
                {
                    pq[i + 1] = keys[i];
                }

                int start = count / 2;
                for (int i = start; i >= 0; i--)
                {
                    Sink(i);
                }
            }

            public bool IsEmpty()
            {
                return count == 0;
            }

            public int Count()
            {
                return count;
            }

            public int RemoveMax()
            {
                int max = pq[0];
                pq[0] = pq[count];
                count--;
                Sink(0);
                return max;
            }

            public void Insert(int key)
            {
                count++;
                pq[count] = key;
                Swim(count);
            }

            private void Sink(int k)
            {
                while (2 * k <= count)
                {
                    int j = 2 * k;
                    if (j < count && Less(j, j + 1))
                    {
                        j++;
                    }

                    if (Less(k, j))
                    {
                        Exch(k, j);
                        k = j;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void Exch(int i, int j)
            {
                int temp = pq[i];
                pq[i] = pq[j];
                pq[j] = temp;
            }

            private bool Less(int i, int j)
            {
                if (pq[i] < pq[j])
                {
                    return true;
                }

                return false;
            }

            private void Swim(int k)
            {
                while (k != 0)
                {
                    int r = k / 2;
                    if (Less(r, k))
                    {
                        Exch(r, k);
                        k = r;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }


        public int LastStoneWeight(int[] stones)
        {
            MaxPQ maxPQ = new MaxPQ(stones);
            while (maxPQ.Count() >= 2)
            {
                int x = maxPQ.RemoveMax();
                int y = maxPQ.RemoveMax();
                if (x != y)
                {
                    maxPQ.Insert(Math.Abs(x - y));
                }
            }

            if (maxPQ.IsEmpty())
            {
                return 0;
            }
            else
            {
                return maxPQ.RemoveMax();
            }


        }
        static void Main(string[] args)
        {
            int[] stonesWeights = { 2, 7, 4, 1, 8, 1 };
            Console.WriteLine(new Solution().LastStoneWeight(stonesWeights));


        }
    }
}
