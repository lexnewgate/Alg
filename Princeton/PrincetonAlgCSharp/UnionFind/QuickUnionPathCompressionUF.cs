namespace UnionFind
{
    public class QuickUnionPathCompressionUF:IUnionFind
    {
        private int[] m_ids;
        private int[] m_weights;
        private int m_countOfComps;
        public QuickUnionPathCompressionUF(int n)
        {
            m_ids = new int[n];
            m_weights = new int[n];
            m_countOfComps = n;
            for (int i = 0; i < n; i++)
            {
                m_ids[i] = i ;
                m_weights[i] = 1;
            } 
        }
        public void union(int p, int q)
        {
            int pRoot = find(p);
            int qRoot = find(q);
            if (pRoot == qRoot)
            {
                return;
            }

            if (m_weights[pRoot] > m_weights[qRoot])
            {
                m_ids[qRoot] = pRoot;
                m_weights[pRoot] = m_weights[pRoot] + m_weights[qRoot];
            }
            else
            {
                m_ids[pRoot] = qRoot;
                m_weights[qRoot]= m_weights[pRoot] + m_weights[qRoot];
            }

            m_countOfComps--;
        }

        public int find(int p)
        {
            while (p!=m_ids[p])
            {
                m_ids[p] = m_ids[m_ids[p]];
                p = m_ids[p];
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