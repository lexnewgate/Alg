using System;
using System.Collections.Generic;

namespace x0542_UpdateMatrix
{
    //todo last failed date: 2021-03-20
    //need redo BFS 
    //need redo DP
    public class Solution
    {
        private int m_r;
        private int m_c;

        public int[][] UpdateMatrix(int[][] matrix)
        {
            int[][] ret = new int[matrix.Length][];
            m_r = matrix.Length;
            m_c = matrix[0].Length;
            //IVisitedRecord<Record> visitedRecord = new VisitedRecord(m_r, m_c);
            IVisitedRecord<Record> visitedRecord = new HashVisitedRecord();
            for (int i = 0; i < m_r; i++)
            {
                ret[i] = new int[m_c];
                for (int j = 0; j < m_c; j++)
                {
                    ret[i][j] = -1;
                }
            }

            for (int i = 0; i < m_r; i++)
            {
                for (int j = 0; j < m_c; j++)
                {
                    visitedRecord.Clear();
                    BFS(ret, matrix, i, j,visitedRecord);
                }
            }

            return ret;
        }

        /// <summary>
        /// Assume cur record is valid
        /// </summary>
        /// <param name="cur"></param>
        /// <returns></returns>
        IEnumerable<Record> GetNeighbours(Record cur)
        {
            int curx = cur.X;
            int cury = cur.Y;
            //up 
            int upx = curx;
            int upy = cury - 1;
            if (upy >= 0 )
            {
                yield return  new Record(upx,upy);
            }

            //bot
            int botx = curx;
            int boty = cury + 1;
            if (boty < this.m_r)
            {
                yield return new Record(botx,boty);
            }

            //left
            int leftx = curx - 1;
            int lefty = cury;
            if (leftx >= 0)
            {
                yield return new Record(leftx,lefty);
            }

            //right
            int rightx = curx + 1;
            int righty = cury;
            if (rightx < this.m_c)
            {
                yield return new Record(rightx,righty);
            }
    }



        public void BFS(int[][] ret, int[][] matrix, int y, int x,IVisitedRecord<Record>visited)
        {
            Queue<Record> queue = new Queue<Record>();
            Queue<Record> tempQueue = new Queue<Record>();
            int len = 0;
            var startRecord=new Record(x,y);
            queue.Enqueue(startRecord);
            visited.SetVisited(startRecord);
            while (queue.Count != 0)
            {
                while (queue.Count != 0)
                {
                    Record record = queue.Dequeue();
                    if (matrix[record.Y][record.X] == 0)
                    {
                        ret[y][x] = len;
                        return;
                    }

                    foreach (var neighbour in GetNeighbours(record))
                    {
                        if (!visited.IsVisited(neighbour))
                        {
                            visited.SetVisited(neighbour);
                            tempQueue.Enqueue(neighbour);
                        }
                    }
                }

                (queue, tempQueue) = (tempQueue, queue);
                len++;
            }
        }

        public interface IVisitedRecord<T>
        {
            bool IsVisited(T val);
            void SetVisited(T val);
            void Clear();
        }

        public class Record
        {
            public int X { get; }
            public int Y { get; }

            public Record(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public class HashVisitedRecord:IVisitedRecord<Record>
        {
            class CustomCompare:IEqualityComparer<Record>
            {
                public bool Equals(Record x, Record y)
                {
                    if (ReferenceEquals(x, y)) return true;
                    if (ReferenceEquals(x, null)) return false;
                    if (ReferenceEquals(y, null)) return false;
                    if (x.GetType() != y.GetType()) return false;
                    return x.X == y.X && x.Y == y.Y;
                }

                public int GetHashCode(Record obj)
                {
                    unchecked
                    {
                        return (obj.X * 397) ^ obj.Y;
                    }
                }
            }


            private HashSet<Record> m_hashSet;
            public HashVisitedRecord()
            {
                m_hashSet=new HashSet<Record>(new CustomCompare());
            }

            public bool IsVisited(Record val)
            {
                return m_hashSet.Contains(val);
            }

            public void SetVisited(Record val)
            {
                m_hashSet.Add(val);
            }

            public void Clear()
            {
            m_hashSet.Clear();
            }
        }

        public class VisitedRecord : IVisitedRecord<Record>
        {
            private int m_r;
            private int m_c;
            private int[][] m_visitedSet;

            public VisitedRecord(int r, int c)
            {
                this.m_r = r;
                this.m_c = c;
                this.m_visitedSet=new int[r][];
                for (int i = 0; i < r; i++)
                {
                    this.m_visitedSet[i]=new int[c];
                }

            }
            public bool IsVisited(Record val)
            {
                return m_visitedSet[val.Y][val.X] != 0;
            }

            public void SetVisited(Record val)
            {
                this.m_visitedSet[val.Y][val.X] = 1;
            }

            public void Clear()
            {
                for (int i = 0; i < m_r; i++)
                {
                    for (int j = 0; j < m_c; j++)
                    {
                        m_visitedSet[i][j] = 0;
                    }
                }
            }
        }
}
}
