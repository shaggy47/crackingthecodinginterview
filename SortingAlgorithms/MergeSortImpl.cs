using System;
namespace SortingAlgorithms
{
    public class MergeSortImpl : BaseSort
    {
        public MergeSortImpl(int[] arr) : base(arr)
        {
        }

        private void Merge(int l, int m, int h)
        {
            int n1 = m - l + 1;
            int n2 = h - m;
            int[] L = new int[n1];
            int[] R = new int[n2];


            //copy l through m in L
            for (int i = 0; i < n1; i++)
                L[i] = array[l+i];

            // Copy m+1 through h in R
            for (int i = 0; i < n2; i++)
                R[i] = array[m+1+i];

            // perform merge.

            int index = l;
            int p, q;
            p = q= 0;
            while (p<n1 && q < n2)
            {
                if(p < n1 && L[p] <= R[q])
                {
                    array[index] = L[p];
                    p++;
                }
                else 
                {
                    array[index] = R[q];
                    q++;
                }

                index++;
                    
            }

            while (p < n1)
                array[index++] = L[p++];

            while (q < n2)
                array[index++] = L[q++];
            


        }

        private void MergeSort(int l, int h)
        {
            if (l < h)
            {
                int m = l+ (h - l) / 2;
                MergeSort(l, m);
                MergeSort(m + 1, h);
                Merge(l, m, h);
            }
        }

		public override void Sort()
		{
            MergeSort(0, array.Length-1);
		}
	}
}
