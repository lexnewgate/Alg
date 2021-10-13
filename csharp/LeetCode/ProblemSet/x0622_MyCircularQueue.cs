/// <summary>
/// todo: 数组实现时尝试使用Capacity而非尾部.会让代码更清晰
/// </summary>
public class MyCircularQueue
{
    /** Initialize your data structure here. Set the size of the queue to be k. */
    public MyCircularQueue(int k)
    {
        m_data = new int[k];
        m_size = k;
        m_start = m_end = -1;
    }

    /** Insert an element into the circular queue. Return true if the operation is successful. */
    public bool EnQueue(int value)
    { 
        if(IsFull())
        {
            return false;
        }

        //如果为空的话,同时操作head和start
        if (IsEmpty())
        {
            this.m_start = this.m_end = 0;
        }
        else//否则只关注尾部
        {
            this.m_end = (this.m_end + 1) % this.m_size;
        }

        this.m_data[this.m_end] = value;
        return true;
    }

    /** Delete an element from the circular queue. Return true if the operation is successful. */
    public bool DeQueue()
    {
        if (IsEmpty())
        {
            return false;
        }

        //队列里只有一个元素
        if (this.m_start == this.m_end)
        {
            this.m_start = this.m_end = -1;
        }
        else//不止一个元素. 我们只用关心头部即可
        {
            this.m_start = (this.m_start + 1) % this.m_size;
        }

        return true;
    }

    /// <summary>
    /// 为空则返回-1
    /// </summary>
    public int Front()
    {
        if (IsEmpty())
        {
            return -1;
        }
        return m_data[m_start];
    }

    /// <summary>
    /// 为空则返回-1
    /// </summary>
    public int Rear()
    {
        if (IsEmpty())
        {
            return -1;
        }
        return m_data[m_end];
    }

    /** Checks whether the circular queue is empty or not. */
    public bool IsEmpty()
    {
       return m_end == -1;
    }

    /** Checks whether the circular queue is full or not. */
    public bool IsFull()
    {
        return ((m_end + 1) % m_size) == m_start;
    }

    private int[] m_data;
    /// <summary>
    /// 从头部拿出
    /// </summary>
    private int m_start;
    /// <summary>
    /// 从尾部插入
    /// </summary>
    private int m_end;
    private readonly int m_size;
}