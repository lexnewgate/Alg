namespace Lex.Alg
{
    public class UnionFind
    {
        int[] m_parents;
        int[] m_weights;
        /// <summary>
        /// 分量数量
        /// </summary>
        int m_count;
        
        public UnionFind(int n)
        {
            this.m_count = n;
            this.m_parents = new int[n];
            this.m_weights = new int[n];
            for (int i = 0; i < n; i++)
            {
                this.m_parents[i] = i;
                this.m_weights[i] = 1;
            }
        }

        public void Union(int p,int q)
        {
            int pRoot = Find(p);
            int qRoot = Find(q);

            if (pRoot == qRoot)
            {
                return;
            }

            this.m_count--;
            if (this.m_weights[pRoot] > this.m_weights[qRoot])
            {
                this.m_parents[qRoot] = pRoot;
                this.m_weights[pRoot] += this.m_weights[qRoot];
            }
            else
            {
                this.m_parents[pRoot] = qRoot;
                this.m_weights[qRoot] += this.m_weights[pRoot];
            }
        }

        int Find(int p)
        {
            int root = p;
            while (root!=this.m_parents[root])
            {
                root = this.m_parents[root];
            }

            while (p!=root)
            {
                var oldParent = this.m_parents[p];
                this.m_parents[p] = root;
                p = oldParent;
            }

            return root;
        }

        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        /// <summary>
        /// 连通组的数量
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return m_count;
        }

    }
}