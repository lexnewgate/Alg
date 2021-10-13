public class MyCircularQueue
{
    private int[] m_mem;
    private int m_head;
    private int m_tail;
    private int m_count;
    private int m_size;

    public MyCircularQueue(int k)
    {
        m_mem = new int[k];
        this.m_size = k;
    }

    public bool EnQueue(int value)
    {
        if (IsFull())
        {
            return false;
        }

        if (IsEmpty())
        {
            m_head = m_tail = 0;
            m_mem[0] = value;
        }
        else
        {
            m_tail++;
            m_tail %= m_size;
            m_mem[m_tail] = value;
        }

        m_count++;
        return true;
    }

    public bool DeQueue()
    {
        if (IsEmpty())
        {
            return false;
        }

        if (m_count == 1)
        {
            m_tail = m_head = 0;
        }
        else
        {
            m_head++;
            m_head %= m_size;
        }

        m_count--;
        return true;
    }

    public int Front()
    {
        if (IsEmpty())
        {
            return -1;
        }

        return m_mem[m_head];

    }

    public int Rear()
    {
        if (IsEmpty())
        {
            return -1;
        }

        return m_mem[m_tail];

    }

    public bool IsEmpty()
    {
        return m_count == 0;
    }

    public bool IsFull()
    {
        return m_count == m_size;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */