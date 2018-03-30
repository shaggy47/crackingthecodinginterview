using System;
namespace SortingAlgorithms
{
    public class QuickSort: BaseSort
    {
        public QuickSort(int[] arr) : base(arr)
        {
        }

        private int Partition(int l, int h)
        {
            int pivote = array[h];
            int j = l-1;

            for (int i = l; i < h; i++)
            {
                if(array[i] <= pivote)
                {
                    j++;
                    Swap(j, i);
                }
                    
            }

            Swap(j + 1, h);
            return j + 1;
        }

        private void QuickSortAlgo(int l, int h)
        {
            if(l<h)
            {
                int p = Partition(l, h);
                QuickSortAlgo(l, p - 1);
                QuickSortAlgo(p+1, h);
            }
        }

		public override void Sort()
		{
            QuickSortAlgo(0, array.Length - 1);
		}
	}
}
