namespace UnionFind
{
    public class QuickFindUF:IUnionFind
    {
        private int[] m_id;
        private int m_countOfComps;
        public QuickFindUF(int n)
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
            int pid = find(p);
            int qid = find(q);

            if (pid == qid)
            {
                return;
            }

            m_countOfComps--;
            
            for (int i = 0; i < m_id.Length; i++)
            {
                if (m_id[i]==pid)
                {
                    m_id[i] = qid;
                }
            }
        }

        public int find(int p)
        {
            return m_id[p];
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