namespace UnionFind
{
    public class QuickUnionUF:IUnionFind
    {
        private int[] m_id;
        private int m_countOfComps;
        
        public QuickUnionUF(int n)
        {
            m_id = new int[n];
            m_countOfComps = n;
            for (int i = 0; i < n; i++)
            {
                m_id[i] = i ;
            }
        }

        public void union(int p, int q)
        {
            int proot = find(p);
            int qroot = find(q);
            if (proot == qroot)
            {
                return;
            }

            m_countOfComps--;
            m_id[proot] = qroot;
        }

        public int find(int p)
        {
            while (p!=m_id[p])
            {
                p = m_id[p];
            }

            return p;
        }

        public bool connected(int p, int q)
        {
            return find(p) == find(q);
        }

        public int count()
        {
            return m_countOfComps;
        }
    }
}