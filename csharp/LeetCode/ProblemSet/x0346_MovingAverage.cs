using System.Collections.Generic;

namespace x0346_MovingAverage
{
    public class MovingAverage
    {
        private int m_size;
        private Queue<int> m_queue;
        private int sum = 0;
        public MovingAverage(int size)
        {
            this.m_size = size;
            this.m_queue = new Queue<int>(size);
        }

        public double Next(int val)
        {
            if (this.m_queue.Count == this.m_size)
            {
                var v = m_queue.Dequeue();
                m_queue.Enqueue(val);
                sum = sum - v + val;
            }
            else
            {
                m_queue.Enqueue(val);
                sum += val;
            }

            return (double)sum / this.m_queue.Count;
        }
    }


}
