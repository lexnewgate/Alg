namespace Lex.Alg
{
    public static class Misc
    {
        /// <summary>
        /// 返回众数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Mode(int []nums)
        {
            int candidate=0;
            int count=0 ;
            for (int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    candidate = nums[i];
                    count++;
                    continue;
                }
                
                if (nums[i] != candidate)
                {
                    count--;
                }
                else
                {
                    count++;
                }
            }

            return candidate;
        }
    }
}